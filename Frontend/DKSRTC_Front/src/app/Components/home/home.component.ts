import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ISearch } from 'src/app/Interfaces/Isearch';
import { ILocationDetails } from 'src/app/Interfaces/ILocationDetails';
import { dataLocationDetailsService } from 'src/app/Services/data-LocationDetails.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass'],
})

export class HomeComponent implements OnInit {
  constructor(private router: Router, private service: dataLocationDetailsService) {
    this.service.getLocationDetails().subscribe((data : Array<ILocationDetails>) =>{
      this.filteredOptions=data;
      this.locationList=this.filteredOptions.filter(x=>x.locationName.toLowerCase())
    console.log(data)
  });
  }

  busSearchForm = new FormGroup({
    fromLocation: new FormControl(null),
    toLocation: new FormControl(null),
    travelDate: new FormControl(null),
  });
  
  locationList: Array<ILocationDetails> = [];
  filteredOptions: ILocationDetails[]=[];

  searchCriteria: ISearch = {
    FromLocation: '',
    ToLocation: '',
    JourneyDate: new Date(),
  };

  ngOnInit() {
    this.filteredOptions = this.busSearchForm.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value || '')),
    );
  }

  
  searchBus() {
    const fromLocationControl = this.busSearchForm.get('fromLocation');
    const toLocationControl = this.busSearchForm.get('toLocation');
    const travelDateControl = this.busSearchForm.get('travelDate');

    if (fromLocationControl && toLocationControl && travelDateControl) {
      this.searchCriteria.FromLocation = fromLocationControl.value || '';
      this.searchCriteria.ToLocation = toLocationControl.value || '';
      this.searchCriteria.JourneyDate = travelDateControl.value || new Date();

      console.log('Searching for buses...');
      console.log('From:', this.searchCriteria.FromLocation);
      console.log('To:', this.searchCriteria.ToLocation);
      console.log('Date:', this.searchCriteria.JourneyDate);
      
      // Optionally, you can navigate to a new page using the router
      // this.router.navigate(['/search-results']); // Replace with your route
    }
  }
}
