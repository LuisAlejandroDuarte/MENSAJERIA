
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { environment } from 'src/environments/environment';

const base_url = environment.base_url;
@Injectable({
  providedIn: 'root'
})

export class ReporteService {

    constructor(private http:HttpClient,private router:Router,private spinner: NgxSpinnerService) { }

    getFacturaServicio(){
        return this.http.get(`${base_url}/GetReporteFactura/${environment.EmpresaId}`);
    }

}