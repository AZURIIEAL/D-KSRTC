import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-seat-booking',
  templateUrl: './seat-booking.component.html',
  styleUrls: ['./seat-booking.component.sass']
}) 
export class SeatBookingComponent implements OnInit {
  selectedBusId!: number;
  seatRows: { selected: boolean }[][] = [];
  maxSelections = 4; // Maximum number of allowed seat selections

  constructor(private activatedRoute: ActivatedRoute) {
  }

  ngOnInit() {
    this.activatedRoute.queryParamMap.subscribe((x) => {
      const selectedBusIdParam = x.get('selectedBusId');
      if (selectedBusIdParam) {
        this.selectedBusId = parseInt(selectedBusIdParam, 10);
      }
    });
    // 5 rows and 6 coloumns
    for (let i = 0; i < 5; i++) {
      const row: { selected: boolean }[] = [];
      for (let j = 0; j < 6; j++) {
        row.push({ selected: false });
      }
      this.seatRows.push(row);
    }
  }
  selectSeat(row: number, column: number) {
    // Check if the seat is already selected
    const isSelected = this.seatRows[row][column].selected;

    // Count the currently selected seats
    //Code From GPT
    const selectedCount = this.seatRows
      .map((row) => row.filter((seat) => seat.selected))
      .reduce((total, row) => total + row.length, 0);
    // If the seat is already selected, deselect it
    if (isSelected) {
      this.seatRows[row][column].selected = false;
    } else {
      // Check if the user has already selected the maximum number of seats
      if (selectedCount >= this.maxSelections) {
        // Optionally, you can provide a message to the user here to indicate the limit has been reached.
        return;
      }
      // Toggle the selected state of the seat
      this.seatRows[row][column].selected = true;
    }
  }
}




