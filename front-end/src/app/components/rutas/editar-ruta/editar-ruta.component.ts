import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { RutaService } from 'src/app/services/ruta.service';
import { TurnoService } from 'src/app/services/turno.service';
import { Ruta } from 'src/app/model/ruta.model';
import Swal from 'sweetalert2';
import { Turno } from 'src/app/model/turno.model';

@Component({
  selector: 'app-editar-ruta',
  templateUrl: './editar-ruta.component.html',
  styleUrls: ['./editar-ruta.component.css']
})
export class EditarRutaComponent implements OnInit {

  ruta:Ruta;
  turno:Turno;

  constructor(private activatedRoute: ActivatedRoute,private rutaService:RutaService,private turnoService:TurnoService,
    private spinner: NgxSpinnerService,private router:Router) { }


  ngOnInit(): void {
    this.spinner.show();
    this.activatedRoute.params.subscribe(params=>{
       this.rutaService.getRutaByTurno(params.turnoId).subscribe({
          next:(resp:Ruta)=>{
            setTimeout(()=>{
              this.ruta=resp;

              this.turnoService.get(params.turnoId).subscribe({
                next:(result:Turno)=>{
                  setTimeout(()=>{
                    this.turno=result;
                    this.spinner.hide();
                    console.log("Ruta",resp);
                    console.log("Turno",result);
                  },1000);                  
                },
                error:(err)=>{
                  this.spinner.hide();
                  Swal.fire("Turnos",err.message,"error");
                }                
              });              
            },500)            
          },
          error:(err)=>{
            this.spinner.hide();
            Swal.fire("Rutas",err.message,"error");
          }
       });
    });
  }

  save(ruta:Ruta) {
    console.log("Salvar ruta",ruta);
    this.spinner.show();
    this.rutaService.editar(ruta).subscribe({
      next:(resp:Ruta)=>{
      this.spinner.hide();
        this.router.navigateByUrl('components/turnos');
      },
      error:(err)=>{
        this.spinner.hide();
        Swal.fire("Rutas",err.message,"error");
      }
    });

  }
}
