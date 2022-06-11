import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-carinfo',
  templateUrl: './carinfo.component.html',
  styleUrls: ['./carinfo.component.css']
})
export class CarinfoComponent implements OnInit {


  //משתנה שהערך שלו נקבע לפי לחיצת כפתור, הוא משפיע על הפונקציה תוצג ותיתן את האופציה לפעולה שנבחרה
  chooseAction;

  //משתנים להוספה ועריכת רכב
  carId;
  carType;
  km;
  pic;
  rentable;
  available;
  carNum;
  postReturn: any;
  putReturn: any;


  //משתנים להשגת מידע מסוים או מחיקה
  getbyCarNumReturn: any;
  getallCarTypesReturn: any;
  deleteReturn: any;

  constructor(private http: HttpClient) { }


  //פונקציה שאחראית על תצוגת הפעולה שבחר המנהל, מקבלת ערך ע"י לחיצת כפתור
  fun1(Action) { this.chooseAction = Action; }

  //השגת רכב לפי מספר רכב
  GetCarbyCarNum(CarNum) {
    this.http.get("https://localhost:44384/ManagerPage/GetCarsByNumber/" + CarNum).subscribe(
      g => {
        this.getbyCarNumReturn = g
      },
      err => {
        alert("car not found")
      })
  }

  //השגת כל הרכבים
  GetallCars() {
    this.http.get("https://localhost:44384/ManagerPage/GetAllCars").subscribe(
      t => this.getallCarTypesReturn = t)
  }

  //הוספת מידע על רכב
  PostCarInfo() {
    this.http.post("https://localhost:44384/ManagerPage/PostCarInfoTable", {
      "CarId": this.carId, "CarType": this.carType, "Km": this.km, "Pic": this.pic,
      "Rentable": this.rentable, "Available": this.available, "CarNum": this.carNum
    }).subscribe(
      t => {
        this.postReturn = t
        alert("post success");
      },
      err => {
        alert("post failed, make sure there is a cartype of the car you want to post" + err)
      })
  }

  //עריכת מידע על רכב
  PutCarInfo(CarNum) {
    this.http.put("https://localhost:44384/ManagerPage/UpdateCarsInfo/" + CarNum, {
      "CarId": this.carId, "CarType": this.carType, "Km": this.km, "Pic": this.pic,
      "Rentable": this.rentable, "Available": this.available, "CarNum": this.carNum
    }).subscribe(
      t => {
        this.putReturn = t
        alert("put success");
      }, err => {
        alert("put failed" + err)
      })
  }

  //מחיקת מידע על רכב
  DeleteCarInfo(CarNum) {
    this.http.delete("https://localhost:44384/ManagerPage/DeleteCarInfo/" + CarNum)
      .subscribe(
        g => {
          this.deleteReturn = g
          alert("delete success");
        }, err => {
          alert("delete failed" + err)
        })
  }



  ngOnInit(): void {
  }

}
