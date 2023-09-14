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
    //a for each loop is attached to the subscribe to observe the changes in the seats.
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
      //A method called UpdateSeatRows is called here.
      this.updateSeatRows(data);
    });
  }

  //a method to create forms and it is called in the NgOnit.
  CreateForm() {
    //Using formarray
    const formArray = this.formBuilder.array([]);
    this.seatReservationForm = this.formBuilder.group({
      passengers: formArray,
    });
  }

  ngOnInit() {
    //checking the authentication and who is the current User.
    this.authService.isLoggedIn().subscribe((status) => {
      this.isLoggedIn = status;
    });

    //getting the values from the route.
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
    //calling the CreateForm function to make the forms(inside the OnInit).
    this.CreateForm();
  }
  AddToCheckOut() {
    if (this.isLoggedIn) {
      //Getting the data from the formarray and passing it to a const.
      const passengersArray = this.seatReservationForm.get(
        'passengers'
      ) as FormArray;

      //For each passenger form:(These are for packing the objects so that we could easily send it to the backend API's)
      passengersArray.controls.forEach((passengerForm: AbstractControl) => {
        if (passengerForm instanceof FormGroup && passengerForm.valid) {
          //Keeping the seatName in a const as we will be searching for the values later in the allSeats data.
          const seatName = passengerForm.get('SeatName')?.value
          const passenger: Ipassenger = {
            bookingId: 0, //Setting the booking Id to 0 temporarily(As we will get the data from backend andwe can manually alter it there.)
            firstName: passengerForm.get('FirstName')?.value,
            lastName: passengerForm.get('LastName')?.value,
            age: passengerForm.get('Age')?.value,
            gender: passengerForm.get('Gender')?.value,
            seatName:seatName,
            seatId: this.allSeats.find(x=>x.seatNumber==seatName)?.seatID, // searching the values from the allseats data and then alloting the value.
            phoneNumber: passengerForm.get('PhoneNumber')?.value,
            email: passengerForm.get('Email')?.value,
          };
          //Adding the current passenger object to the passenger[] in the service as we need the packed object later,for sending it in the Api.
          this.SeatService.addPassengers(passenger)
          //Getting the current user data from the authService ,as we will be packing the object so that the Api can carry the data easily as a collection of list of objects.
          const user= this.authService.currentUserSession()
          //Packing the booking header data.
          const booking = {
            userId: user.userId, 
            busRoute:this.onRoute , 
            bookingDate: new Date(), // Current date.
            journeyDate: this.onDate, // Set the journey date accordingly.
            amount: (this.selectedSeatsData.length)*this.totalAmount, // Set the booking amount accordingly.
          };
          //Adding the data to the service.
          this.SeatService.addBooking(booking);
        }
      });
      
    //As there isnt any meaning in staying here we can navigate the router to the respective component.
      this.router.navigate(['/confirm-checkout'])
    
    } else {
      alert('Please login to continue');
    }
  }

  //This is useful in the HTML template.
  getSeatName(row: number, column: number): string {
    return String.fromCharCode(65 + column) + (row + 1);
  }

  //Used in the HTML template.
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

  //The Grid Driver
  updateSeatRows(seatAvailabilityData: any) {

    //First there will be row allocation
    for (let i = 0; i < 5; i++) {
      //Then a row variable is declared (an array of objects)
      const row: { selected: boolean; booked: boolean }[] = [];
      for (let j = 0; j < 6; j++) {
        row.push({ selected: false, booked: false });
      }
      this.seatRows.push(row);
    }
  }
}
