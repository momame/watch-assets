import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Asset } from '../models/asset.model';

export interface AssetSearchCriteria {
  query?: string;
  location?: string;
  status?: string;
}

@Injectable({
  providedIn: 'root'
})
export class AssetService {
  private apiUrl = 'https://localhost:7001/api'; // TODO: Move to environment config

  constructor(private http: HttpClient) { }

  getAssets(): Observable<Asset[]> {
    return this.http.get<Asset[]>(`${this.apiUrl}/assets`)
      .pipe(
        retry(1), // Retry once on failure
        catchError(this.handleError)
      );
  }

  getAsset(id: number): Observable<Asset> {
    return this.http.get<Asset>(`${this.apiUrl}/assets/${id}`)
      .pipe(catchError(this.handleError));
  }

  searchAssets(criteria: AssetSearchCriteria): Observable<Asset[]> {
    // Note: This was initially a GET request but changed to POST for complex criteria
    return this.http.post<Asset[]>(`${this.apiUrl}/assetsearch/search`, criteria)
      .pipe(catchError(this.handleError));
  }

  // Error handling - need to improve this
  private handleError(error: HttpErrorResponse) {
    let errorMessage = 'Unknown error!';
    if (error.error instanceof ErrorEvent) {
      // Client-side errors
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side errors
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.error(errorMessage);
    return throwError(() => errorMessage);
  }
}