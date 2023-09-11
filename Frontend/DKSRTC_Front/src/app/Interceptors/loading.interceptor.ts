// Purpose: Loading interceptor to show loading screen when HTTP requests are made.
import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoadingService } from '../Services/loading.service';
import { NavigationStart, Router } from '@angular/router';
import { delay, tap } from 'rxjs/operators';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {
  constructor(
    private loadingService: LoadingService,
    private router: Router
  ) {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationStart) {
        this.loadingService.startLoading();

        setTimeout(() => {
          this.loadingService.stopLoading();
        }, 1000); // Show loading screen for 2 seconds
      }
    });
  }

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    // You can also handle HTTP requests here if needed.
    return next.handle(request).pipe(delay(1000),
      tap(() => {
        // Stop loading when the response is received.
        this.loadingService.stopLoading();
      })
    );
  }
}
