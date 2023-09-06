import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
<<<<<<< HEAD
import { AvailableBusesComponent } from './Components/available-buses/available-buses.component';
=======
import { LoginComponent } from './Components/login/login.component';
import { SignUpComponent } from './Components/sign-up/sign-up.component';
>>>>>>> 802ac007ca931749df9706fe7484231a36a6cde0

const routes: Routes = [
  {
    //Hence my default route will be the home component.
    path: '',
    component: HomeComponent,
    title: 'Home page',
  },
  {
<<<<<<< HEAD
    path: 'available-buses',
    component: AvailableBusesComponent,
    title: 'Available Buses',
  },
=======
    path:'Login',
    component:LoginComponent,
    title: 'login'
  },
  {
    
      path:'SignUp',
      component:SignUpComponent,
      title: 'SignUp'
    ,
  }


>>>>>>> 802ac007ca931749df9706fe7484231a36a6cde0
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
