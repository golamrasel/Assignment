import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResponseModel } from '../model/response';

@Injectable({
  providedIn: 'root'
})
export class WebApiService {

  constructor(private Http: HttpClient) {
  }

  save(url:string, model: any) {
    return this.Http.post(`${environment.baseUrl + url}`, model);
  }
  // getList(url: string, model: any) {
  //   let content:any ={
  //     headers: {'Content-Type': 'application/json'}
  // }
  // console.log(model);
  //   return this.Http.post<ResponseModel>(`${environment.baseUrl + url}`,model);
  // }

  getList(url: string, model: any) {
    return this.Http.post<ResponseModel>(`${environment.baseUrl + url}`,model);
  }

  get(url: string, id: number): Observable<ResponseModel> {
    return this.Http.get<ResponseModel>(`${environment.baseUrl + url + id}`);
  }

  update(url:string, model: any) {
    return this.Http.post(`${environment.baseUrl + url}`, model);
  }

  delete(url: string, id: number): Observable<ResponseModel>{
    return this.Http.delete<ResponseModel>(`${environment.baseUrl + url + id}`);
  }
}