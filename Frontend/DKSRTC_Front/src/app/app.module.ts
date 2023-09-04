import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserRedirectionPageComponent } from './Components/user-redirection-page/user-redirection-page.component';
import { UserPageComponent } from './Components/user-page/user-page.component';
import { AdminPageComponent } from './Components/admin-page/admin-page.component';
import { AddNewUserComponent } from './Components/add-new-user/add-new-user.component';
import { HomeComponent } from './Components/home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    UserRedirectionPageComponent,
    UserPageComponent,
    AdminPageComponent,
    AddNewUserComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
