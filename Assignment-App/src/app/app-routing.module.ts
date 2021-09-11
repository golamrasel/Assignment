import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { BranchCreateComponent } from './branches/branch-create/branch-create.component';
import { BranchEditComponent } from './branches/branch-edit/branch-edit.component';
import { BranchListComponent } from './branches/branch-list/branch-list.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { StudentCreateComponent } from './students/student-create/student-create.component';
import { StudentEditComponent } from './students/student-edit/student-edit.component';
import { StudentListComponent } from './students/student-list/student-list.component';

const routes: Routes = [
  
{ path: '', component: DashboardComponent, canActivate: [AuthGuard] },
{ path: 'login', component: LoginComponent },
// { path: '**', redirectTo: ''},
{ path: 'student-create', component: StudentCreateComponent, canActivate: [AuthGuard] },
{ path: 'student-list', component: StudentListComponent, canActivate: [AuthGuard]},
{ path: 'student-edit/:id', component: StudentEditComponent, canActivate: [AuthGuard] },
{ path: 'branch-create', component: BranchCreateComponent, canActivate: [AuthGuard] },
{ path: 'branch-list', component: BranchListComponent, canActivate: [AuthGuard] },
{ path: 'branch-edit/:id', component: BranchEditComponent, canActivate: [AuthGuard] },

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
