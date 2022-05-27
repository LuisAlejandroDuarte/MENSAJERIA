import { Component, EventEmitter, Input, OnInit, Output, OnChanges, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { FormValidatorService } from 'src/app/help/form-validator.service';
import { Roles, Usuario,DataRoles } from 'src/app/model/usuario.model';
import { UsuarioService } from 'src/app/services/usuario.service';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { Encriptacion } from 'src/app/help/cripto';

@Component({
  selector: 'app-form-usuarios',
  templateUrl: './form-usuarios.component.html',
  styleUrls: ['./form-usuarios.component.css']
})


export class FormUsuariosComponent implements OnInit,OnChanges {

  @Input() titulo:string;
  @Input() modelo:Usuario;
  @Output() guardarCambios = new EventEmitter<Usuario>();
  formUsuario:FormGroup;
  formSend:boolean=false;
  roles:Roles[];
  constructor(private fb:FormBuilder,private formValidatorService:FormValidatorService,
    private router:Router,private userService:UsuarioService,private spinner: NgxSpinnerService) { 
   
  }

  ngOnInit(): void {
    this.formUsuario = this.fb.group({
      id:[''],
      user:['', Validators.required],    
      nombre:['', Validators.required],
      apellido:['', Validators.required],
      direccion:['', Validators.required],
      telefono:['', Validators.required],
      estado:[false],
      rol:['', Validators.required],
      password:[''],
      empresaId:[environment.EmpresaId],
    });
    
   this.roles= DataRoles;
   console.log("Modelo usuario",this.modelo);
      setTimeout(()=>{
        if (this.modelo) {
          console.log("Modelo usuario2",this.modelo);
          this.formUsuario.get('id').setValue(this.modelo.id);
          this.formUsuario.get('user').setValue(this.modelo.user);          
          this.formUsuario.get('nombre').setValue(this.modelo.nombre);
          this.formUsuario.get('apellido').setValue(this.modelo.apellido);
          this.formUsuario.get('direccion').setValue(this.modelo.direccion);
          this.formUsuario.get('telefono').setValue(this.modelo.telefono);
          this.formUsuario.get('estado').setValue(this.modelo.estado);
          this.formUsuario.get('rol').setValue(this.modelo.rol);
                    //this.formUsuario.patchValue(this.modelo);
        }            
      
      },1000)
        
        
      
   
  }

  onSubmit() {    
    this.formSend=true;    
    this.guardarCambios.emit(this.formUsuario.value);
  }

  resetear() {
    Swal.fire({
      title: `Resetear la contraseña con ${this.formUsuario.get('user').value}`,
      showDenyButton: true,      
      confirmButtonText: 'Si',
      denyButtonText: `No`,
    }).then((result) => {      
      if (result.isConfirmed) {
        this.formUsuario.get('password').setValue(Encriptacion.encriptar(this.formUsuario.get('user').value));
        this.userService.changePassword(this.formUsuario.value).subscribe({
          next:(res)=>{
            Swal.fire('Salvada', 'Contraseña reseteada', 'success');
          },
          error:(err)=>{
            console.log("Cambiar contraseña",err);
            Swal.fire('Error', err.message, 'error');
          }
        });        
      } 
    })
  }

  validarCampo(field)
  {
      return this.formValidatorService.campoRequerido(this.formUsuario, field,this.formSend);
  }

  salir() {
    this.router.navigateByUrl('components/usuarios');    
  }
  ngOnChanges(changes: SimpleChanges): void {
    
    setTimeout(()=>{
      for (let propName in changes) {
        if (propName=="modelo" )
        {        
           this.modelo=changes["modelo"].currentValue;

           if (this.modelo){
                this.formUsuario.get('id').setValue(this.modelo.id);
                this.formUsuario.get('user').setValue(this.modelo.user);          
                this.formUsuario.get('nombre').setValue(this.modelo.nombre);
                this.formUsuario.get('apellido').setValue(this.modelo.apellido);
                this.formUsuario.get('direccion').setValue(this.modelo.direccion);
                this.formUsuario.get('telefono').setValue(this.modelo.telefono);
                this.formUsuario.get('estado').setValue(this.modelo.estado);
                this.formUsuario.get('rol').setValue(this.modelo.rol);
           }
          
        }          
      }        
    },1000);    
  }
}
