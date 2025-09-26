import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
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
  private apiUrl = 'https://localhost:7001/api'; // Update with your API URL

  constructor(private http: HttpClient) { }

  getAssets(): Observable<Asset[]> {
    return this.http.get<Asset[]>(`${this.apiUrl}/assets`);
  }

  getAsset(id: number): Observable<Asset> {
    return this.http.get<Asset>(`${this.apiUrl}/assets/${id}`);
  }

  searchAssets(criteria: AssetSearchCriteria): Observable<Asset[]> {
    return this.http.post<Asset[]>(`${this.apiUrl}/assetsearch/search`, criteria);
  }
}