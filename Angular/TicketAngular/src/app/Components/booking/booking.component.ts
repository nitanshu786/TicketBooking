import { Booking } from 'src/app/Classes/booking';
import { Component, OnInit } from '@angular/core';

import { BookingService } from 'src/app/Services/booking.service';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.scss']
})
export class BookingComponent implements OnInit  {

booking:Booking[]=[]

constructor(public Bookingservice: BookingService){}

ngOnInit(): void {
  this.getALL();
}

 getALL()
 {
   

   this.Bookingservice.GetALL().subscribe(
     (respnse)=>{
       this.booking = respnse;
       console.log(this.booking);
      
     },
     (error)=>{
       console.log(error);
     }
   )
 }

}
