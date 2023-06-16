import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {
  urlApi = 'https://localhost:7208/api/Journey';

  httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  searchJourneys(origin: string, destination: string): Observable<any>{
    return this.http.get<any>(this.urlApi + '?Origin=' + origin + '&Destination='+ destination);
  }
}
