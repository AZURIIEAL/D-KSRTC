import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthCheckService } from 'src/app/Services/auth-check.service';
import { RouterModule } from '@angular/router';


@Component({
  selector: 'app-navbar',
  standalone:true,
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.sass'],
  imports:[
    CommonModule,
    RouterModule
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
GoLogOut() {
  if (this.isLoggedIn) {
    const text = "Do you want to log out?";
    if (confirm(text) == true) {
      this.authService.logOut();
      this.router.navigate(['/user-login']);
      window.location.reload();
    } else {
    }
  }
}


}

