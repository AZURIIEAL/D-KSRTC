import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ILogin } from 'src/app/Interfaces/Ilogin';
import { AuthCheckService } from 'src/app/Services/auth-check.service';
import { UserAddService } from 'src/app/Services/user-add.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.sass'],
})
export class SignUpComponent implements OnInit {
  addUserForm!: FormGroup;
  isLoggedIn = false;
  public newUser: ILogin = {
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    phoneNumber: '',
    address: '',
  };
  constructor(private router: Router,private authService:AuthCheckService,private userService:UserAddService) {}
  CreateForm() {
    this.addUserForm = new FormGroup({
      firstName: new FormControl('', [
        Validators.required,
        Validators.minLength(2),
      ]),
      lastName: new FormControl('', [
        Validators.required,
        Validators.minLength(2),
      ]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(8),
      ]),
      phoneNumber: new FormControl('', [
        Validators.required,
        Validators.pattern('[0-9]{10}'),
      ]),
      address: new FormControl('', [Validators.required]),
    });
  }
  ngOnInit() {
    this.CreateForm();
    this.authService.isLoggedIn().subscribe((status) => {
      this.isLoggedIn = status;
    })
  }
  
  GoLogin() {
    this.router.navigate(['Login']);
  }
  signUp() {
    if (!this.isLoggedIn) {
      const newUser: ILogin = this.addUserForm.value;
      this.userService.AddNewUser(newUser).subscribe(
        (res) => {
          if (res) {
            alert("User created successfully");
            this.router.navigate(['user-login']);
          } else {
            alert("User creation failed");
          }
        }
    )}
    

    
  }
}
