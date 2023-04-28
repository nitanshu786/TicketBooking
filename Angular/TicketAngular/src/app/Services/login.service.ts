import { Observable, map } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Router } from '@angular/router';
import { Login } from '../Classes/login';
import { Booking } from '../Classes/booking';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Role } from '../Classes/role';


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  CourentUser:any;
 
 Roles:any
  

  constructor(private httpclient:HttpClient, private router:Router,private jwtHealper:JwtHelperService) { }



  loginup(newemp:Login):Observable<Login>
  {
    return this.httpclient.post<Login>("https://localhost:44334/api/RegisterAPI/Login",newemp).

    pipe(map(u=>{
          if(u)
          {
            this.CourentUser=u.email;
            this.Roles=u.role
             sessionStorage["id"]=JSON.stringify(u.id);
             sessionStorage["role"]=JSON.stringify(u.role)
            
            //  const user= sessionStorage.getItem('role')as string;
            //  const users =JSON.parse(user);
            //  this.Roles= users;
          
            sessionStorage["CurrentUser"]=JSON.stringify(u);
          }
      return u;
    }))
      }
      LogOut()
      {
         this.CourentUser="";
         sessionStorage.removeItem("CurrentUser");
          sessionStorage.removeItem("role");
        this.router.navigateByUrl("/login");
    
      }
      // public getUserId(): string {
      // var token = sessionStorage.getItem("CurrentUser");
      //   var decodedToken = this.jwtHelper.decodeToken(token);
      //   return decodedToken.id;
      // }
      public isAuthentication():boolean
      {
       
        if(this.jwtHealper.isTokenExpired())
        {
          return false;
        }
       
       else
       {
            return true;
       }


  
         
       
        
      }
}
