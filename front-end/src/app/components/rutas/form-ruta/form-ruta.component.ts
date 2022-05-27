import { Component, EventEmitter, Input, OnInit, Output, AfterViewInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Ruta } from 'src/app/model/ruta.model';
import { Turno } from 'src/app/model/turno.model';
import { RutaService } from 'src/app/services/ruta.service';
import Swal from 'sweetalert2';
import { NgxSpinnerService } from 'ngx-spinner';
import * as moment from 'moment';
import { Router } from '@angular/router';
import { FormValidatorService } from 'src/app/help/form-validator.service';
import { TurnoService } from 'src/app/services/turno.service';
import { TypeTurnos } from '../../../model/turno.model';


@Component({
  selector: 'app-form-ruta',
  templateUrl: './form-ruta.component.html',
  styleUrls: ['./form-ruta.component.css']
})
export class FormRutaComponent implements OnInit,AfterViewInit {

  @Input() title:string;
  @Input() turno:Turno;
  @Input() ruta:Ruta;
  @Output() saveChanges = new EventEmitter<Ruta>();

  modelo:Turno;

  formRuta:FormGroup;
  formSend:boolean=false;

  constructor(private fb:FormBuilder,private rutaService:RutaService,private snipper:NgxSpinnerService, private router:Router,
    private validarCampos:FormValidatorService,private turnoService:TurnoService) { }

  ngOnInit(): void {
    
    this.formRuta = this.fb.group({
      id:[0],
      turnoId:[''],
      inicia:[''],
      termina:[''],
      valor:[0],
      estado:[''],
      destino:['',[Validators.required]],
      telefono:['',[Validators.required]],
      observacion:['']
    });



    
  }

  ngAfterViewInit():void {
    setTimeout(()=>{
      console.log("ngChangeturno",this.turno)
      console.log("ngChangeRuta",this.ruta)
      if (this.turno)
      {
          this.modelo=this.turno;          
      }
      if (this.ruta) {
        this.formRuta.get('destino').setValue(this.ruta.destino);
        this.formRuta.get('telefono').setValue(this.ruta.telefono);
        this.formRuta.get('inicia').setValue(moment(this.ruta.inicia).format("HH:mm a"));
        this.formRuta.get('observacion').setValue(this.ruta.observacion);
        this.formRuta.get('valor').setValue(this.ruta.valor);
      }

    },1000);
  }

  onSubmit() {
      if (!this.ruta) {
        this.snipper.show();
        const ruta = new Ruta(0,this.turno.id,moment(Date.now()).toDate(),null,this.formRuta.get('destino').value,
                    this.formRuta.get('telefono').value,this.formRuta.get('valor').value,false,'','',
                    this.formRuta.get('observacion').value);
        console.log("Rutas",ruta);

        this.saveChanges.emit(ruta);      
      }
      else {
        this.ruta.destino= this.formRuta.get('destino').value;
        this.ruta.telefono= this.formRuta.get('telefono').value;
        this.ruta.observacion=this.formRuta.get('observacion').value;
        this.ruta.valor=this.formRuta.get('valor').value;
        this.saveChanges.emit(this.ruta);      
      }
  }

  validarCampo(field:string)
  {
    this.validarCampos.campoRequerido(this.formRuta,field, this.formSend);
  }

  terminar() {
      if (!this.formRuta.get('valor').value) {
        Swal.fire("Rutas","Falta el Valor");
        return;
      }

      Swal.fire({
        title: `Terminar la ruta de  ${this.turno.nombrePropietario}`,
        showDenyButton: true,      
        confirmButtonText: 'Si',
        denyButtonText: `No`,
      }).then((result) => {      
        if (result.isConfirmed) {
         this.ruta.destino= this.formRuta.get('destino').value;
         this.ruta.telefono=this.formRuta.get('telefono').value;         
         this.ruta.observacion=this.formRuta.get('observacion').value;
         this.ruta.estado=true;             
         this.ruta.termina=moment(Date.now()).add(-5,"hours").utc().toDate();
         this.ruta.valor=this.formRuta.get('valor').value;         
         console.log("Termiona ruta",this.ruta);              
          console.log("Crear turno",this.turno);     
        this.snipper.show();
         this.rutaService.editar(this.ruta).subscribe({
          next:(res)=>{
            this.turno.estado=TypeTurnos.Terminado;                              
            this.turnoService.editar(this.turno).subscribe({
                next:(respTurno:Turno)=>{
                  this.turno.id=0;
                  this.turno.estado=TypeTurnos.Disponible;    
                  this.turnoService.crear(this.turno).subscribe({
                    next:(resp)=>{
                      this.snipper.hide();
                      this.router.navigateByUrl('components/turnos');    
                    },
                    error:(err)=>{
                      this.snipper.hide();
                      Swal.fire('Rutas', err.message, 'error');
                    }              
                  });
                },
                error:(err)=>{
                    this.snipper.hide();
                    Swal.fire('Rutas', err.message, 'error');
                }
            });

            
          },
          error:(err)=>{            
            this.snipper.hide();
            Swal.fire('Rutas', err.message, 'error');
          }
        });        
        }                 
      }); 
  }
  salir() {
    this.router.navigateByUrl('components/turnos');    
  }

}
