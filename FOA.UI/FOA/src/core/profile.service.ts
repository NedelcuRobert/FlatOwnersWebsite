import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Profile } from 'src/models/profile';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  url: string = "https://localhost:7211/api";

  constructor(private http: HttpClient) { }

  getProfile(userId: string): Observable<Profile>{
    return this.http.get<Profile>(`${this.url}/Profile/${userId}`);
  }

  editProfile(request: Profile): Observable<Profile> {
    return this.http.put<Profile>(`${this.url}/Profile`, request);
  }

  getProfilePicture(userId: string): Observable<string> {
    return this.http.get<string>(`${this.url}/Profile/get-profile-picture/${userId}`);
  }
}
