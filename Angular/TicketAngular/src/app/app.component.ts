
import { Component,OnInit } from '@angular/core';
import { LoginService } from './Services/login.service';
import { TicketService } from './Services/ticket.service';
import { Ticket } from './Classes/ticket';
import { Role } from './Classes/role';
import { Login } from './Classes/login';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'TicketAngular';
  roles:any;
  

  

  
  constructor( public loginapi:LoginService) { 
   
  }

ngOnInit(): void {   
}
  Logot()
  {
    this.loginapi.LogOut();
  }
}
