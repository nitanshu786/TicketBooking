import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { Register } from '../Classes/register';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private httpclient:HttpClient ) { }


  checkUser(newemp:Register):Observable<Register>
  {
    return this.httpclient.post<Register>("https://localhost:44334/api/RegisterAPI/register",newemp)
  }

}
