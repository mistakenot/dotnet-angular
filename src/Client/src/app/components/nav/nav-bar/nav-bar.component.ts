import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AuthService, IAuthService } from '../../../services/auth.service';

@Component({
  moduleId: module.id,
  selector: 'nav-bar',
  templateUrl: 'nav-bar.component.html',
  styleUrls: ['nav-bar.component.css']
  //providers: [{ provide: AuthService, useClass: MockAuthService}]
})
export class NavBarComponent implements OnInit {
    loggedIn: Observable<boolean>

    email: string;
    password: string;
    isError: boolean;
    errorMsg: string;

  constructor(
      private authService: AuthService
  ) {
      this.loggedIn = authService.loggedIn;
      this.resetForm();
  }

  ngOnInit() {
  }

  loginWithEmail() {
      this.authService.login(this.email, this.password).then(() => {
          this.email = "";
          this.password = "";
      })
      .catch(e => {
          this.isError = true;
          this.errorMsg = "There has been an error.";
      })
      .then(() => {
          this.resetForm();
      });
  }

  logoutWithEmail() {
      this.authService.logout().then(() => {
          this.resetForm();
      });
  }

  private resetForm() {
      this.email = "";
      this.password = "";
      this.isError = false;
      this.errorMsg = "";
  }

}
