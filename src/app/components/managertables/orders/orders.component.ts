import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  //משתנה שהערך שלו נקבע לפי לחיצת כפתור, הוא משפיע על הפונקציה תוצג ותיתן את האופציה לפעולה שנבחרה
  chooseAction;

  //משתנים להוספה ועריכת הזמנה
  userId;
  startDate;
  returnDate;
  realReturnDate;
  carNum;
  orderNum;
  postReturn: any;
  putReturn: any;


  //משתנים להשגת מידע מסוים או מחיקה
  getbyOrderNumReturn: any;
  getallOrdersReturn: any;
  deleteReturn: any;

  constructor(private http: HttpClient) { }

  //פונקציה שאחראית על תצוגת הפעולה שבחר המנהל, מקבלת ערך ע"י לחיצת כפתור
  fun1(Action) { this.chooseAction = Action; }


  //השגת הזמנה לפי מספר הזמנה
  GetOrderByID(OrderNum) {
    this.http.get("https://localhost:44384/ManagerPage/GetOrderById/" + OrderNum)
      .subscribe(
        g => {
          this.getbyOrderNumReturn = g
        }, err => {
          alert("order not found" + err)
        })

  }

  //השגת כל ההזמנות
  Getallorders() {
    this.http.get("https://localhost:44384/ManagerPage/GetAllOrders").subscribe(t => this.getallOrdersReturn = t)
  }
 
  //הוספת הזמנה
  PostOrder() {
    this.http.post("https://localhost:44384/ManagerPage/PostUserOrder",
      {
        "UserId": this.userId, "StartRentDate": this.startDate, "ReturnDate": this.returnDate, "RealReturnDate": this.realReturnDate,
        "CarNum": this.carNum
      })
      .subscribe(t => {
        this.postReturn = t
        alert("post success");
      },
        err => {
          alert("post failed" + err)
        })
  }

  //עריכת הזמנה
  PutOrder(OrderNum) {
    this.http.put("https://localhost:44384/ManagerPage/UpdateOrder/" + OrderNum, {
      "UserId": this.userId, "StartRentDate": this.startDate, "ReturnDate": this.returnDate, "RealReturnDate": this.realReturnDate,
      "CarNum": this.carNum
    })
      .subscribe(
        t => {
          this.putReturn = t
          alert("put success");
        }, err => {
          alert("put failed" + err)
        })
  }

  //מחיקת הזמנה
  deleteOrder(OrderNum) {
    this.http.delete("https://localhost:44384/ManagerPage/DeleteOrder/" + OrderNum)
      .subscribe(g => {
        this.deleteReturn = g
        alert("delete success");
      }, err => {
        alert("delete failed" + err)
      })
  }



  ngOnInit(): void {
  }

}
