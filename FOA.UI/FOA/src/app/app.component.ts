import { Component } from '@angular/core';
import { SessionStorageService } from 'ngx-webstorage';
import { User } from 'src/models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'FOA';

  constructor(private sessionStorageService: SessionStorageService) { }

  get isUserAuthenticated(): boolean {
    return !!this.getUser();
  }

  getUser(): any {
    return this.sessionStorageService.retrieve('user');
  }
}
