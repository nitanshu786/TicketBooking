import { Injectable } from '@angular/core';
import { Ticket } from '../Classes/ticket';

@Injectable({
  providedIn: 'root'
})
export class CartService {

 cartItems:any[]=[];

  constructor() { }

  addToCart(item: Ticket) {
    this.cartItems.push(item);
   console.log(this.cartItems)
      sessionStorage['carts']=JSON.stringify(this.cartItems);
  }

  getCart() {
     const myArray = JSON.parse(sessionStorage.getItem('carts') || '[]');
    return myArray
    // const user= sessionStorage.getItem('carts') as any;
    // const users= JSON.parse(user)
    // return users;
  
  }

 
}
