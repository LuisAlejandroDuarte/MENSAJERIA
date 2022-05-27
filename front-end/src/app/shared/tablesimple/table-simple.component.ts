import { Component, EventEmitter, Input, OnInit, Output,AfterViewInit,OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-table-simple',
  templateUrl: './table-simple.component.html',
  styleUrls: ['./table-simple.component.css']
})
export class TableSimpleComponent implements OnInit,AfterViewInit,OnChanges {

  
  tabla:DataTables.Api;
  @Input() data: any;
  @Input() columns: any;
  @Output() onEditClick =new EventEmitter<number>();
  @Output() onEliminarClick =new EventEmitter<number>();


  constructor() { }

  ngOnInit(): void {
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
        data:this.data,
        responsive: true,                                        
        deferRender: true,
        scrollY:     '200',        
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
