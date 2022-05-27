import { EditPropietarioComponent } from './propietarios/edit-propietario/edit-propietario.component';
import { ListUsuariosComponent } from './usuarios/list-usuarios/list-usuarios.component';
import { Routes } from '@angular/router';

import { ButtonsComponent } from './buttons/buttons.component';
import { GridSystemComponent } from './grid/grid.component';
import { IconsComponent } from './icons/icons.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { PanelsComponent } from './panels/panels.component';
import { SweetAlertComponent } from './sweetalert/sweetalert.component';
import { TypographyComponent } from './typography/typography.component';
import { EditarUsuariosComponent } from './usuarios/editar-usuarios/editar-usuarios.component';
import { CrearUsuariosComponent } from './usuarios/crear-usuarios/crear-usuarios.component';
import { ListPropietariosComponent } from './propietarios/list-propietarios/list-propietarios.component';
import { CrearPropietarioComponent } from './propietarios/crear-propietario/crear-propietario.component';
import { ListMotosComponent } from './motos/list-motos/list-motos.component';
import { EditMotoComponent } from './motos/edit-moto/edit-moto.component';
import { CrearMotoComponent } from './motos/crear-moto/crear-moto.component';
import { ListTurnosComponent } from './turnos/list-turnos/list-turnos.component';
import { CrearTurnoComponent } from './turnos/crear-turno/crear-turno.component';
import { ListRutasComponent } from './rutas/list-rutas/list-rutas.component';
import { CrearRutaComponent } from './rutas/crear-ruta/crear-ruta.component';
import { EditarRutaComponent } from './rutas/editar-ruta/editar-ruta.component';




export const ComponentsRoutes: Routes = [
      {
        path: '',
        children: 
        [
            {
                path: 'buttons',
                component: ButtonsComponent
            }
        ]
    },{
        path: '',
        children: 
        [ 
            {
                path: 'usuarios',
                component: ListUsuariosComponent          
            }
        ]
    },{
        path: '',
        children:
        [
            {
              path: 'propietario',
              component: ListPropietariosComponent          
            }
        ]
    },{
        path: '',
        children:
        [
            {
              path: 'motos',
              component: ListMotosComponent          
            }
        ]
    },{
        path: '',
        children:
        [
            {
              path: 'edit-moto/:id',
              component: EditMotoComponent          
            }
        ]
    },{
        path: '',
        children:
        [
            {
              path: 'crear-moto',
              component: CrearMotoComponent          
            }
        ]
    },{
        path: '',
        children:
        [
            {
              path: 'edit-propietario/:id',
              component: EditPropietarioComponent          
            }
        ]
    },{
        path:'',
        children: [ {
            path: 'crear-propietario',
            component: CrearPropietarioComponent
        }]
    },{
        path: '',
        children: 
        [
            {
             path: 'usuarios',
             component: ListUsuariosComponent          
            }
        ]
    },{
        path:'',
        children: 
        [
            {
             path: 'edit-usuario/:id',
             component: EditarUsuariosComponent
            }
        ]
      },{
        path:'',
        children: 
        [
            {
             path: 'turnos',
             component: ListTurnosComponent
            }
        ]
      },{
        path:'',
        children: 
        [
            {
             path: 'rutas',
             component: ListRutasComponent
            }
        ]
      },{
        path:'',
        children: 
        [
            {
             path: 'crear-ruta/:turnoId',
             component: CrearRutaComponent
            }
        ]
      },{
        path:'',
        children: 
        [
            {
             path: 'editar-ruta/:turnoId',
             component: EditarRutaComponent
            }
        ]
      },{
        path:'',
        children: 
        [
            {
             path: 'crear-turno',
             component: CrearTurnoComponent
            }
        ]
      },{
            path:'',
            children: [ {
                path: 'crear-usuario',
                component: CrearUsuariosComponent
            }]
        },{
    path: '',
    children: [ {
      path: 'grid',
      component: GridSystemComponent
    }]
    }, {
      path: '',
      children: [ {
        path: 'icons',
        component: IconsComponent
        }]
    }, {
        path: '',
        children: [ {
            path: 'notifications',
            component: NotificationsComponent
        }]
    }, {
        path: '',
        children: [ {
            path: 'panels',
            component: PanelsComponent
        }]
    }, {
        path: '',
        children: [ {
            path: 'sweet-alert',
            component: SweetAlertComponent
        }]
    }, {
        path: '',
        children: [ {
            path: 'typography',
            component: TypographyComponent
        }]
    }
];
