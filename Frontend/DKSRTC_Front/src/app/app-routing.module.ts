import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';

const routes: Routes = [
  {
    //Hence my default route will be the home component.
    path: '',
    component: HomeComponent,
    title: 'Home page',
  },]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})


export class AppRoutingModule { }
