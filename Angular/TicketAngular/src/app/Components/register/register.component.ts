import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Booking } from 'src/app/Classes/booking';
import { Register } from 'src/app/Classes/register';
import { RegisterService } from 'src/app/Services/register.service';

import Swal from 'sweetalert2';
import { string } from 'yup';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
book:Booking= new Booking();
  newRegister:Register= new Register();
  isLoading :boolean=false;
message: string='';
  registerForm!: FormGroup;
   

  constructor(private registerservice:RegisterService, private router:Router,private fb: FormBuilder){}
  
  ngOnInit(): void {
    this.registerForm = this.fb.group({
      name: ['', [Validators.required, Validators.pattern('^[a-zA-Z ]*$')]],
      address: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }
  regClick()
    {
      Swal.fire({
        title: 'Please wait!',
        customClass: '.swal2-progresssteps',
        timerProgressBar: true,
        timer: 15000,
        didOpen: () => {
          Swal.showLoading();
        }
      });
  
      this.registerservice.emailuser(this.newRegister).subscribe(
        (response)=>{
        
        Swal.close();
          Swal.fire({
            icon: 'success',
            title: 'Mail sent successfully Please check your Email',
            confirmButtonText:'Ok'
           
          });
        
          this.newRegister.name="";
          this.newRegister.address="";
          this.newRegister.email="";

       
        },
        (error)=>{
         debugger
          console.log(error);
          Swal.close();
          this.isLoading= true;
          this.message='Email already exist'

        }
      )
    
  }

  
  
    
  
  

}
