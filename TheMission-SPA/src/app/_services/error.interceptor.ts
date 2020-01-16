import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';


@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    intercept(
        req: HttpRequest<any>,
        next: HttpHandler): Observable<HttpEvent<any>> {
                return next.handle(req).pipe(
                    catchError(error => {
                        if (error.status === 401) {
                            return throwError(error.statusText);
                        }

                        if (error instanceof HttpErrorResponse) {
                            // 500 errors
                            const applicationError = error.headers.get('Application-Error');
                            if (applicationError) {
                                return throwError(applicationError);
                            }

                            // Model errors
                            const serverError = error.error;
                            let modalStatErrors = '';
                            if (serverError.errors && typeof serverError.errors === 'object') {
                                for (const key in serverError.errors) {
                                    if (serverError.errors[key]) {
                                        modalStatErrors += serverError.errors[key] + '\n';
                                    }
                                }
                            }

                            return throwError(modalStatErrors || serverError || 'Unknown Error');
                        }

                    })
                );
        }
}

export const ErrorInterCeptorProvider = {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorInterceptor,
    multi: true
};