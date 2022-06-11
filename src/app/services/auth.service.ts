import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  //משתנים לבדיקת רול ולבדיקה האם משתמש התחבר למערכת
  ishost = false;
  isemployee = false;
  isuser = false;
  notsigned = true;

  //משתנים לשימוש בהזמנת רכב, הצגת פרופיל המשתמש, והצגת הזמנות קודמות
  usertz;
  userid;

  constructor() { }

  //בדיקה האם התחבר משתמש
  userauth(role: any): boolean {
    if (role.role == "user") {
      this.isuser = true;
      this.notsigned = false;
      return true;
    }
    this.employeeauth(role)
  }


  //בדיקה האם התחבר עובד 
  employeeauth(role: any): boolean {
    if (role.role == "employee") {
      this.isemployee = true;
      this.notsigned = false;
      return true;
    }
    this.hostauth(role);
  }


  //בדיקה האם התחבר מנהל 
  hostauth(role: any): boolean {
    if (role.role == "host") {
      this.ishost = true;
      this.notsigned = false;
      return true;
    }
    return false;

  }


}
