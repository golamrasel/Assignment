import { Component, OnInit } from '@angular/core';
import { ColumnMode } from '@swimlane/ngx-datatable';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Branch } from 'src/app/model/branch';
import { PageRequestModel } from 'src/app/model/pageRequest';
import { PageResponseModel } from 'src/app/model/pageResponse';
import { UrlDataService } from 'src/app/services/url-service';
import { WebApiService } from 'src/app/services/web-api.service';

@Component({
  selector: 'app-branch-list',
  templateUrl: './branch-list.component.html',
  styleUrls: ['./branch-list.component.css']
})
export class BranchListComponent implements OnInit {
  rowData: Branch[] = [];
  searchText: string = "";
  totalLength: any;
  dataPerPage: number = 0;
  paginationModel: PageRequestModel;
  columnMode = ColumnMode;
  public rows = new Array<Branch>();
  page = {
    limit: 2,
    count: 0,
    offset: 0,
    orderBy: 'name',
    orderDir: 'asc'
  };

  constructor(
    public service: WebApiService,
    private toastr: ToastrService,
    private SpinnerService: NgxSpinnerService
      ) { 
     this.paginationModel = new PageRequestModel();
     this.paginationModel.pageNo = 1;
     this.paginationModel.pageSize = 2;
  }

  ngOnInit(): void {
    this.getBranchList();
  }
  searchKeyword(){
    this.paginationModel.keyword =  this.searchText;
    this.getBranchList();
  }
  serverSideSetPage(event?:any) {
    this.paginationModel.pageNo = event.offset + 1;
    this.getBranchList();
  }
  getBranchList(){
    this.SpinnerService.show(); 
    this.service.getList(UrlDataService.listBranch, this.paginationModel).subscribe( response =>{
      var responses = response.result as PageResponseModel<Branch>;
      this.rows = responses.rows;
      this.page.count =  responses.count;
      this.SpinnerService.hide(); 
    }, errore => {
      console.log(errore);
    });
  }

  BranchDelete(model: Branch){
    console.log(model);
    if(confirm("Are you sure delete this data?")){
    this.service.delete(UrlDataService.deleteBranch, model.id).subscribe( response => {
      var index = this.rowData.indexOf(model);
      this.rowData.splice(index);
      this.toastr.success("Delete Successfully!!");
      this.getBranchList();
    })
  }

}
}
