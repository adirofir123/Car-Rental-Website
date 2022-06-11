import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  //משתנים להתחברות
  nickname;
  password;
  UserLogin: any;

  //שימוש בבנאי לגישה ישירה לסרוויס אוטנטיקשיון כדי לבדוק את הרול של האדם שהתחבר ולקבל משתנים של תז איידי
  constructor(private http: HttpClient, private authService: AuthService) { }


  //פונקציה להתחברות
  Login() {
    this.http.get("https://localhost:44384/UserCarPage/Login/" + this.nickname + '/' + this.password).subscribe(
      g => {
        this.UserLogin = g;
        this.authService.userauth(this.UserLogin)
        this.authService.usertz = this.UserLogin.userTz;
        this.authService.userid = this.UserLogin.userId;
        alert("Login Success")
      }, Fail => {
        alert("Login has Failed, you are being transferred to home page");
      });

  }


  ngOnInit(): void {
  }

}
