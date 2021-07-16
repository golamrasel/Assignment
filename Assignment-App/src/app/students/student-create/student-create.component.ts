import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Student } from 'src/app/model/student';
import { UrlDataService } from 'src/app/services/url-service';
import { WebApiService } from 'src/app/services/web-api.service';
import { Location } from '@angular/common';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-student-create',
  templateUrl: './student-create.component.html',
  styleUrls: ['./student-create.component.css']
})
export class StudentCreateComponent implements OnInit {

  model!: Student;
  constructor(
    public service: WebApiService,
    private toastr: ToastrService,
    private _location: Location,
    private SpinnerService: NgxSpinnerService

  ) { }

  ngOnInit(): void {
    this.model = new Student();
  }
   
  backClicked(){
    this._location.back();
  }

  save(){
    this.SpinnerService.show(); 
    this.service.saveStudent(UrlDataService.saveStudent, this.model).subscribe((response: any)=>{
      this.toastr.success(response.result.result)
      this.model = {
        studentId: 0,
        studentName: '',
        roll: 0,
        class: ''
      }
      this.SpinnerService.hide(); 
    })
  }
}


