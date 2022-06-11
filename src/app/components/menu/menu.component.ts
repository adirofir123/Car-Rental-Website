import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  constructor(public RoleAuth: AuthService) { }

  //פונקציה להתנתקות
  Logout() {
    let logout = confirm("are you sure?")
    if (logout == true) {
      location.replace("home");
    }
  }

  ngOnInit(): void {
  }

}
