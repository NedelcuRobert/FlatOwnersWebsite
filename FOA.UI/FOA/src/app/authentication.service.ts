import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginModel } from 'src/models/login-model';
import { CONFIG } from './config';
import { User } from 'src/models/user';
import { RegisterRequest } from 'src/models/requests/register-request';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  url: string = "https://localhost:7211/api";

  constructor(private http: HttpClient) { }

  login(request: LoginModel): Observable<User> {
    return this.http.post<User>(`${this.url}/auth/login`, request);
  }

  register(request: RegisterRequest): Observable<User> {
    return this.http.post<User>(`${this.url}/auth/register`, request);
  }
}
