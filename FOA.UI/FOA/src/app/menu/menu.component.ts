import { Component, OnInit } from '@angular/core';
import { SessionStorageService } from 'ngx-webstorage';
import { ProfileService } from 'src/core/profile.service';
import { User } from 'src/models/user';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  user!: User;
  profileUrl!: string;

  constructor(private sessionStorageService: SessionStorageService,
    private profileService: ProfileService) {

  }

  ngOnInit(): void {
    this.user = this.sessionStorageService.retrieve('user');
    this.profileService.getProfilePicture(this.user.id).subscribe({
      next: (response) => this.profileUrl = response
    })
    console.log(this.user)
  }

  onSignOut(): void {
    this.clearSessionStorage();
  }

  private clearSessionStorage(): void {
    this.sessionStorageService.clear('user');
  }
}
