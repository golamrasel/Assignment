import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Branch } from 'src/app/model/branch';
import { UrlDataService } from 'src/app/services/url-service';
import { WebApiService } from 'src/app/services/web-api.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-branch-edit',
  templateUrl: './branch-edit.component.html',
  styleUrls: ['./branch-edit.component.css']
})
export class BranchEditComponent implements OnInit {
  branchForm!: FormGroup;
  model!: Branch;

  constructor(
    private fb: FormBuilder,
    public service: WebApiService,
    public toastr: ToastrService,
    public route: ActivatedRoute,
    private _location: Location,
    private SpinnerService: NgxSpinnerService
  ) { }

  ngOnInit(): void {
    this.branchForm = this.fb.group({
      id: new FormControl('',Validators.required),
      branchName: new FormControl('',Validators.required),
      password: new FormControl('',Validators.required),
      mac: new FormControl('',Validators.required)
    })
    if(this.route.snapshot.params.id>0)
      this.getBranchById(this.route.snapshot.params.id) ;
  }

  getBranchById(id:number) {
    this.service.get(UrlDataService.detailsBranch,id).subscribe(response => {
      console.log(response);
     this.branchForm.setValue(response.result)
    }, error => {
       console.log(error);
    });
  }

  backClicked(){
    this._location.back();
  }

  UpdateBranch() {
    this.SpinnerService.show(); 
    this.model = Object.assign({}, this.branchForm.value);
    this.service.update(UrlDataService.updateBranch,this.model).subscribe(
    () => {
      this.toastr.success("Update Successfully!!");
      this.branchForm.reset();
      this._location.back();
      this.SpinnerService.hide(); 
    }, error => {
       console.log(error);
    });
  }
}
