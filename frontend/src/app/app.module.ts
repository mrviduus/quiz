import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';



import { AppComponent } from './app.component';
import { appRoutingModule } from './app.routing';

import { JwtInterceptor, ErrorInterceptor } from './_helpers';
import { HomeComponent } from './home';
import { LoginComponent } from './login';
import { QuizComponent } from './quiz';
import { ResultComponent } from './result/result.component';
import { PopulatedbComponent } from './populatedb/populatedb.component';
import {MatProgressBarModule} from '@angular/material/progress-bar';

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        appRoutingModule,
        MatProgressBarModule
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        LoginComponent,
        QuizComponent ,
        ResultComponent,
        PopulatedbComponent
       ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },


    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
