import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseModel } from '../model/response';
import { Student } from '../model/student';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(
    private Http: HttpClient
    ) { }

  saveStudent(model:Student) {
    return this.Http.post('http://localhost:1074/api/Student/Add', model);
  }

  studentList(): Observable<ResponseModel> {
    return this.Http.get<ResponseModel>('http://localhost:1074/api/Student/All');
  }

  


}