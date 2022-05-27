import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DatatableNetComponent } from './datatable.component';

import { DataTablesModule } from "angular-datatables";
import { TableSimpleComponent } from '../tablesimple/table-simple.component';
@NgModule({
  imports: [
    CommonModule,
    DataTablesModule
  ],
  declarations: [DatatableNetComponent,TableSimpleComponent],
  exports: [DatatableNetComponent,TableSimpleComponent]
})
export class DatatableNetModule { }
