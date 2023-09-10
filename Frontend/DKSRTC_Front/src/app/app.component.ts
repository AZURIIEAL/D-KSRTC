import { Component, OnInit } from '@angular/core';
import { LoadingService } from './Services/loading.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent implements OnInit {
  isLoading: boolean = false;

  constructor(private loadingService: LoadingService) {}
  ngOnInit() {
    this.loadingService.getLoadingState().subscribe((isLoading) => {
      this.isLoading = isLoading;
    });
  }
  title = 'DKSRTC_Front';
}
