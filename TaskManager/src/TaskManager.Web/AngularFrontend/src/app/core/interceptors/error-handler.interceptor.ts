import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Injectable()
export class ErrorHandlerInterceptor implements HttpInterceptor {
  constructor(private toastr: ToastrService,private _router: Router) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError(error => this.errorHandler(error)));
  }

  private errorHandler(response: HttpErrorResponse): Observable<HttpEvent<any>> {

    console.log(typeof(response.error));

    if(response.status > 0)
      this.showError( typeof(response.error) != "string" ? response.error.text : response.error, response.status);

    throw response;
  }

  private showError(message: string, status: number) {
    if(status > 300)
      this.toastr.error(message, `Erro ${status}`);
    else
      this.toastr.success(message, `Success ${status}`);
  }
}
