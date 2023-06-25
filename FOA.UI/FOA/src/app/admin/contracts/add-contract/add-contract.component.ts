import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { AdminService } from 'src/core/admin.service';
import { AddContractRequest } from 'src/models/requests/add-contract-request';

@Component({
  selector: 'app-add-contract',
  templateUrl: './add-contract.component.html',
  styleUrls: ['./add-contract.component.scss']
})
export class AddContractComponent {
  provider: FormControl = new FormControl('', Validators.required);
  service: FormControl = new FormControl('', Validators.required);
  cost: FormControl = new FormControl('', Validators.required);

  constructor(private adminService: AdminService) {

  }

  onAdd(){
    let request = this.buildRequest();

    this.adminService.addContract(request).subscribe({
      complete: () => {
        window.location.reload();
      }
    })
  }

  buildRequest(): AddContractRequest{
    let request = new AddContractRequest();

    request.amount = this.cost.value;
    request.providerName = this.provider.value;
    request.serviceName = this.service.value;
    request.startDate = new Date().toUTCString();
    request.endDate = new Date().toUTCString();

    return request;
  }
}
