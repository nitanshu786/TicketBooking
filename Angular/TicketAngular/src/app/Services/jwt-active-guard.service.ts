import { Injectable } from '@angular/core';
import { LoginService } from './login.service';
import { ActivatedRouteSnapshot, Router,CanActivate } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class JwtActiveGuardService implements CanActivate {

  constructor(private login:LoginService, private router:Router, private jwthealper:JwtHelperService) { }

  canActivate(route: ActivatedRouteSnapshot): boolean{
  
   
    if(this.login.isAuthentication())
    {
      return true;
    }
    else{
      this.router.navigateByUrl("/login")
      return false;
    }
    
  }
}
