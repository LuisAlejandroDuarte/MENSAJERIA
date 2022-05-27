import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { UsuarioService } from '../services/usuario.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private usuarioService:UsuarioService,private router:Router,private spinner:NgxSpinnerService) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot) {
      console.log("Guards");    
      this.spinner.show();
      return  this.usuarioService.validarToken()      
      .pipe(
        tap(estaAutenticado=>{
          console.log("estaautenticado",estaAutenticado);
          this.spinner.hide();
          if (!estaAutenticado ) {           
            this.router.navigateByUrl('/pages/login');          
          }          
        })
      );      
  }  
}
