import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Moto } from 'src/app/model/moto.model';
import { MotoService } from 'src/app/services/moto.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-edit-moto',
  templateUrl: './edit-moto.component.html',
  styleUrls: ['./edit-moto.component.css']
})
export class EditMotoComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute,private motoService:MotoService,private spinner: NgxSpinnerService) { }

  modelo:Moto;

  ngOnInit(): void {

    this.activatedRoute.params.subscribe(params=>{
      this.motoService.getMoto(params.id).subscribe({
        next:(resp:Moto)=>{
          this.modelo=resp;
          console.log("MOTO",resp);
        },

      });
    })

  }

  save(moto:Moto) {
    this.spinner.show();   
    this.motoService.editarMoto(moto).subscribe({
      next:(resp:Moto)=>{
        this.spinner.hide();    
        Swal.fire("Moto","Actualizado","success");
      },
      error:(err)=>{
        this.spinner.hide();     
        console.log(err);       
        Swal.fire("Moto",err.error.Message,'error');
      }
    })
  }
}


