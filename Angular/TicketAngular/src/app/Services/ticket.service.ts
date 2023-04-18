import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ticket } from '../Classes/ticket';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  constructor(private httpClient: HttpClient ) { }


  GetEmployes():Observable<any>
  {
    return this.httpClient.get<any>("https://localhost:44334/api/TicketAPI/get")
  }

  saveEmployes(newemp:Ticket):Observable<Ticket>
  {
    return this.httpClient.post<Ticket>("https://localhost:44334/api/TicketAPI/save",newemp)
  }

  updateemploye(upemp:Ticket):Observable<Ticket>
  {
    return this.httpClient.put<Ticket>("https://localhost:44334/api/TicketAPI/update",upemp)
  }

  Delete(Id:Number):Observable<any>
  {
    return this.httpClient.delete<any>("https://localhost:44334/api/TicketAPI/?id="+Id)
  }
}
