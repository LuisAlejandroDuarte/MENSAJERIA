import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { TablaTurno, Turno } from 'src/app/model/turno.model';
import { TurnoService } from 'src/app/services/turno.service';
import { typeColumns } from 'src/app/shared/datatable/datatable.component';
import Swal from 'sweetalert2';
import * as moment from 'moment';
import { DatatableService } from 'src/app/services/change/datatable.service';
import { TypeTurnos } from '../../../model/turno.model';

@Component({
  selector: 'app-list-turnos',
  templateUrl: './list-turnos.component.html',
  styleUrls: ['./list-turnos.component.css']
})
export class ListTurnosComponent implements OnInit {

  constructor(private turnoServicio:TurnoService,private spinner: NgxSpinnerService,private router:Router,private dataService:DatatableService) { }
  data: Turno[]=[];
  columns: typeColumns[];
  dtOptions: DataTables.Settings = {};
  motos:TablaTurno[]=[];
  dataTabla : {
    columns:any,
    data:any
  };
  ngOnInit(): void {

      this.columns=[          
        { title:'Id',data:'id', visible:false},
        { title:'Pos',data:'posicion'},
        { title:'Placa',data:'placa'},
        { title:'Inicia',data:'inicia',
          render:(data,index,row)=>{
            if (row.inicia!=null)
                return moment(row.inicia).format("HH:mm a");
            else return "";
        }},                       
        { title:'Propietario',data:'nombrePropietario'},           
        { title:'Estado',data:'edit',
          render: (data,index,row)=> {
            if (row.estado==TypeTurnos.Disponible) {
                return `<a class="btn btn-link  edit"  data-item='editar'><span class="badge badge-primary">` + 
                `Disponible</span></a>`
            }
            if (row.estado==TypeTurnos.EnRuta) {
              return `<a class="btn btn-link edit"  data-item='editar'><span class="badge badge-danger">` + 
              `En ruta</span></a>`
          }

        }},
        { title:'Eliminar',data:'eliminar',
          render: (data,index,row)=> {
            if (row.estado==TypeTurnos.Disponible) {
                return `<a class="btn btn-link btn-danger btn-just-icon eliminar"   data-item='eliminar'><i class="material-icons">delete</i></a>`
            }      
            else return ''      
          }}
        
      ];
    this.loadData();
  }

  loadData() 
  {
    setTimeout(()=>{
      this.spinner.show();
      this.data=[];
      this.turnoServicio.getAllEspera().subscribe({
          next:(resp:Turno[])=>{              
              resp.forEach(element => {                 
                
                this.data.push(new TablaTurno(element.id,element.fechaHora,element.empresaId,element.motoId,
                  element.posicion,element.placa,element.nombrePropietario,element.inicia,element.termina, element.estado,'',''));
              });
              this.spinner.hide();
              console.log("Datos desde turnos",this.data);
           //   this.dataService.setData(this.dataTabla={columns:this.columns,data:this.data});
          },
          error:(err)=>{
            this.spinner.hide();
            Swal.fire("Turno",err.error.Message,'error');
          }
      });  
    },500);
  }

  onclickEditar(turno:Turno) {
    console.log("Turnos",turno); 
    if (turno.estado==TypeTurnos.Disponible)
        this.router.navigateByUrl("components/crear-ruta/" + turno.id);
    else if(turno.estado==TypeTurnos.EnRuta)
        this.router.navigateByUrl("components/editar-ruta/" + turno.id);
  }

  onclickEliminar(turno:Turno) {
    console.log("Elimniar",turno); 
    Swal.fire({
      title: `Desea eliminar el turno de ${turno.nombrePropietario}`,
      showDenyButton: true,      
      confirmButtonText: 'Si',
      denyButtonText: `No`,
    }).then((result) => {      
      if (result.isConfirmed) {
        
        this.turnoServicio.delete(turno.id).subscribe({
          next:(res)=>{
            Swal.fire('Eliminado', 'Turno eliminado', 'success');          
              this.loadData();
            // const idremove = this.data.findIndex(x=>x.id==turno.id);
            // console.log("IdBorrar",idremove);
            // this.data.splice(idremove,1);
            // const datos=this.data;

            // console.log("Datos en turno",datos);
            // this.data=datos;
          },
          error:(err)=>{            
            Swal.fire('Error', err.message, 'error');
          }
        });        
      } 
    })
  }

  onCrearTurno() {
    this.router.navigateByUrl('components/crear-turno');    
  }

}
