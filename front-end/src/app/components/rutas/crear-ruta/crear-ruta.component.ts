import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { RutaService } from 'src/app/services/ruta.service';
import { Turno } from 'src/app/model/turno.model';
import { TurnoService } from 'src/app/services/turno.service';
import Swal from 'sweetalert2';
import { Ruta } from 'src/app/model/ruta.model';

@Component({
  selector: 'app-crear-ruta',
  templateUrl: './crear-ruta.component.html',
  styleUrls: ['./crear-ruta.component.css']
})


export class CrearRutaComponent implements OnInit {
  turno:Turno;
  constructor(private activatedRoute: ActivatedRoute,private rutaService:RutaService,private turnoService:TurnoService,
    private spinner: NgxSpinnerService,private router:Router) { }

  ngOnInit(): void {
    this.spinner.show();
    this.activatedRoute.params.subscribe(params=>{
       this.turnoService.get(params.turnoId).subscribe({
          next:(resp:Turno)=>{
            setTimeout(()=>{
              this.turno=resp;
              this.spinner.hide();
              console.log("Turno",resp);
            })            
          },
          error:(err)=>{
            this.spinner.hide();
            Swal.fire("Rutas",err.message,"error");
          }
       });
    });
  }
  save(ruta:Ruta) {
    this.spinner.show();
    this.rutaService.crear(ruta).subscribe({
        next:(resp:Ruta)=>{
          this.spinner.hide();
          Swal.fire("RUTA","Ruta creada","success");
          this.router.navigateByUrl("components/turnos");
        },
        error:(err)=>{
          this.spinner.hide();
          Swal.fire("RUTA",err.message,"error");
        }
    });
  }
}
