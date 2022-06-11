import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {

  //משתנים להזמנת הרכב
  startDate
  returnDate
  carNum
  userpostreturn;


  //משתנים להצגת פרטי המשתמש
  fullname;
  tz;
  nickname;
  dob;
  gender;
  email;
  password;
  img;
  getbytzReturn;


  //משתנים להצגת הזמנות המשתמש
  orders;
  getmyordersreturn;


  //שימוש בבנאי לגישה ישירה לזיהוי פרטי המשתמש 
  constructor(private http: HttpClient, public Auth: AuthService) { }


  //פונקציה להזמנת רכב עם יוזר איידיי מובנה
  PostOrder() {
    this.http.post("https://localhost:44384/UserCarPage/NewUserOrder",
      {
        "UserId": this.Auth.userid, "StartRentDate": this.startDate, "ReturnDate": this.returnDate,
        "CarNum": this.carNum
      })
      .subscribe(
        t => {
          this.userpostreturn = t
          alert("order success");
        },
        err => {
          alert("order failed, make sure the car you choose is available"+err);
        })

  }


  //פונקציה להשגת הפרופיל של היוזר המחובר
  GetUserbytz() {
    this.http.get("https://localhost:44384/ManagerPage/GetUserByTz/" + this.Auth.usertz)
      .subscribe(g => this.getbytzReturn = g)

  }


  //פונקציה להשגת הכל ההזמנות של היוזר המחובר
  GetMyOrders() {
    this.http.get("https://localhost:44384/UserCarPage/ShowUserOrder/" + this.Auth.userid)
      .subscribe(g => this.getmyordersreturn = g)
  }


  ngOnInit(): void {
  }

}
