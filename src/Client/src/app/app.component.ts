import { Component } from '@angular/core';
import { NavBarComponent } from './nav/nav-bar'
import { AuthService, MockAuthService } from './services/auth.service';

@Component({
  moduleId: module.id,
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.css'],
  directives: [NavBarComponent],
  providers: [{ provide: AuthService, useClass: MockAuthService}]
})
export class AppComponent {
  title = 'app works!';
}
