import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Booking } from 'src/app/Classes/booking';
import { Register } from 'src/app/Classes/register';
import { RegisterService } from 'src/app/Services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
book:Booking= new Booking();
  newRegister:Register= new Register();
  
   
   

  constructor(private registerservice:RegisterService, private router:Router){}
  
  
  regClick()
    {
      debugger;
     
     
      this.registerservice.emailuser(this.newRegister).subscribe(
        (response)=>{
         
          this.newRegister.name="";
          this.newRegister.address="";
          this.newRegister.email="";
       
        },
        (error)=>{
          console.log(error);
          alert("Wrong UserName & Passward");
        }
      )
    
  }

}
