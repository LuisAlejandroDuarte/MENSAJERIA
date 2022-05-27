import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Encriptacion } from 'src/app/help/cripto';
import { Propietario } from 'src/app/model/propietario.model';
import { PropietarioService } from 'src/app/services/propietario.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-crear-propietario',
  templateUrl: './crear-propietario.component.html',
  styleUrls: ['./crear-propietario.component.css']
})
export class CrearPropietarioComponent implements OnInit {

  constructor(private spinner: NgxSpinnerService,private propietarioService:PropietarioService,private router:Router) { }

  ngOnInit(): void {
    
  }
  save(propietario:Propietario) {
    this.spinner.show(); 
   console.log("Crear",propietario);
    this.propietarioService.crearPropietario(propietario).subscribe({
      next:(resp:Propietario)=>{
        this.spinner.hide();    
        Swal.fire("Propietario","Guardado","success");
        console.log("Propi",resp);
        this.router.navigateByUrl('components/propietario');
      },
      error:(err)=>{
        this.spinner.hide();            
        Swal.fire("Propietario",err.message,'error');
      }
    })
  }

}
