import { Observable, map } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from '../Classes/login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  CourentUser:any;

  constructor(private httpclient:HttpClient, private router:Router) { }



  loginup(newemp:Login):Observable<Login>
  {
    return this.httpclient.post<Login>("https://localhost:44334/api/RegisterAPI/Login",newemp).

    pipe(map(u=>{
          if(u)
          {
            this.CourentUser=u.email;
            sessionStorage["CurrentUser"]=JSON.stringify(u);
          }
      return u;
    }))
      }
      LogOut()
      {
        this.CourentUser="";
        sessionStorage.removeItem("CurrentUser");
        this.router.navigateByUrl("/login");
    
      }
      // public isAuthentication():boolean
      // {
      //   if(this.jwtHealper.isTokenExpired())
      //   {
      //     return false;
      //   }
      //   else{
      //     return true;
      //   }
      // }
}
