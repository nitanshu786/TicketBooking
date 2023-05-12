import { CartService } from './../../Services/cart.service';
import { LoginService } from 'src/app/Services/login.service';
import { BookingService } from './../../Services/booking.service';
import { Ticket } from 'src/app/Classes/ticket';
import { Component,OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TicketService } from 'src/app/Services/ticket.service';
import { Booking } from 'src/app/Classes/booking';
import { Router } from '@angular/router';




@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  ticket:Ticket[]=[];
  booking:Booking= new Booking();
  data:Ticket= new Ticket;
  ticketCount: number = 0;

 
  


     constructor ( private Ticketservice : TicketService,
     private BookingService: BookingService,
     private LoginService: LoginService, private router:Router,
     private CartService:CartService,
    
    ){}
  
  

  ngOnInit(): void {
    this.getALL();
  }
   getALL()
   {
     this.Ticketservice.GetEmployes().subscribe(
       (respnse)=>{
         this.ticket=respnse

         const ticketIndex = this.ticket.findIndex(s => s.count); 
      this.ticketCount = this.ticket[ticketIndex].count; 

    
       },
       (error)=>{
         console.log(error);
       }
     )
   }
   bookingticket(emps:Ticket)
   {
   this.data=emps;
   this.data.count=1;
    this.CartService.addToCart(this.data);
    this.router.navigateByUrl("/cart")
  
   }



  }
   
