import { Component } from '@angular/core';
import { AssetService } from '../../services/asset.service';
import { Asset } from '../../models/asset.model';

@Component({
  selector: 'app-asset-search',
  template: `
    <h2>Search Assets</h2>
    <div class="search-container">
      <div class="search-form">
        <input 
          type="text" 
          [(ngModel)]="searchQuery" 
          placeholder="Search assets..." 
          class="search-input"
        >
        <select [(ngModel)]="locationFilter" class="filter-select">
          <option value="">All Locations</option>
          <option value="Site-A">Site-A</option>
          <option value="Site-B">Site-B</option>
          <option value="Site-C">Site-C</option>
        </select>
        <select [(ngModel)]="statusFilter" class="filter-select">
          <option value="">All Statuses</option>
          <option value="Operational">Operational</option>
          <option value="Maintenance">Maintenance</option>
        </select>
        <button (click)="performSearch()" class="search-button">Search</button>
      </div>
      
      <div class="search-results">
        <div *ngFor="let asset of searchResults" class="asset-card">
          <h3>{{ asset.assetName }}</h3>
          <p><strong>Type:</strong> {{ asset.assetType }}</p>
          <p><strong>Location:</strong> {{ asset.location }}</p>
          <p><strong>Status:</strong> <span [class]="getStatusClass(asset.status)">{{ asset.status }}</span></p>
        </div>
      </div>
    </div>
  `,
  styles: [`
    .search-container {
      max-width: 800px;
      margin: 20px auto;
    }
    .search-form {
      display: flex;
      gap: 10px;
      margin-bottom: 20px;
      flex-wrap: wrap;
    }
    .search-input, .filter-select {
      padding: 8px;
      border: 1px solid #ccc;
      border-radius: 4px;
    }
    .search-input {
      flex: 1;
      min-width: 200px;
    }
    .search-button {
      background-color: #007acc;
      color: white;
      border: none;
      padding: 8px 16px;
      border-radius: 4px;
      cursor: pointer;
    }
    .search-results {
      display: grid;
      grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
      gap: 20px;
    }
    .asset-card {
      border: 1px solid #ddd;
      border-radius: 8px;
      padding: 15px;
      background-color: #f9f9f9;
    }
    .status-operational { color: green; }
    .status-maintenance { color: orange; }
  `]
})
export class AssetSearchComponent {
  searchQuery: string = '';
  locationFilter: string = '';
  statusFilter: string = '';
  searchResults: Asset[] = [];

  constructor(private assetService: AssetService) { }

  performSearch(): void {
    const searchParams = {
      query: this.searchQuery,
      location: this.locationFilter,
      status: this.statusFilter
    };

    this.assetService.searchAssets(searchParams).subscribe(
      (results) => {
        this.searchResults = results;
      }
    );
  }

  getStatusClass(status: string): string {
    return `status-${status.toLowerCase().replace(' ', '')}`;
  }
}