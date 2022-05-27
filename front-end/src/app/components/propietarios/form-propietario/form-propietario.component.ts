import { ChangeDetectorRef, Component, EventEmitter, Input, OnInit, Output, OnChanges, SimpleChanges } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FormValidatorService } from 'src/app/help/form-validator.service';
import { Propietario } from '../../../model/propietario.model';

@Component({
  selector: 'app-form-propietario',
  templateUrl: './form-propietario.component.html',
  styleUrls: ['./form-propietario.component.css']
})
export class FormPropietarioComponent implements OnInit,OnChanges {

  @Input() titulo:string;
  @Input() modelo:Propietario;
  @Output() guardarCambios = new EventEmitter<Propietario>();
  formPropietario:FormGroup;
  formSend:boolean;

  constructor(private fb:FormBuilder,private formValidatorService:FormValidatorService, private router:Router) {     

  }

  ngOnInit(): void {
    
    this.formSend=false;
    this.formPropietario =this.fb.group({
      id:[0],
      identificacion:['',[Validators.required]],
      nombre:['',[Validators.required]],
      apellido:['',[Validators.required]],
      telefono:['',[Validators.required]],
      direccion:['',[Validators.required]],
      estado:[false,[Validators.required]],

    });
    setTimeout(()=>{
      console.log("Modelo",this.modelo);
      if (this.modelo)
      {
        this.formPropietario.patchValue(this.modelo);
      }
    },500);
    
  }

  onSubmit() {
    this.formSend=true;
    this.guardarCambios.emit(this.formPropietario.value);
  }

  salir() {
    this.router.navigateByUrl('components/propietario');    
  }


  validarCampo(field)
  {
      return this.formValidatorService.campoRequerido(this.formPropietario, field,this.formSend);
  }

  ngOnChanges(changes: SimpleChanges): void {
    
    setTimeout(()=>{
      for (let propName in changes) {
        if (propName=="modelo" )
        {        
           this.modelo=changes["modelo"].currentValue;

           if (this.modelo){
            this.formPropietario.patchValue(this.modelo);
           }
          
        }          
      }        
    },1000);    
  }

}
