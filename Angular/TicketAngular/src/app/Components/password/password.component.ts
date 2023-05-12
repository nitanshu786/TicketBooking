import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Register } from 'src/app/Classes/register';
import { RegisterService } from 'src/app/Services/register.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-password',
  templateUrl: './password.component.html',
  styleUrls: ['./password.component.scss']
})
export class PasswordComponent implements OnInit {
  newRegister:Register= new Register();
   id :any;
  match:boolean=false;
// passwordForm!: FormGroup
   passwordForm = new FormGroup({
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
    confirm: new FormControl('', [Validators.required, Validators.minLength(8)])
  });  
get password(){return this.passwordForm.get('password')}
get confirm(){return this.passwordForm.get('confirm')}

  constructor(private registerservice:RegisterService, private router:Router,private route: ActivatedRoute,private fb: FormBuilder){}
  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this. id = params['id'];
     this.newRegister.id= this.id as Number;
     console.log(this.newRegister)
    });
  }

  passwordsMatch(): boolean {
    const password = this.passwordForm.get('password')?.value;
    const confirm = this.passwordForm.get('confirm')?.value;
    return password === confirm;
  }
  regClick()
    {
      this.registerservice.checkUser(this.newRegister).subscribe(
        (response)=>{
          Swal.fire({
            icon: 'success',
            title: 'Register successfully Please login',
            confirmButtonText:'Ok'
           
          });
         this.newRegister.password=""
          this.router.navigateByUrl("/login");
        },
        (error)=>{
          console.log(error);
          alert("Wrong UserName & Passward");
        }
      
      )
    }
    
  }

