import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Moto } from 'src/app/model/moto.model';
import { MotoService } from 'src/app/services/moto.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-crear-moto',
  templateUrl: './crear-moto.component.html',
  styleUrls: ['./crear-moto.component.css']
})
export class CrearMotoComponent implements OnInit {

  constructor(private spinner: NgxSpinnerService,private motoService:MotoService,private router:Router) { }

  ngOnInit(): void {
  }

  save(moto:Moto) {
    this.spinner.show(); 
   console.log("Crear",moto);
    this.motoService.crearMoto(moto).subscribe({
      next:(resp:Moto)=>{
        this.spinner.hide();    
        Swal.fire("Moto","Guardado","success");        
        this.router.navigateByUrl('components/motos');
      },
      error:(err)=>{
        this.spinner.hide();            
        Swal.fire("Moto",err.message,'error');
      }
    })
  }  
}
