import { Routes } from '@angular/router';
import { FacturaServicioComponent } from './factura-servicio/factura-servicio.component';

export const ReportesRoutes: Routes = [
    {
      path: '',
      children: 
        [ 
            {
                path: 'factura-servicio',
                component: FacturaServicioComponent
            }
         ]
    }
];
