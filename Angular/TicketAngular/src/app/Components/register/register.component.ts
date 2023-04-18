import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Register } from 'src/app/Classes/register';
import { RegisterService } from 'src/app/Services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  newRegister:Register= new Register();
   date: Date=new Date;
   
   

  constructor(private registerservice:RegisterService, private router:Router){}
  
  
  regClick()
    {
      
      
      this.registerservice.checkUser(this.newRegister).subscribe(
        (response)=>{
          this.router.navigateByUrl("/login");
        },
        (error)=>{
          console.log(error);
          alert("Wrong UserName & Passward");
        }
      )
    
  }

}
