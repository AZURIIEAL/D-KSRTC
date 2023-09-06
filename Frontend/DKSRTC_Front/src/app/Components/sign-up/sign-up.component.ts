import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ILogin } from 'src/app/Interfaces/Ilogin';
import { UserServiceService } from 'src/app/Services/user-service.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.sass'],
})
export class SignUpComponent {
  public newUser: ILogin = {
    userId: 0,
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    phoneNumber: '',
    address: '',
  };
  public signUpForm!: FormGroup;
  constructor(
    private userService: UserServiceService,
    private fb: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this.signUpForm = this.fb.group({
      userId: new FormControl(''),
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      email: new FormControl(''),
      password: new FormControl(''),
      phoneNumber: new FormControl(''),
      address: new FormControl('')
    });
  }
  GoLogin(){
    this.router.navigate(['Login']);
    }
  signUp() {
    const val=this.signUpForm.value;
    const temp:ILogin={
      userId: val.userId,
      password: val.password || '',
      email: val.email || '',
      firstName: val.firstName||'',
      lastName: val.lastName||'',
      phoneNumber: val.phoneNumber||'',
      address: val.address||''
    }
    this.newUser.userId=temp.userId;
    this.newUser.password=temp.password;
    this.newUser.email=temp.email;
    this.newUser.firstName=temp.firstName;
    this.newUser.lastName=temp.lastName;
    this.newUser.phoneNumber=temp.lastName;
    this.newUser.address=temp.address;
    this.userService.addUser(this.newUser).subscribe(data=>{console.log(data)})
    alert("Successfully Registered");
    this.router.navigate(['']);
  }



}
