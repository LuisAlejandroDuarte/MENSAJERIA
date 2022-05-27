import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { UserComponent } from './user.component';
import { UserRoutes } from './user.routing';
import { CambioClaveComponent } from '../pages/cambio-clave/cambio-clave.component';

@NgModule({
    imports: [
        CommonModule,
        RouterModule.forChild(UserRoutes),
        FormsModule,
        ReactiveFormsModule
    ],
    declarations: [UserComponent,CambioClaveComponent]
})

export class UserModule {}
