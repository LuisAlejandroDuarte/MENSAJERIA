import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FacturaServicioComponent } from './factura-servicio/factura-servicio.component';
import { RouterModule } from '@angular/router';
import { ReportesRoutes } from './reportes.routing';
import { DatatableNetModule } from '../shared/datatable/datatable.module';



@NgModule({  
  declarations: [
    FacturaServicioComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(ReportesRoutes),
    DatatableNetModule
  ]
})
export class ReportesModule { }
