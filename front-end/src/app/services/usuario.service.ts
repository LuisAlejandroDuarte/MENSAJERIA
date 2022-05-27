import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map, tap,catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { LoginForm } from '../interfaces/login.interface';
import { Observable,of } from 'rxjs';
import { UserChangePassword, Usuario } from '../model/usuario.model';
import { NgxSpinnerService } from 'ngx-spinner';
import { Encriptacion } from '../help/cripto';

const base_url = environment.base_url;
@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  public usuario:Usuario;

  constructor(private http:HttpClient,private router:Router,private spinner: NgxSpinnerService,) { }

  login(formData:LoginForm)
  {
    // const clave = formData.password;             
    // formData.password= Encriptacion.encriptar(clave);    
    // const encriptada =formData.password;
    // console.log('Clave',encriptada);
    return this.http.post(`${base_url}/Login`,formData)
                .pipe(
                  tap((resp:any)=>{
                    console.log(resp);
                    localStorage.setItem('token',resp.token)
                  })
                )
  }

  


    validarToken():Observable<boolean> {
    const token = localStorage.getItem('token') || '';

    if (!token) {
      console.log("Entró");
      //this.router.navigateByUrl('/pages/login');
      return of(false);
    }

    this.spinner.show();

    return  this.http.get(`${base_url}/RenewToken/ReNewToken`,{
      headers: {
        'x-token':token
      }
    }).pipe(
      map((resp:any)=>{
      
         const {nombre,apellido,direccion,telefono,user,password, id,rol,empresaId,token,estado} =resp;
         this.usuario=new Usuario(nombre,apellido,direccion,telefono,user,password,id,rol, empresaId,token,estado);
        localStorage.setItem('token',resp.token);
        this.spinner.hide();
        return true;
      }),

      catchError(error=>{
        this.spinner.hide();
        return of(false);
      })        
    );    
    
  }

  actualizarPerfil(formData:Usuario) {
    formData.empresaId=environment.EmpresaId;
    return this.http.put(`${base_url}/ActualizarUsuario`,formData);
    
  }

  crearUsuario(formData:Usuario) {
    return this.http.post(`${base_url}/CrearUsuario`,formData);
  }

  getRoles() {
    return this.http.get(`${base_url}/Account/Role`);
  }

  getAllUsers(idEmpresa:number)
  {
    return this.http.get(`${base_url}/GetAllUsuarios/${idEmpresa}`);
  }

  getUser(id:string)
  {
    return this.http.get(`${base_url}/GetUsuario/${id}`);
  }

  exit() {
    localStorage.removeItem('token');
    this.router.navigateByUrl('/pages/login');
  }

  changePassword(userChangePassword:Usuario) {
      return this.http.post(`${base_url}/ChangePassword`,userChangePassword);
  }
  
}
