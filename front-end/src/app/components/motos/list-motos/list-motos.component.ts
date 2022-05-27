import { Moto, TablaMoto } from './../../../model/moto.model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MotoService } from 'src/app/services/moto.service';
import Swal from 'sweetalert2';
import { typeColumns } from 'src/app/shared/datatable/datatable.component';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-list-motos',
  templateUrl: './list-motos.component.html',
  styleUrls: ['./list-motos.component.css']
})
export class ListMotosComponent implements OnInit {

  data: Moto[]=[];
  columns: typeColumns[];
  dtOptions: DataTables.Settings = {};
  motos:TablaMoto[]=[];
  host:string;
  
  constructor(private motoServicio:MotoService,private spinner: NgxSpinnerService,private router:Router) { }

  ngOnInit(): void {
    const base_url = environment.base_url;
    this.host=`${base_url}/GetAllmoto/`;

    setTimeout(()=>{
      this.columns=[          
        { title:'Id',data:'id', visible:false},
        { title:'Placa',data:'placa'},
        { title:'Propietario',data:'nombrePropietario'},        
        { title:'Bloqueado',data:'bloqueado',orderable:false},        
        { title:'Editar',data:'edit',orderable:false,
          render: ()=> {
                return `<a class="btn btn-link btn-warning btn-just-icon edit"  data-item='editar'><i class="material-icons">dvr</i></a>`
          }}
      ];

    })

  }

  onclickEditar(data:Moto)
  {
    this.router.navigateByUrl('components/edit-moto/' + data.id);
  }

  onCrearMoto() {
    this.router.navigateByUrl('components/crear-moto');
  }

}
