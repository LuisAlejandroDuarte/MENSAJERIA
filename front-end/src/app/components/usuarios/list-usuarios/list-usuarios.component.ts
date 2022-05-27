import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Usuario,TableUsuario } from 'src/app/model/usuario.model';
import { UsuarioService } from 'src/app/services/usuario.service';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { DatatableService } from 'src/app/services/change/datatable.service';
import { typeColumns } from 'src/app/shared/datatable/datatable.component';


@Component({
  selector: 'app-list-usuarios',
  templateUrl: './list-usuarios.component.html',
  styleUrls: ['./list-usuarios.component.css']
})
export class ListUsuariosComponent implements OnInit {

  constructor(private usuarioServicio:UsuarioService,private spinner: NgxSpinnerService,private router:Router,private dataTableService:DatatableService) { }
  data: Usuario[]=[];
  columns: typeColumns[]=[];  
  usuarios:TableUsuario[]=[];
  host:string;


  ngOnInit(): void {      
    this.host=`${ environment.base_url}/GetAllUsuarios/`
          this.columns=[          
            {title:'Usuario',data:'user'},{title:'Nombres',data:'nombre'},{title:'Id',data:'id',visible:false}
              ,{title:'Apellidos',data:'apellido'},{title:'Rol',data:'rol'},{title:'Bloqueado',data:'bloqueado',orderable:false},
              {title:'Editar',data:'edit',orderable:false, render: (data, type, row)=> {
                return `<a class="btn btn-link btn-warning btn-just-icon edit"  data-item='editar'><i class="material-icons">dvr</i></a>`
            }}];             
  }

  onclickEditar(data:Usuario) {
    this.router.navigateByUrl('components/edit-usuario/'+ data.id);    
  }

  onCrearUsuario() {
    this.router.navigateByUrl('components/crear-usuario');    
  }
}
