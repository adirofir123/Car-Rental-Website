import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { LayoutComponent } from './components/layout/layout.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { MenuComponent } from './components/menu/menu.component';
import { HomeComponent } from './components/home/home.component';
import { CarsComponent } from './components/cars/cars.component';
import { AboutComponent } from './components/about/about.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { ManagercompComponent } from './components/managercomp/managercomp.component';
import { CarinfoComponent } from './components/managertables/carinfo/carinfo.component';
import { CartypeComponent } from './components/managertables/cartype/cartype.component';
import { UsersComponent } from './components/managertables/users/users.component';
import { OrdersComponent } from './components/managertables/orders/orders.component';
import { EmployeecompComponent } from './components/employeecomp/employeecomp.component';
import { SearchcarPipe } from './Pipes/searchcar.pipe';
import { SearchcarbyYearPipe } from './Pipes/searchcarby-year.pipe';
import { SearchcarbyModelPipe } from './Pipes/searchcarby-model.pipe';

@NgModule({
  declarations: [      
LayoutComponent,
HeaderComponent,
FooterComponent,
MenuComponent,
HomeComponent,
CarsComponent,
AboutComponent,
RegisterComponent,
LoginComponent,
ManagercompComponent,
CarinfoComponent,
CartypeComponent,
UsersComponent,
OrdersComponent,
EmployeecompComponent,
SearchcarPipe,
SearchcarbyYearPipe,
SearchcarbyModelPipe,
],
imports: [BrowserModule,AppRoutingModule,HttpClientModule,FormsModule,ReactiveFormsModule],
providers: [],
bootstrap: [LayoutComponent]
})
export class AppModule { }
