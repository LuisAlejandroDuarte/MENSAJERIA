import { Component, Input, OnInit, Output, EventEmitter  } from '@angular/core';

@Component({
  selector: 'app-list-tabla',
  templateUrl: './list-tabla.component.html',
  styleUrls: ['./list-tabla.component.css']
})
export class ListTablaComponent implements OnInit {
  @Input() dataSource:any;
  displayedColumns:any;
  @Input() columnas:any;
  @Output() onEditClick =new EventEmitter<string>();
  

  constructor() { }

  ngOnInit(): void {

    var visibles = this.columnas.filter(c=>c.visible==true);
    this.displayedColumns=visibles.map(c=>c.columnDef);
  }

  Select(id) {
    this.onEditClick.emit(id);
  }

}
