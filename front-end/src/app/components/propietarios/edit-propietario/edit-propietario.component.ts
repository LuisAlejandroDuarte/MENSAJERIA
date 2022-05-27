import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Propietario } from 'src/app/model/propietario.model';
import { PropietarioService } from 'src/app/services/propietario.service';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-edit-propietario',
  templateUrl: './edit-propietario.component.html',
  styleUrls: ['./edit-propietario.component.css']
})
export class EditPropietarioComponent implements OnInit {

  modelo:Propietario;

  constructor(private activatedRoute: ActivatedRoute,private propietarioioService:PropietarioService,private spinner: NgxSpinnerService) { }

  ngOnInit(): void {

    this.spinner.show();    
    this.activatedRoute.params.subscribe((params)=>{
      this.propietarioioService.getPropietario(params.id).subscribe({
        next:(res:any)=>{  
          this.spinner.hide();
          this.modelo=res;
          this.modelo.id=res.id;     
          console.log("ModeloEdit",this.modelo);             
        },
        error:(err)=>{
            this.spinner.hide();
            Swal.fire("Propietario",err.error.Message,'error');
        }  
      })
    });       

  }

  save(propietario:Propietario) {
    this.spinner.show();   
    this.propietarioioService.editarPropietario(propietario).subscribe({
      next:(resp)=>{
        this.spinner.hide();    
        Swal.fire("Propietario","Actualizado","success");
      },
      error:(err)=>{
        this.spinner.hide();     
        console.log(err);       
        Swal.fire("Propietario",err.error.Message,'error');
      }
    })
  }
}


