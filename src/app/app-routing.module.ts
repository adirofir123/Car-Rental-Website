import { registerLocaleData } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './components/about/about.component';
import { CarsComponent } from './components/cars/cars.component';
import { EmployeecompComponent } from './components/employeecomp/employeecomp.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { ManagercompComponent } from './components/managercomp/managercomp.component';
import { CarinfoComponent } from './components/managertables/carinfo/carinfo.component';
import { CartypeComponent } from './components/managertables/cartype/cartype.component';
import { OrdersComponent } from './components/managertables/orders/orders.component';
import { UsersComponent } from './components/managertables/users/users.component';
import { RegisterComponent } from './components/register/register.component';

const routes: Routes = [
  {path:"home",component:HomeComponent},
  {path:"cars",component:CarsComponent},
  {path:"register",component:RegisterComponent},
  {path:"about",component:AboutComponent},
  {path:"login",component:LoginComponent},
  {path:"managercomp",component:ManagercompComponent,children:[//הגדרת ילדים שיוצגו בקומפוננטת המנהל
    {path:"carinfo",component:CarinfoComponent},
    {path:"cartype",component:CartypeComponent},
    {path:"orders",component:OrdersComponent},
    {path:"users",component:UsersComponent}
  ]}, 
  {path:"employeecomp",component:EmployeecompComponent},
  {path:"",redirectTo:"/home",pathMatch:"full"},
  {path:"**",redirectTo:"/home",pathMatch:"full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
