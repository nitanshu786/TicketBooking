
import { Component,OnInit } from '@angular/core';
import { LoginService } from './Services/login.service';
import { TicketService } from './Services/ticket.service';
import { Ticket } from './Classes/ticket';
import { Role } from './Classes/role';
import { Login } from './Classes/login';
import { Router } from '@angular/router';
import { CartService } from './Services/cart.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'TicketAngular';

  count=0;
  
 


  

  constructor( public loginapi:LoginService,private router: Router,
    private CartService: CartService) { 
  }

ngOnInit(): void {  
   
  this.CartService.getCartItemCount().subscribe(counts=>{
  
    this.count = counts;
  })
 
  
  }
  
  Logot()
  {
    this.loginapi.LogOut();
  }

}
