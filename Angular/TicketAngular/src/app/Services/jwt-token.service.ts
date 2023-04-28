import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class JwtTokenService {

  constructor() { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var curentuser={token:""};
    var currentsession= sessionStorage.getItem("CurrentUser");
    if(currentsession!=null)
    {
      curentuser= JSON.parse(currentsession);
    }
    req=req.clone({
      setHeaders:{
        Authorization:"Bearer "+curentuser.token
      }
    })
    return next.handle(req)
  }
}
