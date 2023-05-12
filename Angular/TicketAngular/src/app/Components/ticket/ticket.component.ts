
import { Component } from '@angular/core';
import { Ticket } from 'src/app/Classes/ticket';
import { TicketService } from 'src/app/Services/ticket.service';

import Swal from 'sweetalert2';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',

  styleUrls: ['./ticket.component.scss']
})
export class TicketComponent {

  ticketlist: Ticket[]=[];
  NewTicket:Ticket= new Ticket();
  EditTicket:Ticket= new Ticket();
  url:any;
  
 
  constructor(private Ticketservice : TicketService){}

  ngOnInit(): void {
   
    
    this.getALL();
  }
  

  onselected(event: any): void {
  const file: File = event.target.files[0];
  const reader = new FileReader();
  reader.readAsDataURL(file);
  reader.onload = (event:any) => {
    this.url=event.target.result;
    const base64String: string = reader.result as string;
    this.NewTicket.image= base64String
    this.EditTicket.image=base64String
    
    
  };
}


  getALL()
  {
    

    this.Ticketservice.GetEmployes().subscribe(
      (respnse)=>{
        this.ticketlist=respnse;
       
       
      },
      (error)=>{
        console.log(error);
      }
    )
  }
  
  Save()
  {
    
    this.Ticketservice.saveEmployes(this.NewTicket). subscribe(
      (response)=>{

        Swal.fire({
          icon: 'success',
          title: 'Data saved successfully',
          showConfirmButton: false,
          timer: 1500
        });
        this .getALL();
        this.NewTicket.name="";
       
        this.NewTicket.image="";
      },
      (error)=>{
        console.log(error)
      }
    )
    
  }

  EditClick(employe:Ticket){
    this.EditTicket=employe
    
  }

  Update()
  {
    this.Ticketservice.updateemploye(this.EditTicket).subscribe(
      (response)=>{
        Swal.fire({
          icon: 'success',
          title: 'Data Updated successfully',
          showConfirmButton: false,
          timer: 1500
        });
        this.getALL();
      },
      
      (error)=>{
        console.log(error);
      }
    )
  }


DeleteClick(id:Number)
{  

  Swal.fire({  
    title: 'Are you sure want to remove?',  
    text: 'You will not be able to recover this file!',  
    icon: 'warning',  
    showCancelButton: true,  
    confirmButtonText: 'Yes, delete it!',  
    cancelButtonText: 'No, keep it'  
  }).then((result) => {  
    if (result.value)
    {
      this.Ticketservice.Delete(id).subscribe(
        (response)=>{
          this.getALL();
        })

      Swal.fire(  
        'Deleted!',  
        'Your imaginary file has been deleted.',  
        'success'  
      )  
    } else if (result.dismiss === Swal.DismissReason.cancel) {  
      Swal.fire(  
        'Cancelled',  
        'Your imaginary file is safe :)',  
        'error'  
      )  
    }  
  })  
}  

}
