import { Component, Inject } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SessionStorageService } from 'ngx-webstorage';
import { ApartmentService } from 'src/core/apartment.service';
import { AppartmentRequest } from 'src/models/requests/appartment-request';
import { EditApartmentRequest } from 'src/models/requests/edit-apartment';

@Component({
  selector: 'app-edit-property',
  templateUrl: './edit-property.component.html',
  styleUrls: ['./edit-property.component.scss']
})
export class EditPropertyComponent {
  phoneControl: FormControl = new FormControl('', Validators.required);
  surfaceControl: FormControl = new FormControl('', Validators.required);
  numberOfPeopleControl: FormControl = new FormControl('', Validators.required);
  cityControl: FormControl = new FormControl('', Validators.required);
  streetControl: FormControl = new FormControl('', Validators.required);
  buildingControl: FormControl = new FormControl('', Validators.required);
  numberControl: FormControl = new FormControl('', Validators.required);

  constructor(private apartmentService: ApartmentService,
    private sessionStorageService: SessionStorageService,
    @Inject(MAT_DIALOG_DATA) public data: any){

  }

  onAdd(){
    let request = this.buildRequest();

    this.apartmentService.editApartment(this.data.id, request).subscribe({
      next: (response) => console.log(response),
      error: (err) => console.error(err)
    })
  }

  get isDisabled(): boolean {
    return this.phoneControl.invalid && this.surfaceControl.invalid && this.numberOfPeopleControl.invalid
          && this.cityControl.invalid && this.streetControl.invalid && this.buildingControl.invalid
          && this.numberControl.invalid;
  }

  buildRequest(): EditApartmentRequest {
    let request = new EditApartmentRequest();
    request.phoneNumber = this.phoneControl.value;
    request.numberOfPersons = this.numberOfPeopleControl.value;

    return request;
  }
}
