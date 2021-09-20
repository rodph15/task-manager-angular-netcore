import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { ToastrModule } from 'ngx-toastr';

import { ErrorHandlerInterceptor } from './core/interceptors/error-handler.interceptor';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { FooterComponent } from './layout/footer/footer.component';
import { SidebarComponent } from './layout/sidebar/sidebar.component';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { ContentComponent } from './layout/content/content.component';
import { ListComponent } from './features/task/list/list.component';
import { CreateComponent } from './features/task/create/create.component';
import { EditComponent } from './features/task/edit/edit.component';

import { TaskService } from './service/task-service';

@NgModule({
  declarations: [
    FooterComponent,
    SidebarComponent,
    NavbarComponent,
    ContentComponent,
    AppComponent,
    ListComponent,
    CreateComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    HttpClientModule
  ],
  providers: [
    TaskService,
  {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorHandlerInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
