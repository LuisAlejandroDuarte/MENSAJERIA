import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DatatableService {
  
  dataTabla:{
    columns:any,
    data:any    
  }


  constructor() { }

  public data = new Subject<any>();
    data$ = this.data.asObservable();

    setData(data: any) {
        this.data.next(data);
    }
}
