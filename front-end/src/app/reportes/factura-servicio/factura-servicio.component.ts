import { Component, OnInit } from '@angular/core';
import { ReporteServicio } from 'src/app/model/reporte.model';
import { ReporteService } from 'src/app/services/reporte.service';
import { typeColumns } from 'src/app/shared/datatable/datatable.component';
import Swal from 'sweetalert2';
import { NgxSpinnerService } from 'ngx-spinner';


@Component({
  selector: 'app-factura-servicio',
  templateUrl: './factura-servicio.component.html',
  styleUrls: ['./factura-servicio.component.css']
})
export class FacturaServicioComponent implements OnInit {

  constructor(private reporteServicio:ReporteService,private snipper:NgxSpinnerService) { }

  columns:typeColumns[]=[];
  data:ReporteServicio[]=[];

  ngOnInit(): void {

    this.columns =[
            {title:'Moto',data:'placa'},
            {title:'Propietario',data:'nombrePropietario'},
            {title:'Valor',data:'valor'}
          ];
    

    this.snipper.show();          
    this.reporteServicio.getFacturaServicio().subscribe({
          next:(resp:ReporteServicio[])=>{
            setTimeout(()=>{
              this.snipper.hide();
              this.data=resp;
            });           
          },
          error:(err)=>{
            this.snipper.hide();
            Swal.fire("Reporte Servicio",err.message,"error");
          }
    });
  }

}
