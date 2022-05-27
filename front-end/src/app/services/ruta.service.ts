import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Ruta } from '../model/ruta.model';
import { Turno } from '../model/turno.model';


const base_url = environment.base_url;
@Injectable({
  providedIn: 'root'
})
export class RutaService {

  constructor(private http:HttpClient,private router:Router) { }


  getAll(){
    return this.http.get(`${base_url}/GetAllDateRuta/${environment.EmpresaId}`);
  }

  crear(ruta:Ruta){
    
    return this.http.post(`${base_url}/CrearRuta`,ruta);
  }

  editar(ruta:Ruta){
    
    return this.http.put(`${base_url}/EditarRuta`,ruta);
  }

  getRutaByTurno(turnoId:number){
    return this.http.get(`${base_url}/GetRutaByTurno/${turnoId}`);
  }

}
