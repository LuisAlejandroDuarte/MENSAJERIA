import { UsuarioService } from './../../services/usuario.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { FormValidatorService } from 'src/app/help/form-validator.service';
import { UserChangePassword, Usuario } from 'src/app/model/usuario.model';
import Swal from 'sweetalert2';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { Encriptacion } from 'src/app/help/cripto';
@Component({
  selector: 'app-cambio-clave',
  templateUrl: './cambio-clave.component.html',
  styleUrls: ['./cambio-clave.component.css']
})
export class CambioClaveComponent implements OnInit {

  formCambioClave:FormGroup;
  formSubmitted:boolean=false;
  oldPassword:string;
  newPassword:string;
  usuario:Usuario;

  constructor(private fb:FormBuilder,private formValidarCampo:FormValidatorService,
    private spinner: NgxSpinnerService,private userService:UsuarioService,private router:Router) { 
    this.formCambioClave = fb.group({
      claveactual:['',[Validators.required]],
      clave1:['',[Validators.required]],
      clave2:['',[Validators.required]]
    },{validators:this.passwordsIguales})
  }

  ngOnInit(): void {

  }

  actualizar() {
  
    
    this.formSubmitted=true;
    if (!this.formCambioClave.valid) return;   
    //this.oldPassword=CryptoJS.AES.encrypt(this.formCambioClave.get('claveactual').value,environment.key_security).toString();
    this.oldPassword=this.formCambioClave.get('claveactual').value;
    if (this.oldPassword != Encriptacion.decrypter(this.userService.usuario.password)) {
        Swal.fire("Clave","La clave actual no es la misma",'warning');
        return;
    }
    this.newPassword=this.formCambioClave.get('clave1').value;    
    this.usuario = this.userService.usuario;
    this.usuario.password=Encriptacion.encriptar(this.newPassword);
  
    this.spinner.show();    

    this.userService.changePassword(this.usuario).subscribe({
      next:(result)=>{
        this.spinner.hide();
        this.router.navigateByUrl('/dashboard');
        Swal.fire("Clave","Clave cambiada",'info');

      },
      error:(err)=> {
        this.spinner.hide();
        Swal.fire("Error",err.error.Message,'error');        
      }            
    })

  }

  validarCampo(field){

    return this.formValidarCampo.campoRequerido(this.formCambioClave, field,this.formSubmitted);

  }

  validarContrasenas():boolean {
    const pass1 = this.formCambioClave.get('clave1').value;
    const pass2 = this.formCambioClave.get('clave2').value;
      if ((pass1!==pass2) && this.formSubmitted)
        return true;
          else
        return false;
  }

  passwordsIguales(formGroup:FormGroup) {
    return ()=> {
      
      const pass1Control = formGroup.controls.clave1.value;;
      const pass2Control = formGroup.controls.clave2.value;;

      if (pass1Control.value===pass2Control.value) {
        pass2Control.setErrors(null);
      } else {
        pass2Control.setErrors({noEsIgual:true});
      }

    }
  }

}
