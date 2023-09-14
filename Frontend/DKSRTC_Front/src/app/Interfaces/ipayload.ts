import { IBillingPayload } from './ibilling-payload';
import { IBookingPayload } from './ibooking-payload';
import { IPassengerPayload } from './ipassenger-payload';
import { IPaymentPayload } from './ipayment-payload';

export interface IPayload {
  booking: IBookingPayload;
  passengers: IPassengerPayload[];
  billing: IBillingPayload;
  payment: IPaymentPayload;
}
