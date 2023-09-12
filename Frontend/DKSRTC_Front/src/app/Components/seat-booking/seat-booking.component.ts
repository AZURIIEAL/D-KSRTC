import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import {
  AbstractControl,
  FormArray,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ISeatReservation } from 'src/app/Interfaces/ISeatReservation';
import { BookingService } from 'src/app/Services/booking.service';
import { Ipassenger } from '../../Interfaces/ipassenger';
import { AuthCheckService } from 'src/app/Services/auth-check.service';
import { ISeats } from 'src/app/Interfaces/iseats';

@Component({
  selector: 'app-seat-booking',
  templateUrl: './seat-booking.component.html',
  styleUrls: ['./seat-booking.component.sass'],
})
export class SeatBookingComponent implements OnInit {
  selectedBusId!: number;
  seatRows: { selected: boolean; booked: boolean }[][] = [];
  maxSelections = 4;
  selectedSeats: string[] = [];
  selectedSeatsData: ISeatReservation[] = [];
  seatReservationForm!: FormGroup;
  passengersToPush!: Ipassenger[];
  onRoute!: number;
  isLoggedIn = false;
  allSeats :ISeats[] = [];
  onDate!:Date;
  totalAmount!:number;

  constructor(
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private router:Router,
    private SeatService: BookingService,
    private authService: AuthCheckService
  ) {
    this.SeatService.getSeatAvailability(this.selectedBusId,new Date(this.onDate)).subscribe((data) => {
      for (const seatData of data) {
        const transformedSeat = {
          seatID: seatData.seatID,
          busID: seatData.busID,
          date: seatData.date,
          seatNumber: seatData.seatNumber,
          availability: seatData.availability,
        };
        this.allSeats.push(transformedSeat);
      }
      console.log(this.allSeats)
      this.updateSeatRows(data);
    });
  }

  CreateForm() {
    const formArray = this.formBuilder.array([]);
    this.seatReservationForm = this.formBuilder.group({
      passengers: formArray,
    });
  }

  ngOnInit() {
    this.authService.isLoggedIn().subscribe((status) => {
      this.isLoggedIn = status;
    });

    this.activatedRoute.queryParamMap.subscribe((x) => {
      const busRouteParam = x.get('busRouteId');
      if (busRouteParam) {
        this.onRoute = parseInt(busRouteParam, 10);
      }
      const onDateParam = x.get('journeyDate');
      if (onDateParam) {
        this.onDate = new Date(onDateParam);
      }
      const selectedBusIdParam = x.get('selectedBusId');
      if (selectedBusIdParam) {
        this.selectedBusId = parseInt(selectedBusIdParam, 10);
      }
      const fareParam = x.get('perTicketPrice');
      if (fareParam) {
        this.totalAmount = parseInt((+fareParam).toFixed(2));
      }

    });
    this.CreateForm();
  }
  AddToCheckOut() {
    if (this.isLoggedIn) {
      const passengersArray = this.seatReservationForm.get(
        'passengers'
      ) as FormArray;
      const passengerObjects: Ipassenger[] = [];

      passengersArray.controls.forEach((passengerForm: AbstractControl) => {
        if (passengerForm instanceof FormGroup && passengerForm.valid) {
          const seatName = passengerForm.get('SeatName')?.value
          const passenger: Ipassenger = {
            bookingId: 0, // You can set the appropriate booking ID here
            firstName: passengerForm.get('FirstName')?.value,
            lastName: passengerForm.get('LastName')?.value,
            age: passengerForm.get('Age')?.value,
            gender: passengerForm.get('Gender')?.value,
            seatName:seatName,
            seatId: this.allSeats.find(x=>x.seatNumber=seatName)?.seatID, // Use SeatName instead of Seat
            phoneNumber: passengerForm.get('PhoneNumber')?.value,
            email: passengerForm.get('Email')?.value,
          };
          this.SeatService.addPassengers(passenger)
          const user= this.authService.currentUserSession()
          const booking = {
            userId: user.userId, 
            busRoute:this.onRoute , 
            bookingDate: new Date(), // Current date
            journeyDate: this.onDate, // Set the journey date accordingly
            amount: (this.selectedSeatsData.length)*this.totalAmount, // Set the booking amount accordingly
          };
          this.SeatService.addBooking(booking);
        }
      });
      
    
      this.router.navigate(['/confirm-checkout'])
    
    } else {
      alert('Please login to continue');
    }
  }

  getSeatName(row: number, column: number): string {
    return String.fromCharCode(65 + column) + (row + 1);
  }

  selectSeat(row: number, column: number) {
    const seat = `${String.fromCharCode(65 + column)}${row + 1}`;
    const isSelected = this.seatRows[row][column].selected;
    const isBooked = this.seatRows[row][column].booked; // Check if the seat is booked

    const selectedCount = this.seatRows
      .map((row) => row.filter((seat) => seat.selected))
      .reduce((total, row) => total + row.length, 0);

    if (isBooked) {
      // If the seat is booked, do nothing
      return;
    }

    if (isSelected) {
      this.seatRows[row][column].selected = false;
      const index = this.selectedSeats.indexOf(seat);
      if (index !== -1) {
        this.selectedSeats.splice(index, 1);
        this.formArray.removeAt(index);
      }
      this.selectedSeatsData = this.selectedSeatsData.filter(
        (reservation) => reservation.SeatId !== seat
      );
    } else {
      if (selectedCount >= this.maxSelections) {
        return;
      }
      const temp = this.getControlGroup();
      temp.patchValue({
        SeatName: seat,
      });
      this.formArray.push(temp);
      this.seatRows[row][column].selected = true;
      this.selectedSeats.push(seat);
      this.selectedSeatsData.push({
        FirstName: '',
        LastName: '',
        Age: null,
        Gender: '',
        SeatId: seat,
        PhoneNumber: '',
        Email: '',
      });
    }
  }

  getPassengersGroup(index: number): FormGroup {
    return this.formArray.at(index) as FormGroup;
  }

  private getControlGroup() {
    return this.formBuilder.group({
      SeatName: ['', [Validators.required]],
      FirstName: ['', [Validators.required, Validators.minLength(2)]],
      LastName: ['', [Validators.required, Validators.minLength(2)]],
      Age: ['', [Validators.required, Validators.min(0)]],
      Gender: ['', Validators.required],
      PhoneNumber: ['', [Validators.required, Validators.pattern('[0-9]{10}')]],
      Email: ['', [Validators.required, Validators.email]],
    });
  }

  get formArray() {
    return this.seatReservationForm.get('passengers') as FormArray;
  }

  updateSeatRows(seatAvailabilityData: any) {
    for (let i = 0; i < 5; i++) {
      const row: { selected: boolean; booked: boolean }[] = [];
      for (let j = 0; j < 6; j++) {
        const seatId = `${String.fromCharCode(65 + j)}${i + 1}`;
        const availability = seatAvailabilityData[seatId];

        // Set the selected property based on availability
        row.push({ selected: false, booked: availability === 'BOOKED' });
      }
      this.seatRows.push(row);
    }
  }
}
