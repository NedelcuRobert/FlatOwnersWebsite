import { DataSource } from '@angular/cdk/collections';
import { Component, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import { Observable, ReplaySubject } from 'rxjs';
import { Employee } from 'src/models/employee';
import { AdminService } from 'src/core/admin.service';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent {
  employees: Employee[] = [];
  displayedColumns: string[] = ['FirstName', 'LastName', 'PhoneNumber', 'Salary', 'Actions'];
  dataSource!: MatTableDataSource<Employee>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private adminService: AdminService,
    private dialog: MatDialog) {
    this.getEmployees();
  }


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  openAddDialog(){
    const dialogRef = this.dialog.open(AddEmployeeComponent);
    dialogRef.afterClosed().subscribe(() => {

    });
  }

  getEmployees(): void {
    this.adminService.getEmployees().subscribe({
      next: (response) => this.employees = [...response],
      complete: () => {
        this.dataSource = new MatTableDataSource(this.employees)
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error: (err) => console.error(err)
    })
  }
}
