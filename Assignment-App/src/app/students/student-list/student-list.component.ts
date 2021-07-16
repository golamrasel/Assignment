import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ColumnMode } from '@swimlane/ngx-datatable';
import { ToastrService } from 'ngx-toastr';
import { PageRequestModel } from 'src/app/model/pageRequest';
import { PageResponseModel } from 'src/app/model/pageResponse';
import { Student } from 'src/app/model/student';
import { StudentService } from 'src/app/services/student.service';
import { UrlDataService } from 'src/app/services/url-service';
import { WebApiService } from 'src/app/services/web-api.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css','../../assets/libs/datatables.scss'],
  encapsulation: ViewEncapsulation.None
})
export class StudentListComponent implements OnInit {
  rowData: Student[] = [];
  searchText: string = "";
  totalLength: any;
  dataPerPage: number = 0;
  paginationModel: PageRequestModel;
  columnMode = ColumnMode;
  public rows = new Array<Student>();
  page = {
    limit: 2,
    count: 0,
    offset: 0,
    orderBy: 'name',
    orderDir: 'asc'
  };

  constructor(public service: WebApiService, private toastr: ToastrService) { 
     this.paginationModel = new PageRequestModel();
     this.paginationModel.pageNo = 1;
     this.paginationModel.pageSize = 2;
  }

  ngOnInit(): void {
    this.getStudentList();
  }
  searchKeyword(){
    this.paginationModel.keyword =  this.searchText;
    this.getStudentList();
  }
  serverSideSetPage(event?:any) {
    debugger;
    this.paginationModel.pageNo = event.offset + 1;
    this.getStudentList();
  }
  getStudentList(){
    this.service.getList(UrlDataService.listStudent, this.paginationModel).subscribe( response =>{
      var responses = response.result as PageResponseModel<Student>;
      this.rows = responses.rows;
      this.page.count =  responses.count;
      console.log(response);
    }, errore => {
      console.log(errore);
    });
  }

  StudentDelete(model: Student){
    if(confirm("Are you sure delete this data?")){
    this.service.deleteData(UrlDataService.deleteStudent, model.studentId).subscribe( response => {
      var index = this.rowData.indexOf(model);
      this.rowData.splice(index);
      this.toastr.success("Delete Successfully!!");
      this.getStudentList();
    })
  }
  }
}

