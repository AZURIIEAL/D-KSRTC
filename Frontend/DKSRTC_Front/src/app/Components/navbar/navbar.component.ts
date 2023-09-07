import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthCheckService } from 'src/app/Services/auth-check.service';

@Component({
  selector: 'app-navbar',
  standalone:true,
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.sass'],
  imports:[
    CommonModule
  ]
})
export class NavbarComponent implements OnInit {
  isLoggedIn = false;
  constructor(private router:Router,private authService:AuthCheckService){}
  ngOnInit() {
    this.authService.isLoggedIn().subscribe((status) => {
      this.isLoggedIn = status;
    })
  }
GoLogin() {
  this.router.navigate(['/user-login'])
}
GoLogOut(){
  alert("Do you want to log out?")
}

}
