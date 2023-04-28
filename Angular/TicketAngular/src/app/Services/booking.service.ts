import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Booking } from '../Classes/booking';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private HttpClient:HttpClient) { }

  booking(newbok:Booking):Observable<any>
  {
    debugger;
    return this.HttpClient.post<any>("https://localhost:44334/api/BookingAPI",newbok);
  }

  GetALL():Observable<any>
  {
    return this.HttpClient.get<any>("https://localhost:44334/api/BookingAPI");
  }

}
