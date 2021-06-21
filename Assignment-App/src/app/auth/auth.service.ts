import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { User } from '../model/User';

@Injectable()
export class AuthService {
  private loggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  email: string =  '123';
  password: string =  '123';

  get isLoggedIn() {
    return this.loggedIn.asObservable();
  }

  constructor(
    private router: Router,
    private toastr : ToastrService
  ) {}

  login(model: User) {
    if (this.isAuthenticated(model)) {
      this.loggedIn.next(true);
      this.router.navigate(['/']);
    }
    else{
      this.toastr.error("Email or Password incorrect!!")
    }
  }

  logout() {
    this.loggedIn.next(false);
    this.router.navigate(['/login']);
  }

  isAuthenticated(model: User): boolean{
    if (this.email == model.email && this.password == model.password ) 
        return true;
    else   
        return false;
  }
}