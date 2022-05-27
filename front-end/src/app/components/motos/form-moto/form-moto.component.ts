import { Component, EventEmitter, Input, OnInit, Output,AfterViewInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FormValidatorService } from 'src/app/help/form-validator.service';
import { Moto } from 'src/app/model/moto.model';
import { Propietario } from 'src/app/model/propietario.model';
import { PropietarioService } from 'src/app/services/propietario.service';
import Swal from 'sweetalert2';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import { Paginator } from 'src/app/model/paginator.model';

@Component({
  selector: 'app-form-moto',
  templateUrl: './form-moto.component.html',
  styleUrls: ['./form-moto.component.css']
})
export class FormMotoComponent implements OnInit,AfterViewInit {

  listPropietarios:Propietario[]=[];
  @Input() title:string;
  formSend:boolean;
  @Input() modelo:Moto;
  @Output() guardarCambios = new EventEmitter<Moto>();
  formMoto:FormGroup;

  constructor(private fb:FormBuilder,private formValidatorService:FormValidatorService,
    private propietarioService:PropietarioService,private spinner: NgxSpinnerService, private router:Router) { }

  ngOnInit(): void {
    this.formSend=false;
    this.formMoto=this.fb.group({
      id:[0],
      placa:['',[Validators.required,Validators.minLength(6)]],
      propietarioId:['',[Validators.required]],
      estado:[false,[Validators.required]]
    });
   

  }

  ngAfterViewInit(): void {

    setTimeout(()=>{           
    this.spinner.show();    
    this.propietarioService.getAll().subscribe({
      next:(resp:Propietario[]) =>{
        resp.forEach(x=>x.nombre=x.nombre + ' ' + x.apellido);
          this.listPropietarios=resp.filter(x=>x.estado==false);
          this.spinner.hide();

          setTimeout(()=>{           
            if (this.modelo)
            {
              this.formMoto.patchValue(this.modelo);
            }
          },1000);
      },
      error:(err)=>{
        this.spinner.hide();
        Swal.fire("Motos","Error al cargar los propietarios");
        
      }
    });
    },100)
  }

  onSubmit() {
    this.formSend=true;
    this.guardarCambios.emit(this.formMoto.value);
  }

  validarCampo(field)
  {
    return this.formValidatorService.campoRequerido(this.formMoto, field,this.formSend);
  }
  salir() {
    this.router.navigateByUrl('components/motos');
  }
}
