import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Student } from 'src/app/model/student';
import { UrlDataService } from 'src/app/services/url-service';
import { WebApiService } from 'src/app/services/web-api.service';
import { Location } from '@angular/common';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-student-edit',
  templateUrl: './student-edit.component.html',
  styleUrls: ['./student-edit.component.css']
})
export class StudentEditComponent implements OnInit {
  studentForm!: FormGroup;
  model!: Student;

  constructor(
    private fb: FormBuilder,
    public service: WebApiService,
    public toastr: ToastrService,
    public route: ActivatedRoute,
    private _location: Location,
    private SpinnerService: NgxSpinnerService
  ) { }

  ngOnInit(): void {
    this.studentForm = this.fb.group({
      studentId: new FormControl('',Validators.required),
      studentName: new FormControl('',Validators.required),
      roll: new FormControl('',Validators.required),
      class: new FormControl('',Validators.required)
    })
    if(this.route.snapshot.params.id>0)
      this.getstudentById(this.route.snapshot.params.id) ;
  }

  getstudentById(id:number) {
    this.service.studentEdit(UrlDataService.detailsStudent,id).subscribe(response => {
      console.log(response);
     this.studentForm.setValue(response.result)
    }, error => {
       console.log(error);
    });
  }

  backClicked(){
    this._location.back();
  }

  UpdateStudent() {
    this.SpinnerService.show(); 
    this.model = Object.assign({}, this.studentForm.value);
    this.service.updateStudent(UrlDataService.updateStudent,this.model).subscribe(
    () => {
      this.toastr.success("Update Successfully!!");
      this.studentForm.reset();
      this._location.back();
      this.SpinnerService.hide(); 
    }, error => {
       console.log(error);
    });
  }
}
