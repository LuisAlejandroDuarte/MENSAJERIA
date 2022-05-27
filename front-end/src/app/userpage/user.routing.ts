import { Routes } from '@angular/router';
import { AuthGuard } from '../guads/auth.guard';
import { CambioClaveComponent } from '../pages/cambio-clave/cambio-clave.component';

import { UserComponent } from './user.component';

export const UserRoutes: Routes = [
    {

      path: '',
      children: [ {
        path: 'pages/user',
        canActivate:[AuthGuard],  
        component: UserComponent
        }, { 
          path: 'pages/cambioclave',                  
          canActivate:[AuthGuard],  
          component: CambioClaveComponent
        }]
    }
];
