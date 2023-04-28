import { BookingService } from './../../Services/booking.service';
import { CartService } from './../../Services/cart.service';
import { Component,EventEmitter,Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Booking } from 'src/app/Classes/booking';
import { Ticket } from 'src/app/Classes/ticket';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {
  book:Ticket[]=[]
  tic:Ticket= new Ticket
  booking:Booking= new Booking()
  empid:any;

  

  constructor(private router: Router,private CartService: CartService, private BookingService:BookingService){}
ngOnInit(): void {
this.book= this.CartService.getCart()

console.log(this.book);

}

Delete(id:number){
  
this.empid=id;

const index = this. book.findIndex(item => item.id === this.empid);

if (index !== -1) {
 this. book.splice(index, 1);

}
}


bookingticket(id:number)
{
   this.booking.ticketId=id;
   const user= sessionStorage.getItem('id') as string;
    const users=JSON.parse(user) 
    this.booking.userId=users;
    this.savebooking(this.booking)

}

savebooking(Booking:Booking)
{
this.BookingService.booking(Booking).subscribe(
  (response)=>{
     alert("Booking Successfuly")
     this.router.navigateByUrl("/home")
  },
  (err)=>{
alert("Tickets are not available")
  }
  
)
}



  
}

