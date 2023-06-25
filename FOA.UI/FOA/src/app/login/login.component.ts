import { Component } from '@angular/core';
import { LoginModel } from 'src/models/login-model';
import { AuthenticationService } from '../authentication.service';
import { User } from 'src/models/user';
import { FormControl, Validators } from '@angular/forms';
import { SessionStorageService } from 'ngx-webstorage';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  message: string = '';
  input: LoginModel = new LoginModel();
  user!: User;
  emailControl = new FormControl('', Validators.required);
  passwordControl = new FormControl('', Validators.required);


  constructor(private authService: AuthenticationService,
    private sessionStorageService: SessionStorageService){
  }

  onInputChange(field: string, inputChangeEvent: Event): void{

  }

  onSubmit() {
    this.input.email = this.emailControl.value as string;
    this.input.password = this.passwordControl.value as string;
    this.authService.login(this.input).subscribe({
      next: (response) => this.user = response,
      complete: () => {
        this.saveUser(this.user)
      },
      error: (err) => {
        console.error(err),
        this.message = 'Login failed!'
      }
    })
  }

  private saveUser(user: any) {
    this.sessionStorageService.store('user', user);
  }
}
