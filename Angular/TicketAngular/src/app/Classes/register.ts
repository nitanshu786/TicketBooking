import { DatePipe } from "@angular/common";

export class Register {

    id:Number;
    name:string;
    address:string;
    email:string;
    password:string;
    confirmpassword:string;

    constructor(){
        this.id=0;
        this.name="";
        this.email="";
        this.address="";
        this.password="";
        this.confirmpassword="";
      
        
       

    }
}
