import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { AdminService } from 'src/core/admin.service';
import { AddEmployeeRequest } from 'src/models/requests/add-employee-request';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.scss']
})
export class AddEmployeeComponent {
  firstName: FormControl = new FormControl('', Validators.required);
  lastName: FormControl = new FormControl('', Validators.required);
  salary: FormControl = new FormControl('', Validators.required);
  phoneNumber: FormControl = new FormControl('', Validators.required);

  constructor(private adminService: AdminService){

  }

  onAdd(){
    let request = this.buildRequest();
    this.adminService.addEmployee(request).subscribe({
      complete: () => window.location.reload(),
      error: () => window.location.reload()
    });
  }

  buildRequest(): AddEmployeeRequest{
    let request = new AddEmployeeRequest();

    request.firstName = this.firstName.value;
    request.lastName = this.lastName.value;
    request.salary = this.salary.value;
    request.phoneNumber = this.phoneNumber.value;

    return request;
  }
}
