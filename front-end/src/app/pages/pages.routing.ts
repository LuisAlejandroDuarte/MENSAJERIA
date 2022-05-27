import { CambioClaveComponent } from './cambio-clave/cambio-clave.component';
import { Routes } from '@angular/router';

import { RegisterComponent } from './register/register.component';
import { PricingComponent } from './pricing/pricing.component';
import { LockComponent } from './lock/lock.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from '../guads/auth.guard';

export const PagesRoutes: Routes = [

    {
        path: '',
        children: [ {
            path: 'login',
            component: LoginComponent
        }, {
            path: 'lock',
            component: LockComponent
        }, {
            path: 'register',           
            component: RegisterComponent
        },{
            path: 'pricing',
            component: PricingComponent
        }]
    }
];
