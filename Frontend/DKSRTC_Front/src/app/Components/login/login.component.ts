import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ILogin } from 'src/app/Interfaces/Ilogin';
import { AuthCheckService } from 'src/app/Services/auth-check.service';
import { UserServiceService } from 'src/app/Services/user-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass'],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  login?: ILogin;
  user: Array<ILogin> = [];
  constructor(
    private authService: AuthCheckService,
    private router: Router
  ) {}
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
  this.CreateForm()
  }
  GoSignUp() {
    this.router.navigate(['/user-signup']);
  }
  onLogin() {
    if (this.loginForm.valid) {
      const email = this.loginForm.value.email;
      const password = this.loginForm.value.password;
      this.authService.login(email, password).subscribe();
    }
  }    
}
