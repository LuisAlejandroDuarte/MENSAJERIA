import { Propietario, TablaPropietario } from './../../../model/propietario.model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { PropietarioService } from 'src/app/services/propietario.service';
import { typeColumns } from 'src/app/shared/datatable/datatable.component';
import Swal from 'sweetalert2';
import { Paginator } from 'src/app/model/paginator.model';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-list-propietarios',
  templateUrl: './list-propietarios.component.html',
  styleUrls: ['./list-propietarios.component.css']
})
export class ListPropietariosComponent implements OnInit {


  constructor(private propietarioServicio:PropietarioService,private spinner: NgxSpinnerService,private router:Router) { }
  data: Propietario[]=[];
  columns: typeColumns[];  
  propietarios:TablaPropietario[]=[];
  host:string;

  ngOnInit(): void {
    this.host=environment.base_url + "/GetAllPropietarios";    
    setTimeout(()=>{
      this.columns=[          
        { title:'Id',data:'id', visible:false},
        { title:'Identificación',data:'identificacion'},
        { title:'Nombres',data:'nombre',orderable:true},
        { title:'Apellidos',data:'apellido'},
        { title:'Dirección',data:'direccion'},
        { title:'Bloqueado',data:'bloqueado'},
        { title:'Editar',data:'edit',orderable:false,
          render: (data, type, row)=> {
                return `<a class="btn btn-link btn-warning btn-just-icon edit"  data-item='editar'><i class="material-icons">dvr</i></a>`
        }}];      
    })    
  }


  onclickEditar(data:Propietario) {    
    this.router.navigateByUrl('components/edit-propietario/'+ data.id);
  }

  onCrearPropietario() {
    this.router.navigateByUrl('components/crear-propietario');
  }  

}
