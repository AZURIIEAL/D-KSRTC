import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HomeComponent } from './Components/home/home.component';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { AvailableBusesComponent } from './Components/available-buses/available-buses.component';
import { LoginComponent } from './Components/login/login.component';
import { SignUpComponent } from './Components/sign-up/sign-up.component';
import { SeatBookingComponent } from './Components/seat-booking/seat-booking.component';
import { LoadingComponent } from './Components/loading/loading.component';
import { LoadingInterceptor } from './Interceptors/loading.interceptor';
import { FooterComponent } from './Components/footer/footer.component';
import { NotFoundComponent } from './Components/not-found/not-found.component';
import { CheckOutComponent } from './Components/check-out/check-out.component';
import { PaymentGatewayComponent } from './Components/payment-gateway/payment-gateway.component';
import { UpcomingJourneyComponent } from './Components/upcoming-journey/upcoming-journey.component';
import { HistoryComponent } from './Components/history/history.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    SignUpComponent,
    AvailableBusesComponent,
    SeatBookingComponent,
    LoadingComponent,
    CheckOutComponent,
    PaymentGatewayComponent,
    FooterComponent,
    NotFoundComponent,
    CheckOutComponent,
    UpcomingJourneyComponent,
    HistoryComponent,
  ],
  imports: [
    MatSelectModule,
    FormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatFormFieldModule,
    MatInputModule,
    MatAutocompleteModule,
    ReactiveFormsModule,
    BrowserModule,
    NavbarComponent,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
  ],
  providers: [
    MatDatepickerModule,
    {
      //loading interceptor
      provide: HTTP_INTERCEPTORS,
      useClass: LoadingInterceptor,
      multi: true,
    },
  ],

  bootstrap: [AppComponent],
})
export class AppModule {}
