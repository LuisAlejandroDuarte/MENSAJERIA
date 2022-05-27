import { FormValidatorService } from 'src/app/help/form-validator.service';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Roles, Usuario } from '../model/usuario.model';
import { UsuarioService } from '../services/usuario.service';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';

@Component({
    selector: 'app-user-cmp',
    templateUrl: 'user.component.html'
})




export class UserComponent {
    usuario:Usuario;
    formUser:FormGroup;
    rol:string;
    public formSend:boolean=false;
    constructor(private usuarioService:UsuarioService,private fb:FormBuilder,
        private formValidatorService: FormValidatorService,private spinner: NgxSpinnerService){
        this.usuario=usuarioService.usuario;
        this.formSend=false;
        this.rol = this.usuario.rol;
        this.formUser=fb.group({
            id:[this.usuario.id,[Validators.required]],
            empresaId:[environment.EmpresaId],
            user:[this.usuario.user,[Validators.required]],            
            nombre:[this.usuario.nombre,[Validators.required]],
            apellido:[this.usuario.apellido,[Validators.required]],
            direccion:[this.usuario.direccion],
            rol:[this.usuario.rol],            
            telefono:[this.usuario.telefono,[Validators.required]],
            estado:[this.usuario.estado]
        });
    }
    
    ngOnInit():void {

    }

     validarCampo(field)
    {
        return this.formValidatorService.campoRequerido(this.formUser, field,this.formSend);
    }



    actualizar() {
        
        if (!this.formUser.valid) return;      
        this.formSend=true;  
        this.spinner.show();
        this.usuarioService.actualizarPerfil(this.formUser.value).subscribe({
            next:(res)=>{
                this.usuarioService.usuario.user=this.formUser.get('user').value;
                this.spinner.hide();
            },
            error:(err)=>{
                this.spinner.hide();
                Swal.fire("Error",err.error.Message,'error');
            },
            complete:()=>{}
        });
    }

}
