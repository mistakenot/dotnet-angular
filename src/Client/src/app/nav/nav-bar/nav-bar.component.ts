import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AuthService, IAuthService } from '../../services/auth.service';

@Component({
  moduleId: module.id,
  selector: 'nav-bar',
  templateUrl: 'nav-bar.component.html',
  styleUrls: ['nav-bar.component.css']
  //providers: [{ provide: AuthService, useClass: MockAuthService}]
})
export class NavBarComponent implements OnInit {
    loggedIn: Observable<boolean>

    email: string
    password: string

  constructor(
      private authService: AuthService
  ) {
      this.loggedIn = authService.loggedIn
      this.email = ""
      this.password = ""
  }

  ngOnInit() {
  }

  loginWithEmail() {
      this.authService.login(this.email, this.password);
  }

  logoutWithEmail() {
      this.authService.logout();
  }

}
