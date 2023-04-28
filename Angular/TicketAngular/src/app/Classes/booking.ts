export class Booking {
    id:number;
    userId:number;
    userTable :any;
    ticketId:number;
    ticketTable:any;
    count:number;

    constructor(){
        this.id=0,
        this.userId=0,
        this.userTable=null;
        this.ticketId=0,
        this.ticketTable=null;
        this.count=0;
    }
}
