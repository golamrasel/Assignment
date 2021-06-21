import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-topbar',
  templateUrl: './topbar.component.html',
  styleUrls: ['./topbar.component.css']
})
export class TopbarComponent implements OnInit {
  
  isLoggedIn$: Observable<boolean>;

  constructor(private authService: AuthService) { 
    this.isLoggedIn$ = this.authService.isLoggedIn;
  }

  ngOnInit(): void {
  }
  onLogout() {
    this.authService.logout();
  }
}
