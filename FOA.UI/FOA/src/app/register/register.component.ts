import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { LoginModel } from 'src/models/login-model';
import { RegisterRequest } from 'src/models/requests/register-request';
import { User } from 'src/models/user';
import { AuthenticationService } from '../authentication.service';
import { SessionStorageService } from 'ngx-webstorage';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  user!: User;
  message: string = '';
  email = new FormControl('', Validators.required);
  firstName = new FormControl('', Validators.required);
  lastName = new FormControl('', Validators.required);
  password = new FormControl('', Validators.required);
  city = new FormControl('', Validators.required);
  street = new FormControl('', Validators.required);
  building = new FormControl('', Validators.required);
  apartmentNumber = new FormControl('', Validators.required);

  constructor(private authService: AuthenticationService,
    private sessionStorageService: SessionStorageService){
  }

  get isDisabled(): boolean {
    return this.email.invalid || this.firstName.invalid || this.lastName.invalid || this.password.invalid
                              || this.city.invalid || this.building.invalid || this.street.invalid || this.apartmentNumber.invalid;
  }

  onSubmit(): void {
    let request = this.buildRequest();

    this.authService.register(request).subscribe({
      next: (response) => this.user = response,
      complete: () => {
        this.saveUser(this.user);
      },
      error: (err) => {
        console.error(err)
        this.message = "Register failed!"
      }
    })
  }

  buildRequest(): RegisterRequest {
    let request = new RegisterRequest();
    request.apartmentNumber = this.apartmentNumber.value as string;
    request.city = this.city.value as string;
    request.email = this.email.value as string;
    request.firstName = this.firstName.value as string;
    request.lastName = this.lastName.value as string;
    request.password = this.password.value as string;
    request.street = this.street.value as string;
    request.building = this.building.value as string;

    return request;
  }

  private saveUser(user: any) {
    this.sessionStorageService.store('user', user);
  }
}
