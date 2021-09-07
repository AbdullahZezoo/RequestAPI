import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public requests: Request[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Request[]>(baseUrl + 'Requests').subscribe(result => {
      this.requests = result;
    }, error => console.error(error));
  }
}

interface Request {
  RequestId: number;
  MobileNumber: number;
  RequestDate: Date;
}
