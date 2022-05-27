import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Turno, TypeTurnos } from 'src/app/model/turno.model';
import { TurnoService } from 'src/app/services/turno.service';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-crear-turno',
  templateUrl: './crear-turno.component.html',
  styleUrls: ['./crear-turno.component.css']
})
export class CrearTurnoComponent implements OnInit {

  constructor(private router:Router,private turnoService:TurnoService,private spinner:NgxSpinnerService) { }

  ngOnInit(): void {
  }

  save(turno:Turno)
  {

    console.log("Turno",turno);
    this.spinner.show();
    turno.estado=TypeTurnos.Disponible;
    this.turnoService.crear(turno).subscribe({
      next:(resp:Turno[])=>{              
        this.router.navigateByUrl('components/turnos');
        this.spinner.hide();
    },
    error:(err)=>{
      this.spinner.hide();
      Swal.fire("Turno",err.message,'error');
    }
    });

  }

}
