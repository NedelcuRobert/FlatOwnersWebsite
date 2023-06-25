import { Component, Inject } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ApartmentService } from 'src/core/apartment.service';
import { WaterConsumptionRequest } from 'src/models/requests/edit-apartment';

@Component({
  selector: 'app-add-water-consumption',
  templateUrl: './add-water-consumption.component.html',
  styleUrls: ['./add-water-consumption.component.scss']
})
export class AddWaterConsumptionComponent {
  currentDate!: string;
  kitchenCold: FormControl = new FormControl('', Validators.required);
  bathroomCold: FormControl = new FormControl('', Validators.required);
  kitchenHot: FormControl = new FormControl('', Validators.required);
  bathroomHot: FormControl = new FormControl('', Validators.required);


  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private apartmentService: ApartmentService
  ) {
   this.currentDate = (new Date().getMonth() + 1).toString() + '-' + new Date().getFullYear().toString();

  }

  onAdd(): void {
    let request = this.buildRequest();

    this.apartmentService.addWaterConsumption(request).subscribe({
      error: (err) => console.error(err)
    })
  }

  get isDisabled(): boolean {
    return this.kitchenCold.invalid || this.bathroomCold.invalid || this.bathroomHot.invalid || this.kitchenHot.invalid;
  }

  buildRequest(): WaterConsumptionRequest {
    let request = new WaterConsumptionRequest();

    request.apartmentId = this.data.id;
    request.coldBathroom = this.bathroomCold.value;
    request.coldKitchen = this.kitchenCold.value;
    request.hotBathroom = this.bathroomHot.value;
    request.hotKitchen = this.kitchenHot.value;

    return request;
  }
}
