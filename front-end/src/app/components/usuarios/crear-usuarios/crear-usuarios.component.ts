import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Usuario } from 'src/app/model/usuario.model';
import { UsuarioService } from 'src/app/services/usuario.service';
import Swal from 'sweetalert2';
import { Encriptacion } from 'src/app/help/cripto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-crear-usuarios',
  templateUrl: './crear-usuarios.component.html',
  styleUrls: ['./crear-usuarios.component.css']
})
export class CrearUsuariosComponent implements OnInit {

  constructor(private spinner: NgxSpinnerService,private usuarioService:UsuarioService,private router:Router) { }
  
  ngOnInit(): void {
  }

  save(usuario:Usuario) {
    this.spinner.show(); 
    usuario.password= Encriptacion.encriptar(usuario.user);
    this.usuarioService.crearUsuario(usuario).subscribe({
      next:(resp)=>{
        this.spinner.hide();    
        Swal.fire("Usuario","Guardado","success");
        this.router.navigateByUrl('components/usuarios');
      },
      error:(err)=>{
        this.spinner.hide();            
        Swal.fire("Usuario",err.message,'error');
      }
    })
  }
}
