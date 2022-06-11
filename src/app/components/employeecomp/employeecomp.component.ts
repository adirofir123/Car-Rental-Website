import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employeecomp',
  templateUrl: './employeecomp.component.html',
  styleUrls: ['./employeecomp.component.css']
})
export class EmployeecompComponent implements OnInit {

  //משתנים לחישוב פער התאריכים
  firstDate;
  lastDate;
  FirstDate2;
  LastDate2;
  diff;


  //משתנים להשגת עלות יום איחור לפי הרכב המבוקש
  continue;
  getpricereturn;


  //משתנים לחישוב עלות האיחור
  continue2;
  carNum;
  finalPrice;



  //משתנים להחזרת הרכב והזנת תאריך החזרה אמיתי
  putReturn: any;
  rRD;

  constructor(private http: HttpClient) { }


  //פונקציה לההזנת תאריך החזרה אמיתי של הרכב והחזרת הרכב לפנוי
  PutRRD(ordernum) {
    this.http.put("https://localhost:44384/EmployeePage/EmployeeReturnCar/" + ordernum, { "RealReturnDate": this.rRD }).subscribe(
      t => {
        this.putReturn = t
        alert("Car Returned");
      },
      err => {
        alert("Returning car has Failed, make sure the carnum is correct" + err);
      });


  }

  //פונקציה לחישוב עלות איחור,בחירת תאריך ואז המשך לבחירת רכב
  calculateDiff() {
    this.FirstDate2 = new Date(this.firstDate).getTime();
    this.LastDate2 = new Date(this.lastDate).getTime();
    this.diff = (this.LastDate2 - this.FirstDate2) / 86400000;
    this.continue = "choose car";
  }

  //בחירת רכב למציאת עלות יום איחור
  GetCarPrice(CarNum) {
    this.http.get("https://localhost:44384/EmployeePage/GetCarByNumber/" + CarNum)
      .subscribe(
        g => {
          this.getpricereturn = g
        },
        err => {
          alert("car not found")
        })



    this.continue2 = "price";
  }

  //חישוב העלות הסופית
  FinalPrice() {
    this.finalPrice = this.diff * this.getpricereturn[0].delayPrice;
  }


  ngOnInit(): void {
  }

}
