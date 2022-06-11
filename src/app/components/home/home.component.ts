import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  manufacturerfilter;// סינון מפעל ייצור
  modelfilter;//סינון מודל
  yearfilter;//סינון שנה


  //משתנים לשימוש ברכבים שאהבתי (בעזרת לוקאל סטורג')
  carPrice;
  favorites: any = [];
  favoritesDisplayed = false
  ShowCar;


  //משתנים לחישוב עלות ההשכרה
  firstDate;
  lastDate;
  FirstDate2;
  LastDate2;
  diff;
  continue;
  getpricereturn;
  continue2;
  finalPrice;



  //שימוש בבנאי להצגה ישירה של הרכבים בחברה
  constructor(private http: HttpClient) {
    this.http.get("https://localhost:44384/UserCarPage/GetAllCars").subscribe(t => this.ShowCar = t)
  }


  //הצגת הרכבים שאהבתי (לוקאל סטורג')
  onClickFav() {
    this.favoritesDisplayed = !this.favoritesDisplayed
    if (!this.favoritesDisplayed) {
      this.favorites = []
      return
    }
    this.favorites = JSON.parse(localStorage.getItem("Cars"))
  }


  //הכנסת הרכבים שהמשתמש לחץ עליהם לרכבים שאהבתי (לוקאל סטורג')
  getinfoforLC(info) {
    var cars = [];
    if (localStorage.getItem("Cars")) {
      cars = JSON.parse(localStorage.getItem("Cars"));
      cars = [info, ...cars];
    } else {
      cars = [info];
    }
    localStorage.setItem("Cars", JSON.stringify(cars));
  }


  //פונקציה לחישוב עלות הזמנה,בחירת תאריך ואז המשך לבחירת רכב
  calculateDiff() {
    this.FirstDate2 = new Date(this.firstDate).getTime();
    this.LastDate2 = new Date(this.lastDate).getTime();
    this.diff = (this.LastDate2 - this.FirstDate2) / 86400000;
    this.continue = "choose car";
  }


  //בחירת רכב למציאת עלות ליום 
  GetCarPrice(CarNum) {
    this.http.get("https://localhost:44384/UserCarPage/GetCarsByNumber/" + CarNum)
      .subscribe(
        g => {
          this.getpricereturn = g
        },
        err => {
          alert("car not found, choose a carnum from the list above")
        })
    this.continue2 = "price";
  }


  //חישוב העלות הסופית
  FinalPrice() {
    this.finalPrice = this.diff * this.getpricereturn[0].dayPrice;
  }




  ngOnInit(): void {
  }

}
