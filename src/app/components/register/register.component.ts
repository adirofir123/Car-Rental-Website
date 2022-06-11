import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {


  //משתנים להרשמת משתמש
  fullname;
  tz;
  nickname;
  dob;
  gender;
  email;
  password;
  img;
  file: any;
  registerreturn;

  constructor(public http: HttpClient) { }


  //פונקציה להרשמת משתמש, רול מובנה ליוזר, מקבלת פייל שאותו שולחים עם פונקציה נוספת להעלת תמונה
  register(file) {
    this.file = file;
    this.http.post('https://localhost:44384/UserCarPage/register', {
      "Fullname": this.fullname, "UserTz": this.tz, "NickName": this.nickname,
      "Bday": this.dob, "Gender": this.gender, "Email": this.email
      , "Password": this.password, "Picture": this.img, "Role": "user"
    }).subscribe(r => {
      if (r == true) {
        alert("register success" + r);
      }
      else if (r == false) {
        alert("register falied, try with a different tz or a different nickname" + r);
      }
      else {
        alert("register falied, try with a different tz or a different nickname"+ r);
      }
      //פונקציה להעלת תמונה
      let fileToUpload = <File>this.file[0];
      const formData = new FormData();
      formData.append('file', fileToUpload, fileToUpload.name);
      this.http.post<any>('https://localhost:44384/UserCarPage/upload-image/' + this.nickname, formData)
        .subscribe(res => {
          console.log("response ", res);
        })
    })

  }


    //פונקציה להעלת קובץ, לא בשימוש
  // uploadFile(files) {
  //   let fileToUpload = <File>files[0];
  //   const formData = new FormData();
  //   formData.append('file', fileToUpload, fileToUpload.name);
  //   this.http.post<any>('https://localhost:44384/UserCarPage/upload-image/' + this.fullname, formData)
  //     .subscribe(res => {
  //       console.log("res ", res);
  //     })
  // }



  ngOnInit(): void {
  }

}
