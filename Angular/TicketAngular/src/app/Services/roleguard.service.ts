
import { LoginService } from 'src/app/Services/login.service';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

import { ActivatedRouteSnapshot, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtActiveGuardService } from './jwt-active-guard.service';
import { Role } from '../Classes/role';
import { Login } from '../Classes/login';

@Injectable({
  providedIn: 'root'
})
export class RoleguardService {
  
  log:Login= new Login();

  constructor(private login:LoginService, private router:Router,
     private jwthealper:JwtActiveGuardService) { }
 
  canActivate(route: ActivatedRouteSnapshot,state:RouterStateSnapshot): boolean{
   
     const user= sessionStorage.getItem('role')as any;
     const users=JSON.parse(user) 
     this.log.role=users;

  const isAuthrized= this.log.role===(route.data['role']);
  if(!isAuthrized)
  {
    alert("You are not Authrized to Access these")
    return false;
  }
  return true
  }
   
   
   
    
  
  
}
