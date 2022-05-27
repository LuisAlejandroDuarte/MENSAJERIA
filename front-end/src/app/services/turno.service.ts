import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Turno } from '../model/turno.model';


const base_url = environment.base_url;
@Injectable({
  providedIn: 'root'
})
export class TurnoService {

  constructor(private http:HttpClient,private router:Router) { }

  
  getAllEspera(){
    return this.http.get(`${base_url}/ObtenerTurnosEspera/${environment.EmpresaId}`);
  }

  crear(turno:Turno){
    turno.empresaId=environment.EmpresaId;
    return this.http.post(`${base_url}/CrearTurno`,turno);
  }

  editar(turno:Turno){
    turno.empresaId=environment.EmpresaId;
    return this.http.put(`${base_url}/EditarTurno`,turno);
  }

  motoDisponible() {
      return  this.http.get(`${base_url}/GetMotoDisponible/${environment.EmpresaId}`);
  }

  get(id:number)
  {
    return  this.http.get(`${base_url}/GetTurno/${id}`);
  }

  delete(id:number) {
    return  this.http.delete(`${base_url}/DeleteTurno/${id}`);
  }
  
}
