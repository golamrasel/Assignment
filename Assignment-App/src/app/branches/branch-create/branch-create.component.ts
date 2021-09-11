import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Branch } from 'src/app/model/branch';
import { WebApiService } from 'src/app/services/web-api.service';
import { Location } from '@angular/common';
import { UrlDataService } from 'src/app/services/url-service';

@Component({
  selector: 'app-branch-create',
  templateUrl: './branch-create.component.html',
  styleUrls: ['./branch-create.component.css']
})
export class BranchCreateComponent implements OnInit {

  model!: Branch;
  constructor(
    public service: WebApiService,
    private toastr: ToastrService,
    private _location: Location,
    private SpinnerService: NgxSpinnerService

  ) { }

  ngOnInit(): void {
    this.model = new Branch();
  }
   
  backClicked(){
    this._location.back();
  }

  save(){
    this.SpinnerService.show(); 
    this.service.save(UrlDataService.saveBranch, this.model).subscribe((response: any)=>{
      this.toastr.success(response.result.result)
      this.model = {
        id: 0,
        branchName: '',
        password: '',
        mac: ''
      }
      this.SpinnerService.hide(); 
    })
  }

}
