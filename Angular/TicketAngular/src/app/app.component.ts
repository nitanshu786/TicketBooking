import { Component,OnInit } from '@angular/core';
import { LoginService } from './Services/login.service';
import { TicketService } from './Services/ticket.service';
import { Ticket } from './Classes/ticket';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'TicketAngular';
  ticket:Ticket= new Ticket()

  
  constructor( public loginapi:LoginService,) { }
 

 

  Logot()
  {
    this.loginapi.LogOut();
  }
}
