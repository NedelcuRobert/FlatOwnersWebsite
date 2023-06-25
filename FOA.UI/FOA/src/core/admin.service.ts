import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contract } from 'src/models/contract';
import { Employee } from 'src/models/employee';
import { AddContractRequest } from 'src/models/requests/add-contract-request';
import { AddEmployeeRequest } from 'src/models/requests/add-employee-request';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  url: string = "https://localhost:7211/api";

  constructor(private http: HttpClient) { }

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.url}/Employee`);
  }

  addEmployee(request: AddEmployeeRequest): Observable<void>{
    return this.http.post<void>(`${this.url}/Employee`, request);
  }

  getContracts(): Observable<Contract[]> {
    return this.http.get<Contract[]>(`${this.url}/Contract`);
  }

  addContract(request: AddContractRequest): Observable<void>{
    return this.http.post<void>(`${this.url}/Contract`, request);
  }
}
