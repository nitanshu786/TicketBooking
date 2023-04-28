import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Register } from 'src/app/Classes/register';
import { RegisterService } from 'src/app/Services/register.service';

@Component({
  selector: 'app-password',
  templateUrl: './password.component.html',
  styleUrls: ['./password.component.scss']
})
export class PasswordComponent {



  constructor(private registerservice:RegisterService, private router:Router){}
  
  newRegister:Register= new Register();
  regClick()
    {
     debugger; 
      const user= sessionStorage.getItem('register') as any;
      const value= JSON.parse(user);
      
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
