import { Routes } from '@angular/router';
import { AuthGuard } from '../guads/auth.guard';
import { DashboardComponent } from './dashboard.component';

export const DashboardRoutes: Routes = [
    {

      path: '',           

      children: [ {
        path: 'dashboard',   
        
        component: DashboardComponent
    }]
}
];
