import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { SessionStorageService } from 'ngx-webstorage';
import { ProfileService } from 'src/core/profile.service';
import { Profile } from 'src/models/profile';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
  inEditMode: boolean = false;
  profile!: Profile;
  email = new FormControl('', Validators.required);
  firstName = new FormControl('', Validators.required);
  lastName = new FormControl('', Validators.required);
  password = new FormControl('', Validators.required);
  city = new FormControl('', Validators.required);
  street = new FormControl('', Validators.required);
  building = new FormControl('', Validators.required);
  apartmentNumber = new FormControl('', Validators.required);

  constructor(private profileService: ProfileService,
    private sessionStorageService: SessionStorageService) {
    let userId = this.sessionStorageService.retrieve('user').id;
    this.profileService.getProfile(userId).subscribe({
      next: (response) => this.profile = response
    })
  }

  mapValues(){

  }


}
