import { Component, OnInit } from '@angular/core';
import PerfectScrollbar from 'perfect-scrollbar';
import { Usuario } from '../model/usuario.model';
import { UsuarioService } from '../services/usuario.service';

declare const $: any;

//Metadata
export interface RouteInfo {
    path: string;
    title: string;
    type: string;
    icontype: string;
    collapse?: string;
    children?: ChildrenItems[];
}

export interface ChildrenItems {
    path: string;
    title: string;
    ab: string;
    type?: string;
    visible?:boolean;
}

//Menu Items

export const ROUTESPERFIL : RouteInfo[]= [{
        path:'/pages',
        title:'pages',
        type:'link',
        icontype: '',
        collapse: 'collapseExample',
        children: [
            {path:'user',title:'Perfil', ab:'face'},
            {path:'cambioclave',title:'Cambio clave', ab:'lock'}         
        ]
}];

export const ROUTES: RouteInfo[] = [{
        path: '/dashboard',
        title: 'Principal',
        type: 'link',
        icontype: 'dashboard'
    },{
        path: '/components',
        title: 'Archivo',
        type: 'sub',
        icontype: 'apps',
        collapse: 'components',
        children: [
            {path: 'usuarios', title: 'Usuarios', ab:'UR'} ,       
            {path: 'propietario', title: 'Propietarios', ab:'PR'},
            {path: 'motos', title: 'Motos', ab:'MT'},
            {path: 'turnos', title: 'Turnos', ab:'TU'},
            {path: 'rutas', title: 'Rutas', ab:'RT'},
        ]
    
    },{
        path: '/reportes',
        title: 'Reporte',
        type: 'sub',
        icontype: 'content_paste',
        collapse: 'reportes',
        children: [
            {path: 'factura-servicio', title: 'Servicios', ab:'S'}
            // {path: 'lecturas', title: 'Lecturas', ab:'EF'},
            // {path: 'deudas', title: 'deudas', ab:'VF'},
            // {path: 'notacredito', title: 'Nota crédito', ab:'W'},
            // {path: 'notadebito', title: 'Nota Débito', ab:'W'}
        ]
    }
    //     path: '/tables',
    //     title: 'Tables',
    //     type: 'sub',
    //     icontype: 'grid_on',
    //     collapse: 'tables',
    //     children: [
    //         {path: 'regular', title: 'Regular Tables', ab:'RT'},
    //         {path: 'extended', title: 'Extended Tables', ab:'ET'},
    //         {path: 'datatables.net', title: 'Datatables.net', ab:'DT'}
    //     ]
    // },{
    //     path: '/maps',
    //     title: 'Maps',
    //     type: 'sub',
    //     icontype: 'place',
    //     collapse: 'maps',
    //     children: [
    //         {path: 'google', title: 'Google Maps', ab:'GM'},
    //         {path: 'fullscreen', title: 'Full Screen Map', ab:'FSM'},
    //         {path: 'vector', title: 'Vector Map', ab:'VM'}
    //     ]
    // },{
    //     path: '/widgets',
    //     title: 'Widgets',
    //     type: 'link',
    //     icontype: 'widgets'

    // },{
    //     path: '/charts',
    //     title: 'Charts',
    //     type: 'link',
    //     icontype: 'timeline'

    // },{
    //     path: '/calendar',
    //     title: 'Calendar',
    //     type: 'link',
    //     icontype: 'date_range'
    // }
    // ,{
    //     path: '/pages',
    //     title: 'Pages',
    //     type: 'sub',
    //     icontype: 'image',
    //     collapse: 'pages',
    //     children: [
    //         {path: 'pricing', title: 'Pricing', ab:'P'},
    //         {path: 'timeline', title: 'Timeline Page', ab:'TP'},
    //         {path: 'login', title: 'Login Page', ab:'LP'},
    //         {path: 'register', title: 'Register Page', ab:'RP'},
    //         {path: 'lock', title: 'Lock Screen Page', ab:'LSP'},
    //         {path: 'user', title: 'Mi Perfil', ab:'UP'}
    //     ]
    // }
];
@Component({
    selector: 'app-sidebar-cmp',
    templateUrl: 'sidebar.component.html',
})

export class SidebarComponent implements OnInit {
    public menuItems: any[];
    public menuPerfil:any[];
    ps: any;
    usuario:Usuario;

    constructor(private user:UsuarioService) {
        this.usuario=user.usuario;
    }

    isMobileMenu() {
        if ($(window).width() > 991) {
            return false;
        }
        return true;
    };

    ngOnInit() {
        this.menuItems = ROUTES.filter(menuItem => menuItem);
        this.menuPerfil = ROUTESPERFIL.filter(menuItem => menuItem);
        if (window.matchMedia(`(min-width: 960px)`).matches && !this.isMac()) {
            const elemSidebar = <HTMLElement>document.querySelector('.sidebar .sidebar-wrapper');
            this.ps = new PerfectScrollbar(elemSidebar);
        }
    }
    updatePS(): void  {
        if (window.matchMedia(`(min-width: 960px)`).matches && !this.isMac()) {
            this.ps.update();
        }
    }
    isMac(): boolean {
        let bool = false;
        if (navigator.platform.toUpperCase().indexOf('MAC') >= 0 || navigator.platform.toUpperCase().indexOf('IPAD') >= 0) {
            bool = true;
        }
        return bool;
    }
    onClicSalir() {
        this.user.exit();
    }
}
