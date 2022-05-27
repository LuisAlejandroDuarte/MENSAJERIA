import { Component, EventEmitter, Input, OnInit, Output, AfterViewInit } from '@angular/core';
import { Turno } from 'src/app/model/turno.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Moto } from 'src/app/model/moto.model';
import { TurnoService } from 'src/app/services/turno.service';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';
import { FormValidatorService } from 'src/app/help/form-validator.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-form-turno',
  templateUrl: './form-turno.component.html',
  styleUrls: ['./form-turno.component.css']
})
export class FormTurnoComponent implements OnInit {
  @Input() titulo:string;
  @Output() guardarCambios = new EventEmitter<Turno>();

  formTurno:FormGroup;
  listMotos:Moto[]=[];
  formSend:boolean;
  modelo:Turno;
  constructor(private fb:FormBuilder,private turnoService:TurnoService,private spiner:NgxSpinnerService,
    private router:Router,private formValidatorService:FormValidatorService) { }

  ngOnInit(): void {
    this.formSend=false;
    this.formTurno = this.fb.group({
      motoId:['',[Validators.required]]
    });
    
  }

  ngAfterViewInit():void {
    this.spiner.show();
    this.turnoService.motoDisponible().subscribe({
        next:(resp:Moto[])=>{
          setTimeout(()=>{
            this.spiner.hide();
            this.listMotos =resp;
            console.log("ListMotos",resp);
          },1000);          
        },
        error:(err)=>{
          this.spiner.hide();
          Swal.fire("Motos",err.message,'error');
        }
    });
  }

  onSubmit()
  {
    this.formSend=true;
    this.guardarCambios.emit(this.formTurno.value);
  }

  validarCampo(field)
  {
      return this.formValidatorService.campoRequerido(this.formTurno, field,this.formSend);
  }
  salir() {
    this.router.navigateByUrl('components/turnos');
  }

}
