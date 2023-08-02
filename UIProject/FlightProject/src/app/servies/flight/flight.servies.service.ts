import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FlightServiesService {
  
  private url = "https://localhost:7198/api/Plane";
  constructor(private httpClient: HttpClient) { }

  get() {
    return this.httpClient.get(this.url)
      .pipe(catchError((error: any) => {
        // this.errorMessage = error.message;
        console.error('There was an error!', error);
  
        // after handling error, return a new observable 
        // that doesn't emit any values and completes
        throw new Error(error.message)
      }))
  }

  getById(id: number) {
    return this.httpClient.get(this.url + id)
      .pipe(catchError((error: any) => {
        // this.errorMessage = error.message;
        console.error('There was an error!', error);

        // after handling error, return a new observable 
        // that doesn't emit any values and completes
        throw new Error(error.message)
      }))
  };


}
