import { Component, EventEmitter, Input, OnInit, Output, OnChanges,  AfterViewInit, OnDestroy,  ChangeDetectorRef, SimpleChanges } from '@angular/core';
import { DatatableService } from 'src/app/services/change/datatable.service';
import { environment } from 'src/environments/environment';
import {  NgxSpinnerService } from 'ngx-spinner';

declare const $: any;

@Component({
  selector: 'app-datatablenet',
  templateUrl: './datatable.component.html',
  styleUrls: ['./datatable.component.css']
})
export class DatatableNetComponent implements  AfterViewInit,OnInit,OnDestroy,OnChanges {


  showTable:boolean=false;  
  tabla:any;
  @Input() data: any;
  @Input() columns: any;
  @Input() host: string;
  @Output() onEditClick =new EventEmitter<number>();
  @Output() onEliminarClick =new EventEmitter<number>();


  constructor(private dataService:DatatableService, private readonly chRef: ChangeDetectorRef,private spinner:NgxSpinnerService) { }

  ngOnInit(): void {            
    this.spinner.hide();    
  }
  
  onClicEdit(data:any) {
    this.onEditClick.emit(data);
 }

 onClicEliminar(data:any) {
  this.onEliminarClick.emit(data);

}
ngAfterViewInit(): void {
  
 
  setTimeout(()=>{
 
    console.log("ColumnViewInit",this.columns);
    console.log("DataViewInit",this.data);

    this.tabla= $('#datatables').DataTable({
      pagingType: "full_numbers",
      lengthMenu: [
        [10, 25, 50, -1],
        [10, 25, 50, "Todos"]
      ],       
      dom: "lfrtip",      
      columns: this.columns,
      responsive: true,
      serverSide:true,  
      filter: true,  
      paging: true,            
      ajax: {
        type: "POST",
        url: this.host,      
        headers: {"Authorization": `Bearer ${localStorage.getItem('token')}`},        
        data: (data) => {           
             data.empresaId=environment.EmpresaId;             
             console.log("DataPro",data);
        },
        complete:(data)=>{
          console.log("Complete",data);
        }    
    },
      deferRender: true,
      scrollY:     200,
      scroller:    true,
      language: {
        search: "_INPUT_",
        searchPlaceholder: "Buscar",
        lengthMenu: "Mostar _MENU_ registros por página",
        zeroRecords: "No hay datos",
        info: "Mostrando _PAGE_ de _PAGES_",          
        infoEmpty: "Mostrando 0 a 0 de 0 registros",
        infoFiltered: "(filtered from _MAX_ total registros)",
        paginate: {
          first:      "Primero",
          last:       "Último",
          next:       "Próximo",
          previous:   "Anterior"
        },
      },          

  rowCallback: (row: Node, data: any[] | Object, index: number) => {     
      const self = this;   
      $('td', row).off('click');
      $('td', row).on('click', (evt) => {
        const  accion=$(evt.target).closest('td').find('a').attr("data-item");
          if (accion) {
            switch (accion) {
              case 'editar':
                self.onClicEdit(data);   
                break;
              case 'eliminar' :
                self.onClicEliminar(data);
                break;
              default:
                break;
            }
          }                                 
      });        
      return row;
    }    
  });    
  
},500); 
}

ngOnDestroy(): void { 
  this.tabla.destroy();
  $('#datatables').empty(); 
}

ngOnChanges(changes: SimpleChanges): void {    

  setTimeout(()=>{
      for (let propName in changes) {
        if (propName=="data" && this.tabla)
        {        
          const datos =changes[propName].currentValue;
          $('#datatables').DataTable().clear(); 
          $('#datatables').DataTable().rows.add(datos);
          $('#datatables').DataTable().draw(); 
          console.log("Changes",datos);
        }          
      }        
    },1000);
  }    
}

export interface typeColumns {
  title:string,
  data:string,
  visible?:boolean,
  orderable?:boolean,
  width?:number,
  render?:Function  
}
