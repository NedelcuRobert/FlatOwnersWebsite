import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FOAReport } from 'src/models/report';

@Injectable({
  providedIn: 'root'
})
export class ReportsService {
  url: string = "https://localhost:7211/api";

  constructor(private http: HttpClient) { }

  generateReports(): Observable<void> {
    return this.http.post<void>(`${this.url}/Invoice`, "")
  }

  getReports(): Observable<FOAReport[]> {
    return this.http.get<FOAReport[]>(`${this.url}/Invoice`);
  }

  getReportForApartment(apartmentId: number): Observable<FOAReport[]> {
    return this.http.get<FOAReport[]>(`${this.url}/Invoice/apartment/${apartmentId}`);
  }
}
