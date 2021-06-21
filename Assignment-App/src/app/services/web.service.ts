import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable()

export class WebService {
  constructor(private httpService: HttpClient) {}

  post(url: string, data: any): Observable<any> {
    var self = this;
    var config = {
      headers: { 'Content-Type': 'application/json' },
    };
    return self.httpService.post(url, data, config).pipe(
      map((response: any) => {
        return response;
      })
    );
  }
}
