import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { IBookedBus } from '../Interfaces/ibooked-bus';

@Injectable({
  providedIn: 'root'
})
export class BookedBusService {

  constructor() { }
  public selectData=new BehaviorSubject<Array<IBookedBus>>([]);
  select=this.selectData.asObservable();
}
