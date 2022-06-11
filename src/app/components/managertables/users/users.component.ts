import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {


  //משתנה שהערך שלו נקבע לפי לחיצת כפתור, הוא משפיע על הפונקציה תוצג ותיתן את האופציה לפעולה שנבחרה
  chooseAction;


  //משתנים להוספה ועריכת משתמש
  fullname;
  tz;
  nickname;
  dob;
  gender;
  email;
  password;
  img;
  role;
  postReturn: any;
  putReturn: any;


  //משתנים להשגת מידע מסוים או מחיקה
  getbytzReturn: any;
  getallusersReturn: any;
  deleteReturn: any;


  constructor(private http: HttpClient) { }

  //פונקציה שאחראית על תצוגת הפעולה שבחר המנהל, מקבלת ערך ע"י לחיצת כפתור
  fun1(Action) { this.chooseAction = Action; }

  //השגת משתמש לפי מספר תז
  GetUserbytz(userTZ) {
    this.http.get("https://localhost:44384/ManagerPage/GetUserByTz/" + userTZ)
      .subscribe(
        g => {
          this.getbytzReturn = g
        }, err => {
          alert("user not found" + err)
        })

  }

  //השגת כל המשתמשים
  Getallusers() {
    this.http.get("https://localhost:44384/ManagerPage/GetAllUsers").subscribe(t => this.getallusersReturn = t)
  }

  //הוספת משתמש
  PostUser() {
    this.http.post("https://localhost:44384/ManagerPage/PostNewUser",
      {
        "Fullname": this.fullname, "UserTz": this.tz, "NickName": this.nickname,
        "Bday": this.dob, "Gender": this.gender, "Email": this.email
        , "Password": this.password, "Picture": this.img, "Role": this.role
      })
      .subscribe(t => {
        this.postReturn = t
        alert("post success");
      },
        err => {
          alert("post failed, try with a different tz or a different nickname" + err)
        })
  }

  //עריכת משתמש
  PutUser(PutTz) {
    this.http.put("https://localhost:44384/ManagerPage/UpdateUserInfo/" + PutTz, {
      "FullName": this.fullname, "UserTz": this.tz, "NickName": this.nickname,
      "Bday": this.dob, "Gender": this.gender, "Email": this.email
      , "Password": this.password, "Picture": this.img, "Role": this.role
    })
      .subscribe(t => {
        this.putReturn = t
        alert("put success");
      }, err => {
        alert("put failed" + err)
      })
  }

  //מחיקת משתמש
  deleteUser(DeleteTz) {
    this.http.delete("https://localhost:44384/ManagerPage/DeleteUser/" + DeleteTz)
      .subscribe(g => {
        this.deleteReturn = g
        alert("delete success");
      }, err => {
        alert("delete failed, make sure there are no orders on the user you want to delete" + err)
      })
  }



  //פונקציה שלא בשימוש
  // getimg() {
  //   this.getImageByid(this.tz).subscribe(res => {
  //     this.img = 'data:img/jpeg;base64,' + res;
  //   });
  // }

  // getImageByid(Id): Observable<any> {
  //   if (!Id) {
  //     return of("");
  //   }
  //   let queryParams = new HttpParams();
  //   queryParams = queryParams.append('Id', encodeURIComponent(Id));
  //   return this.http.get<any>('https://localhost:44384/UserCarPage/get-image', { params: queryParams, responseType: 'text' as 'json' });
  // }


  ngOnInit(): void {
  }

}
