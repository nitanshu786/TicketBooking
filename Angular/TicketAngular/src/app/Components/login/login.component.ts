import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from 'src/app/Classes/login';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  login:Login = new Login();
   


  constructor(private loginrservice: LoginService, private router:Router){
  }
  LoginClick()
  {
    this.loginrservice.loginup(this.login).subscribe(
      (response)=>{
     
      },
      (error)=>{
        console.log(error);
        alert("Wrong UserName & Passward");
      }
    )
  }

}
