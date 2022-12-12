import { ShowEmployeeComponent } from './employee/show-employee/show-employee.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { DefaultComponent } from './layouts/default/default.component';
import { AddEditEmployeeComponent } from './employee/add-edit-employee/add-edit-employee.component';
import { DashboardComponent } from './module/dashboard/dashboard.component';
import { EmployeeComponent } from './employee/employee.component';
import { AuthGuard } from './_helper/auth.guard';

const routes: Routes = [
  { path:"register" , component:RegisterComponent },
  { path:"login" , component:LoginComponent },
  {
    path:'',
    canActivate : [AuthGuard],
    component:DefaultComponent,
    children:[{
      path:'',
      component:DashboardComponent
    },
    {
      path : 'employee',
      canActivate: [AuthGuard],
      component : EmployeeComponent
    },
    {
      path : 'add-edit-employee',
      canActivate: [AuthGuard],
      component : AddEditEmployeeComponent
    },  
    // {
    //   path : 'edit-employee/:id',
    //   canActivate: [AuthGuard],
    //   component : EditEmployeeComponent
    // },        
  ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
