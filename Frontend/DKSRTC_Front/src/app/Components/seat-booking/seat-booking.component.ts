import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms'; // Import Validators and FormBuilder
import { ISeatReservation } from 'src/app/Interfaces/ISeatReservation';

@Component({
  selector: 'app-seat-booking',
  templateUrl: './seat-booking.component.html',
  styleUrls: ['./seat-booking.component.sass'],
})
export class SeatBookingComponent implements OnInit {
  selectedBusId!: number;
  seatRows: { selected: boolean }[][] = [];
  maxSelections = 4
  selectedSeats: string[] = [];
  selectedSeatsData: ISeatReservation[] = [];
  seatReservationForm!: FormGroup; // Define a form group for seat reservations

  constructor(
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder
  ) {
    // Initialize the form group with validators
  }
  CreateForm() {
    const formArray = this.formBuilder.array([]);
    this.seatReservationForm = this.formBuilder.group({
      passengers: formArray
    });
  }

  ngOnInit() {
    this.CreateForm();
    this.activatedRoute.queryParamMap.subscribe((x) => {
      const selectedBusIdParam = x.get('selectedBusId');
      if (selectedBusIdParam) {
        this.selectedBusId = parseInt(selectedBusIdParam, 10);
      }
    }); 

    // Initialize the seatRows (same as your previous code)
    for (let i = 0; i < 5; i++) {
      const row: { selected: boolean }[] = [];
      for (let j = 0; j < 6; j++) {
        row.push({ selected: false });
      }
      this.seatRows.push(row);
    }
  }


  AddToCheckOut(){}

  getSeatName(row: number, column: number): string {
    return String.fromCharCode(65 + column) + (row + 1);
  }

  selectSeat(row: number, column: number) {
    const seat = `${String.fromCharCode(65 + column)}${row + 1}`;

    const isSelected = this.seatRows[row][column].selected;
    const selectedCount = this.seatRows
      .map((row) => row.filter((seat) => seat.selected))
      .reduce((total, row) => total + row.length, 0);

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
      this.formArray.push(this.getControlGroup());
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
      Seat:['',[Validators.required]],
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
} 
