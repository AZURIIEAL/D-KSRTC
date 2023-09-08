import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import {  Router } from '@angular/router';
import { ILogin } from 'src/app/Interfaces/Ilogin';
import { AuthCheckService } from 'src/app/Services/auth-check.service';
import { IUser } from '../../Interfaces/IUser';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass'],
})
export class LoginComponent implements OnInit {
  hasClinkedLogin = false;
  hasError = false;
  loginForm!: FormGroup;
  login?: ILogin;
  currentUser!: IUser;
  constructor(private authService: AuthCheckService, private router: Router) {}
  CreateForm() {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(8),
      ]),
    });
  }
  ngOnInit() {
    this.CreateForm();
  }
  GoSignUp() {
    this.router.navigate(['/user-signup']);
  }
  onLogin() {
    if (this.loginForm.valid) {
      const email = this.loginForm.value.email;
      const password = this.loginForm.value.password;
      this.authService.login(email, password).subscribe(userDetailsCurrentSession=>{
        this.hasClinkedLogin = true
        try{
          if(userDetailsCurrentSession){
            this.currentUser=userDetailsCurrentSession;
            this.hasError=false;
            alert(`Welcome ${this.currentUser.firstName},You have succesfully logged in`)
            this.router.navigate([''])
          } else {
            this.hasError = true;
          }
        }
        catch(ex){
          this.hasError=true;
        }
        
      });
    }
  }
}
