import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ILogin } from 'src/app/Interfaces/Ilogin';
import { UserServiceService } from 'src/app/Services/user-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent {
  loginForm!:FormGroup;
  login?:ILogin;
  user:Array<ILogin>=[]
  constructor(private userService:UserServiceService,private fb:FormBuilder,private router:Router)
  {
   this.userService.getLoginDetails().subscribe((data:Array<ILogin>)=>{this.user=data;
   console.log(this.user)})
  }
 
  ngOnInit(){
   this.loginForm=this.fb.group({
     userId:new FormControl(''),
     password:new FormControl('',Validators.required)
   })
 }
 GoSignUp(){
 this.router.navigate(['SignUp']);
 }
 
 onLogin(){
   let userDetails=this.loginForm.value;
   this.login=this.user.find(x=>x.userId===userDetails.userId)
   console.log(this.login?.userId)

   if(userDetails.userId===this.login?.userId)
      {
        if(userDetails.password===this.login?.password)
        {
          alert('Login Succesful');
        this.loginForm.reset()
          this.router.navigate(['']);
          
        }
        else{
          alert("Wrong Password")
        }
        
      }
      else{
        alert("user not found")
 }

}
}
