import { Ruta, TablaRuta } from './../../../model/ruta.model';
import { Component, OnInit } from '@angular/core';
import { typeColumns } from 'src/app/shared/datatable/datatable.component';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { RutaService } from 'src/app/services/ruta.service';
import Swal from 'sweetalert2';
import * as moment from 'moment';
@Component({
  selector: 'app-list-rutas',
  templateUrl: './list-rutas.component.html',
  styleUrls: ['./list-rutas.component.css']
})
export class ListRutasComponent implements OnInit {

  data: Ruta[]=[];
  columns: typeColumns[];
  dtOptions: DataTables.Settings = {};
  rutas:TablaRuta[]=[];


  constructor(private rutaServicio:RutaService,private spinner: NgxSpinnerService,private router:Router) { }

  ngOnInit(): void {
    setTimeout(()=>{
      this.columns=[          
        { title:'Id',data:'id', visible:false},
        { title:'Inicia',data:'inicia',
          render: (data,key,row)=> {
            return `${moment(data).format("hh:mm a")}`
          }},
        { title:'Termina',data:'termina',
          render: (data,key,row)=> {
            return `${moment(data).format("hh:mm a")}`
          }},
        { title:'Placa',data:'placa'},
        { title:'Propietario',data:'nombrePropietario'},        
        { title:'Valor',data:'valor'},        
        { title:'Ver',data:'edit',
          render: ()=> {
                return `<a class="btn btn-link btn-warning btn-just-icon edit"  data-item='editar'><i class="material-icons">dvr</i></a>`
          }}
      ];
        this.spinner.show();
        this.rutaServicio.getAll().subscribe({
          next:(resp:Ruta[])=>{              
              resp.forEach(element => {                 
                const nombrePropietario :string=`${element.nombrePropietario}`;
                this.data.push(new TablaRuta(element.id,element.turnoId,element.inicia,element.termina,
                                  element.destino,element.telefono,element.valor,element.estado,element.placa,
                                   nombrePropietario,element.observacion,(element.estado==true)?'Si':'No',''));
              });
              this.spinner.hide();
          },
          error:(err)=>{
            this.spinner.hide();
            Swal.fire("Rutas",err.error.message,'error');
          }
      });
    });
  }

  onCrearRuta() {

  }

  onclickEditar(ruta:Ruta) {

    const html =`Destino : ${ruta.destino} <br> Teléfono : ${ruta.telefono}`;

    Swal.fire("Detalle ruta",html,"info");
  }

}
