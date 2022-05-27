import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Moto } from '../model/moto.model';

const base_url = environment.base_url;
@Injectable({
  providedIn: 'root'
})
export class MotoService {

  constructor(private http:HttpClient,private router:Router) { }

  
    getAll(){
        return this.http.get(`${base_url}/GetAllmoto/${environment.EmpresaId}`);
    }

    getMoto(id:number)
    {
      return this.http.get(`${base_url}/GetMoto/${id}`);
    }

    editarMoto(moto:Moto)
    {      
      return this.http.put(`${base_url}/EditarMoto/`,moto);
    }

    crearMoto(moto:Moto)
    {      
      return this.http.post(`${base_url}/CrearMoto`,moto);
    }
}
