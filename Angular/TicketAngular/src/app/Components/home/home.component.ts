import { Ticket } from 'src/app/Classes/ticket';
import { Component,OnInit, Input } from '@angular/core';
import { TicketService } from 'src/app/Services/ticket.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  ticket:Ticket[]=[];

  constructor ( private Ticketservice : TicketService){}
  

  ngOnInit(): void {
    this.getALL();
  }
   getALL()
   {
     
 
     this.Ticketservice.GetEmployes().subscribe(
       (respnse)=>{
         this.ticket=respnse
        
       },
       (error)=>{
         console.log(error);
       }
     )
   }
}
