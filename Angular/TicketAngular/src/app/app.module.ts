import { JwtTokenService } from './Services/jwt-token.service';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './Components/home/home.component';
import { TicketComponent } from './Components/ticket/ticket.component';
import { RegisterComponent } from './Components/register/register.component';
import { LoginComponent } from './Components/login/login.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule,HTTP_INTERCEPTORS } from '@angular/common/http';
import { BookingComponent } from './Components/booking/booking.component';
import { JwtModule } from '@auth0/angular-jwt';
import { CartComponent } from './Components/cart/cart.component';
import { PasswordComponent } from './Components/password/password.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';





@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    TicketComponent,
    RegisterComponent,
    LoginComponent,
    BookingComponent,
    CartComponent,
    PasswordComponent,
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    FormsModule,
    MatProgressSpinnerModule,
    MatInputModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatIconModule,
    JwtModule.forRoot({
      config:{
        tokenGetter:()=>{
return sessionStorage.getItem("CurrentUser")? JSON.parse(sessionStorage.getItem("CurrentUser") as string).token:null
        }
      }
    }),
    BrowserAnimationsModule
  ],
  providers: [
    {
      provide:HTTP_INTERCEPTORS,
      useClass:JwtTokenService,
      multi:true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
