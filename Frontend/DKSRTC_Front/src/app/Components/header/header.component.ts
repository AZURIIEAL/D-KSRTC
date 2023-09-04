import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginServiceService } from 'src/app/Services/login-service.service';
import { UserServiceService } from 'src/app/Services/user-service.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.sass']
})
export class HeaderComponent {

  constructor(private router: Router, private loginService: LoginServiceService, private userService: UserServiceService) { }

  ngOnInit() {
  }
  get isAdminLogin() {
    return this.loginService.isAdminLogin();
  }
 
  get isCustomerLogin() {
    return this.loginService.isCustomerLogin();
  }
  // get getavalia() {
  //  return this.userService.avail;
  // }
  logout() {
    this.loginService.isAdminLoggedIn = false;
    
    this.loginService.isCustomerLoggedIn = false;
    this.router.navigateByUrl('/');
  }
}
