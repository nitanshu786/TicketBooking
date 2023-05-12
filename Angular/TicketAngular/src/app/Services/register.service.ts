import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable, map } from 'rxjs';
import { Register } from '../Classes/register';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private httpclient:HttpClient ) { }
 
  checkUser(newemp:Register):Observable<Register>
  {
      
    return this.httpclient.put<Register>("https://localhost:44334/api/RegisterAPI/update",newemp);
  }
 emailuser(email:Register):Observable<Register>
 {
  
  return this.httpclient.post<Register>("https://localhost:44334/api/RegisterAPI/register",email)

  
 }
}
  


