import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../auth/auth.service';
import { User } from '../model/User';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  model: User;
  constructor(
    private authService: AuthService,
    private toastrService: ToastrService
  ) {
    this.model = {
      email: '',
      password: '',
    };
  }

  ngOnInit(): void {}

  onSubmit() {
    this.authService.signinUser(this.model).subscribe(
      (result) => {
        this.authService.routeDashboard();
      },
      (error) => {
        this.toastrService.error('Login failed!', 'Error!', {
          positionClass: 'toast-bottom-right',
        });
      }
    );
  }
}
