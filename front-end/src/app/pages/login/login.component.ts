import { Component, OnInit, ElementRef, OnDestroy, AfterViewInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { FormValidatorService } from 'src/app/help/form-validator.service';
import { UsuarioService } from 'src/app/services/usuario.service';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { Encriptacion } from 'src/app/help/cripto';
import { Usuario } from 'src/app/model/usuario.model';

declare var $: any;



@Component({
    selector: 'app-login-cmp',
    templateUrl: './login.component.html'
})

export class LoginComponent implements OnInit, OnDestroy, AfterViewInit{
    test: Date = new Date();
    public loginform:FormGroup
    private toggleButton: any;
    private sidebarVisible: boolean;
    private nativeElement: Node;
    formSend:boolean=false;
    
    constructor(private element: ElementRef,private fb:FormBuilder,private spinner: NgxSpinnerService,
        private usuarioService:UsuarioService,private router:Router,private formValidatorService:FormValidatorService) {
        this.nativeElement = element.nativeElement;
        this.sidebarVisible = false;

        this.loginform=this.fb.group({
            userName:['',[Validators.required]],
            password:['',Validators.required],
            empresaId:[environment.EmpresaId]
        });
    }
    ngAfterViewInit(): void {
        const card = document.getElementsByClassName('card')[0];
        card.classList.remove('card-hidden');
    }

    ngOnInit() {
        var navbar : HTMLElement = this.element.nativeElement;
        this.toggleButton = navbar.getElementsByClassName('navbar-toggle')[0];
        const body = document.getElementsByTagName('body')[0];
        body.classList.add('login-page');
        body.classList.add('off-canvas-sidebar');
        const card = document.getElementsByClassName('card')[0];
        setTimeout(()=> {
            // after 1000 ms we add the class animated to the login/register card
            card.classList.remove('card-hidden');
        }, 700);
    }

    vaidarCampo(field)
    {
        return this.formValidatorService.campoRequerido(this.loginform,field,this.formSend);
    }

    login() {        
        this.formSend=true;   
        if (!this.loginform.valid) return;
        this.spinner.show();         
        this.usuarioService.login(this.loginform.value).subscribe({
            next:(res)=> {
                this.spinner.hide();           
                const pass = Encriptacion.decrypter(res.password);

                if (pass==this.loginform.get('password').value) {
                    const {nombre,apellido,direccion,telefono,user,password, id,rol,empresaId,token,estado} =res;
                    this.usuarioService.usuario=new Usuario(nombre,apellido,direccion,telefono,user,password,id,rol, empresaId,token,estado);
                    if (res.estado==true)
                    {
                        localStorage.removeItem('token');
                        Swal.fire("Error",'El usuario está bloqueado','error');                   
                    } else {this.router.navigateByUrl('/dashboard');}                    
                }
                else {
                    localStorage.removeItem('token');
                    Swal.fire("Error",'La clave no es correcta','error');                   
                }                
                   
            },
            error:(err)=> { 
                this.spinner.hide();
                Swal.fire("Error",err.error.Message,'error');
            },
            complete:()=>{}                         
          });                
    }

    sidebarToggle() {
        var toggleButton = this.toggleButton;
        var body = document.getElementsByTagName('body')[0];
        var sidebar = document.getElementsByClassName('navbar-collapse')[0];
        if (this.sidebarVisible == false) {
            setTimeout(function() {
                toggleButton.classList.add('toggled');
            }, 500);
            body.classList.add('nav-open');
            this.sidebarVisible = true;
        } else {
            this.toggleButton.classList.remove('toggled');
            this.sidebarVisible = false;
            body.classList.remove('nav-open');
        }
    }
    ngOnDestroy(){
      const body = document.getElementsByTagName('body')[0];
      body.classList.remove('login-page');
      body.classList.remove('off-canvas-sidebar');
    }
}
