import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home';
import { LoginComponent } from './login';
import {QuizComponent} from './quiz';
import { AuthGuard } from './_helpers';
import {ResultComponent} from './result';
import {PopulatedbComponent} from './populatedb';
import { from } from 'rxjs';


const routes: Routes = [
    //{path: '', redirectTo: '/', pathMatch: 'full'},
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'quiz', component: QuizComponent, canActivate: [AuthGuard]},
    { path: 'result', component: ResultComponent, canActivate: [AuthGuard]},
    { path: 'api/abracadabra/service/populatedb', component: PopulatedbComponent},
    // otherwise redirect to home
    { path: '**', redirectTo: '' }

];

export const appRoutingModule = RouterModule.forRoot(routes);