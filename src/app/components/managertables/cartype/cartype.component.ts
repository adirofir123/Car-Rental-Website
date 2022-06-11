import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cartype',
  templateUrl: './cartype.component.html',
  styleUrls: ['./cartype.component.css']
})
export class CartypeComponent implements OnInit {


  //משתנה שהערך שלו נקבע לפי לחיצת כפתור, הוא משפיע על הפונקציה תוצג ותיתן את האופציה לפעולה שנבחרה
  chooseAction;


  //משתנים להוספה ועריכת רכב
  carId;
  quantity;
  manufacturer;
  model;
  dprice;
  delayPrice;
  year;
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
    this.http.get("https://localhost:44384/ManagerPage/GetAllCars").subscribe(t => this.getallCarTypesReturn = t)
  }

  //הוספת סוג רכב
  PostCarType() {
    this.http.post("https://localhost:44384/ManagerPage/PostCarTypeTable", {
      "Quantity": this.quantity, "Manufactor": this.manufacturer, "Model": this.model,
      "Dprice": this.dprice, "DelayPrice": this.delayPrice, "Year": this.year
    }).subscribe(
      t => {
        this.postReturn = t
        alert("post success");
      },
      err => {
        alert("post failed" + err)
      })
  }

  //עריכת סוג רכב
  PutCarType(CarID) {
    this.http.put("https://localhost:44384/ManagerPage/UpdateCarsType/" + CarID, {
      "CarId": this.carId, "Quantity": this.quantity, "Manufactor": this.manufacturer, "Model": this.model,
      "Dprice": this.dprice, "DelayPrice": this.delayPrice, "Year": this.year
    }).subscribe(
      t => {
        this.putReturn = t
        alert("put success");
      }, err => {
        alert("put failed" + err)
      })
  }

  //מחיקת סוג רכב
  DeleteCarType(CarID) {
    this.http.delete("https://localhost:44384/ManagerPage/DeleteCarType/" + CarID)
      .subscribe(
        g => {
          this.deleteReturn = g
          alert("delete success");
        }, err => {
          alert("delete failed, make sure there are no cars of the cartype you want to delete" + err)
        })
  }



  ngOnInit(): void {
  }

}
