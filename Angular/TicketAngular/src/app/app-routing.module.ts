import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { TicketComponent } from './Components/ticket/ticket.component';
import { BookingComponent } from './Components/booking/booking.component';
import { JwtActiveGuardService } from './Services/jwt-active-guard.service';
import { RoleguardService } from './Services/roleguard.service';
import { CartComponent } from './Components/cart/cart.component';
import { PasswordComponent } from './Components/password/password.component';

const routes: Routes = [

  {path:"",redirectTo:"home",pathMatch:"full"},
  {path:"home",component:HomeComponent},
  {path:"password",component:PasswordComponent},
  {path:"ticket",component:TicketComponent,canActivate:[JwtActiveGuardService, RoleguardService], data: { role: "Admin"}},
  {path:"login",component:LoginComponent},
  {path:"booking",component:BookingComponent,canActivate:[JwtActiveGuardService,RoleguardService], 
  data: { role: "Admin"},
  
},

  {path:"register",component:RegisterComponent},
  {path:"cart",component:CartComponent,canActivate:[JwtActiveGuardService]},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

  
 }
