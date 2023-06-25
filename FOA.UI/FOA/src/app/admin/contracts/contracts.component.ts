import { Component, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { Contract } from 'src/models/contract';
import { AdminService } from 'src/core/admin.service';
import { MatDialog } from '@angular/material/dialog';
import { AddContractComponent } from './add-contract/add-contract.component';


@Component({
  selector: 'app-contracts',
  templateUrl: './contracts.component.html',
  styleUrls: ['./contracts.component.scss'],
})
export class ContractsComponent {
  contracts: Contract[] = [];
  displayedColumns: string[] = ['Service', 'ProviderName', 'Amount', 'Actions'];
  dataSource!: MatTableDataSource<Contract>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private adminService: AdminService,
    private dialog: MatDialog) {
    this.getContracts();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  openAddDialog(){
    const dialogRef = this.dialog.open(AddContractComponent);
    dialogRef.afterClosed().subscribe(() => {
      
    });
  }

  getContracts() {
    this.adminService.getContracts().subscribe({
      next: (response) => this.contracts = [...response],
      complete: () => {
        this.dataSource = new MatTableDataSource(this.contracts)
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error: (err) => console.error(err)
    })
  }
}

