import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { TopbarComponent } from './topbar/topbar.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthGuard } from './auth/auth.guard';
import { AuthService } from './auth/auth.service';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { WebService } from './services/web.service';
import { HttpClientModule } from '@angular/common/http';
import { StudentCreateComponent } from './students/student-create/student-create.component';
import { StudentListComponent } from './students/student-list/student-list.component';
import { StudentService } from './services/student.service';
import { NgxPaginationModule } from 'ngx-pagination';
import { StudentEditComponent } from './students/student-edit/student-edit.component';
import { CommonModule } from '@angular/common';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BranchCreateComponent } from './branches/branch-create/branch-create.component';
import { BranchListComponent } from './branches/branch-list/branch-list.component';
import { BranchEditComponent } from './branches/branch-edit/branch-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    TopbarComponent,
    DashboardComponent,
    LoginComponent,
    StudentCreateComponent,
    StudentListComponent,
    StudentEditComponent,
    BranchCreateComponent,
    BranchListComponent,
    BranchEditComponent,
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    NgxPaginationModule,
    CommonModule,
    ReactiveFormsModule,
    Ng2SearchPipeModule,
    NgxDatatableModule,
    NgxSpinnerModule
  ],
  providers: [AuthService, AuthGuard, WebService,StudentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
