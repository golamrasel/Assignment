import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { User } from '../model/User';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

   model: User;

  // password: string = '123';
  constructor(private router: Router, private authService: AuthService) {
    this.model = {
      email:'',
      password:''
    }
  }

  ngOnInit(): void {
  }

  // Save() {
  //   if (this.authenticated()) {
  //     this.router.navigate(['/dashboard'])
  //   }
  //   else {
  //     console.log("user name or password not correct !");
  //   }


    onSubmit() {
      console.log(this.model);
      this.authService.login(this.model);
    }


  }

 

