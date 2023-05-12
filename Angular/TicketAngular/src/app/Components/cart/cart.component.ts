
import { BookingService } from './../../Services/booking.service';
import { CartService } from './../../Services/cart.service';
import { Component,EventEmitter,Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Booking } from 'src/app/Classes/booking';
import { Ticket } from 'src/app/Classes/ticket';
import Swal,{SweetAlertOptions} from 'sweetalert2';
import { array } from 'yup';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {
  book:Ticket[]=[]
 
  booking:Booking= new Booking()
  index:any;

  

  constructor(private router: Router,private cartService: CartService,
     private BookingService:BookingService){}
ngOnInit(): void {
  const ID= this.cartService.getuserID()
this.book= this.cartService.getCart()
if(this.book!=null)
{
  debugger
  const value= this.book.findIndex(s=>s.userid===ID)
  console.log(value);
  if(value!=-1){
   this.book= this.cartService.getCart()
   
  }
  else{
     this.book=[]
  }
}


}

Delete(id:number){
this.cartService.removeFromCart(id)
}


bookingticket(reg:Ticket)
{
  debugger;
  
  Swal.fire({
    title: 'Please wait!',
    customClass: 'swal2-progresssteps',
    timerProgressBar: true,
    timer: 3000,
    didOpen: () => {
      Swal.showLoading();
    }
  });
   this.booking.ticketId=reg.id;
   this.booking.count=reg.count
   const user= sessionStorage.getItem('id') as string;
    const users=JSON.parse(user) 
    this.booking.userId=users;
    this.savebooking(this.booking)

}

savebooking(Booking:Booking)
{
  debugger;
this.BookingService.booking(Booking).subscribe(
  (response)=>{
this.Delete(this.booking.ticketId)
Swal.close();
    Swal.fire({
      icon: 'success',
      title: 'Booking successfully',
      showConfirmButton: false,
      timer: 1500
    });
     this.router.navigateByUrl("/home")
  },
  (err)=>{
   Swal.close()
    Swal.fire({
      icon: 'error',
      title: 'Tickets not available',
      text: 'Sorry, all tickets for this event have been sold out. Please check back later or try another event.',
      confirmButtonText: 'OK'
    });
  }
  
)
}

  decreaseCount(items:Ticket)
  {
    debugger;
    if (items.count > 1) {
      items.count--;
    }
    if(items.count==0)
    {
      debugger
      this.Delete(items.id)
      this.router.navigateByUrl("/home")
      
    }
  }
  increaseCount(item:Ticket)
  {
item.count++
  }
}









 


