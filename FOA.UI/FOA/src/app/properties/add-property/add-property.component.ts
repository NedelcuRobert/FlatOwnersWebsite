import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { SessionStorageService } from 'ngx-webstorage';
import { ApartmentService } from 'src/core/apartment.service';
import { AppartmentRequest } from 'src/models/requests/appartment-request';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.scss']
})
export class AddPropertyComponent {
  phoneControl: FormControl = new FormControl('', Validators.required);
  surfaceControl: FormControl = new FormControl('', Validators.required);
  numberOfPeopleControl: FormControl = new FormControl('', Validators.required);
  cityControl: FormControl = new FormControl('', Validators.required);
  streetControl: FormControl = new FormControl('', Validators.required);
  buildingControl: FormControl = new FormControl('', Validators.required);
  numberControl: FormControl = new FormControl('', Validators.required);

  constructor(private apartmentService: ApartmentService,
    private sessionStorageService: SessionStorageService){

  }

  onAdd(){
    let request = this.buildRequest();

    this.apartmentService.create(request).subscribe({
      next: (response) => console.log(response),
      error: (err) => console.error(err)
    })
  }

  get isDisabled(): boolean {
    return this.phoneControl.invalid && this.surfaceControl.invalid && this.numberOfPeopleControl.invalid
          && this.cityControl.invalid && this.streetControl.invalid && this.buildingControl.invalid
          && this.numberControl.invalid;
  }

  buildRequest(): AppartmentRequest {
    let request = new AppartmentRequest();
    request.userId = this.sessionStorageService.retrieve('user').username;
    request.phoneNumber = this.phoneControl.value;
    request.surface = this.surfaceControl.value;
    request.numberOfPersons = this.numberOfPeopleControl.value;
    request.city = this.cityControl.value;
    request.street = this.streetControl.value;
    request.building = this.buildingControl.value;
    request.apartmentNumber = this.numberControl.value;

    return request;
  }
}
