import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { WebService } from '../services/web.service';
import { UrlService } from '../services/url.service';
import { map } from 'rxjs/operators';

@Injectable()
export class AuthService {
  private loggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  get isLoggedIn() {
    return this.loggedIn.asObservable();
  }

  constructor(
    private router: Router,
    private web: WebService
  ) {}

  routeDashboard() {
      this.loggedIn.next(true);
      this.router.navigate(['/']);
  }

  signinUser(data:any) {
    return this.web.post(UrlService.signIn, data)
      .pipe(map(result => {
        return result;
      }));
  }

  logout() {
    this.loggedIn.next(false);
    this.router.navigate(['/login']);
  }

}
