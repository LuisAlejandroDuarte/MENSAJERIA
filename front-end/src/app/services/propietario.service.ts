
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { environment } from 'src/environments/environment';
import { Propietario } from 'src/app/model/propietario.model';
import { Paginator } from '../model/paginator.model';

const base_url = environment.base_url;
@Injectable({
  providedIn: 'root'
})

export class PropietarioService {

    constructor(private http:HttpClient,private router:Router,private spinner: NgxSpinnerService) { }

    getAll(){
      
        return this.http.get(`${base_url}/GetAllPropietarios/${environment.EmpresaId}`);
    }

    getPropietario(id:number)
    {
      return this.http.get(`${base_url}/GetPropietario/${id}`);
    }

    editarPropietario(propietario:Propietario)
    {
      propietario.empresaId=environment.EmpresaId;
      return this.http.put(`${base_url}/EditarPropietario/`,propietario);
    }

    crearPropietario(propietario:Propietario)
    {
      propietario.empresaId=environment.EmpresaId;
      console.log("CrearServicio",propietario);
      return this.http.post(`${base_url}/CrearPropietario/`,propietario);
    }

}