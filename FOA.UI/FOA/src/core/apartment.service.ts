import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Apartment } from 'src/models/apartment';
import { AppartmentRequest } from 'src/models/requests/appartment-request';
import { EditApartmentRequest, WaterConsumptionRequest } from 'src/models/requests/edit-apartment';
import { WaterConsumption } from 'src/models/water-consumption';

@Injectable({
  providedIn: 'root'
})
export class ApartmentService {
  url: string = "https://localhost:7211/api";

  constructor(private http: HttpClient) { }

  create(request: AppartmentRequest): Observable<Apartment> {
    return this.http.post<Apartment>(`${this.url}/Apartment`, request);
  }

  getById(id: number): Observable<Apartment> {
    return this.http.get<Apartment>(`${this.url}/Apartment/${id}`);
  }

  getByUserId(userId: string): Observable<Apartment[]> {
    return this.http.get<Apartment[]>(`${this.url}/Apartment/user/${userId}`);
  }

  addWaterConsumption(request: WaterConsumptionRequest) {
    return this.http.post<any>(`${this.url}/WaterConsumption`, request);
  }

  getWaterConsumption(apartmentId: number): Observable<WaterConsumption[]> {
    return this.http.get<WaterConsumption[]>(`${this.url}/WaterConsumption/apartment/${apartmentId}`)

  }

  editApartment(apartmentId: number, request: EditApartmentRequest): Observable<void> {
    return this.http.put<void>(`${this.url}/Apartment/${apartmentId}`, request)
  }
}
