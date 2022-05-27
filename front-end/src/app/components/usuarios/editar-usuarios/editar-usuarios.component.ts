import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Usuario } from 'src/app/model/usuario.model';
import { UsuarioService } from 'src/app/services/usuario.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-editar-usuarios',
  templateUrl: './editar-usuarios.component.html',
  styleUrls: ['./editar-usuarios.component.css']
})
export class EditarUsuariosComponent implements OnInit {

  id:string;

  constructor(private activatedRoute: ActivatedRoute,private usuarioService:UsuarioService,private spinner: NgxSpinnerService) { 
       
  }
  modelo:Usuario;
  titulo:string;

  ngOnInit(): void {   
    this.titulo="Editar Usuario";
    this.spinner.show();    
    this.activatedRoute.params.subscribe((params)=>{
      this.usuarioService.getUser(params.id).subscribe({

        next:(res:any)=>{  
          this.spinner.hide();
          setTimeout(()=>{
            this.modelo=res;
            this.modelo.id=res.id;
            this.titulo="Editar Usuario";
            console.log("Datos usuario",res);
          },1000);          
        },
        error:(err)=>{
            this.spinner.hide();
            Swal.fire("Usuario",err.error.Message,'error');
        }
  
      })
    });       
  }

  save(usuario:Usuario) {   
    this.spinner.show();   
    console.log("EnviarActualiza",usuario); 
    this.usuarioService.actualizarPerfil(usuario).subscribe({
      next:(resp)=>{
        this.spinner.hide();    
        Swal.fire("Usuario","Actualizado","success");
      },
      error:(err)=>{
        this.spinner.hide();     
        console.log(err);       
        Swal.fire("Usuario",err.error.Message,'error');
      }
    })
  }

}
