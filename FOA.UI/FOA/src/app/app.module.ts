import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenuComponent } from './menu/menu.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PropertiesComponent } from './properties/properties.component';
import { NewsComponent } from './news/news.component';
import { RequestsComponent } from './requests/requests.component';
import { ProfileComponent } from './profile/profile.component';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule, MatIconButton } from '@angular/material/button';
import { ReportsComponent } from './reports/reports.component';
import { MatIconModule } from '@angular/material/icon';
import { PropertyComponent } from './properties/property/property.component';
import { MatCardModule } from '@angular/material/card';
import { AddPropertyComponent } from './properties/add-property/add-property.component';
import { MatDialogModule } from '@angular/material/dialog';
import { EditPropertyComponent } from './properties/property/edit-property/edit-property.component';
import { ViewPropertyComponent } from './properties/property/view-property/view-property.component';
import { AddWaterConsumptionComponent } from './properties/property/add-water-consumption/add-water-consumption.component';
import { AdminComponent } from './admin/admin.component';
import { EmployeesComponent } from './admin/employees/employees.component';
import { ContractsComponent } from './admin/contracts/contracts.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { AdminReportsComponent } from './admin/admin-reports/admin-reports.component';
import { AdminRequestsComponent } from './admin/admin-requests/admin-requests.component';
import { AddRequestComponent } from './requests/add-request/add-request.component';
import { RequestCardComponent } from './requests/request-card/request-card.component';
import { RequestDetailsComponent } from './requests/request-card/request-details/request-details.component';import { ServicesModule } from 'src/core/services.module';
import { HttpClientModule } from '@angular/common/http';
import {NgxWebstorageModule} from 'ngx-webstorage';
import { AddContractComponent } from './admin/contracts/add-contract/add-contract.component';
import { AddEmployeeComponent } from './admin/employees/add-employee/add-employee.component';


@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    LoginComponent,
    RegisterComponent,
    DashboardComponent,
    PropertiesComponent,
    NewsComponent,
    RequestsComponent,
    ProfileComponent,
    ReportsComponent,
    PropertyComponent,
    AddPropertyComponent,
    EditPropertyComponent,
    ViewPropertyComponent,
    AddWaterConsumptionComponent,
    AdminComponent,
    EmployeesComponent,
    ContractsComponent,
    AdminReportsComponent,
    AdminRequestsComponent,
    AddRequestComponent,
    RequestCardComponent,
    RequestDetailsComponent,
    AddContractComponent,
    AddEmployeeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatDialogModule,
    MatTabsModule,
    MatTableModule,
    MatPaginatorModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgxWebstorageModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
