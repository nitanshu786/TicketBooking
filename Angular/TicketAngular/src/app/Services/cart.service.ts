import { Injectable } from '@angular/core';
import { Ticket } from '../Classes/ticket';
import { BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class CartService {

 cartItems:Ticket[]=[];
 index:any
 private cartItemCount = new BehaviorSubject<number>(0);

  constructor(private router:Router) {
 
    const storedCartItems = localStorage.getItem('cartItems');
    if (storedCartItems) {
      this.cartItems = JSON.parse(storedCartItems);
      this.updateCartItemCount();
    }
   }

  addToCart(item: Ticket) {
    const existingItem = this.cartItems.find(cartItem => cartItem.id === item.id);
    if (existingItem) {
      existingItem.count += item.count;
    } else {
      const user= sessionStorage.getItem('id') as string;
      const users=JSON.parse(user)
      item.userid=users
     console.log(item)
    this.cartItems.push(item);
  
    }
     this.updateCartItemCount();
     this.saveCartItemsToLocalStorage();
 
  }

  getCart() {
   
    return this. cartItems
  }
  getuserID() {
    const user= sessionStorage.getItem('id') as string;
     const users=JSON.parse(user) 
    return users
  }

  getCartItemCount() {
    return this.cartItemCount.asObservable();
  }
  removeFromCart(item: number) {
    debugger
     this. index = this. cartItems.findIndex(itm => itm.id === item);

 if ( this.index !== -1) {
     this. cartItems.splice(this.index, 1);
     this.updateCartItemCount();
     this.saveCartItemsToLocalStorage();
     }
    if ( this.cartItems.length == 0) {
      this.router.navigateByUrl("/home")
    }

  }

  private updateCartItemCount() {
    this.cartItemCount.next(this.cartItems.length)
  }

  private saveCartItemsToLocalStorage() {
    localStorage.setItem('cartItems', JSON.stringify(this.cartItems));
  }
}
