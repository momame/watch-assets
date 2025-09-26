 
import { Component, OnInit } from '@angular/core';
import { Asset } from '../../models/asset.model';
import { AssetService } from '../../services/asset.service';

@Component({
  selector: 'app-asset-list',
  template: `
    <h2>Asset List</h2>
    <div class="asset-grid">
      <div *ngFor="let asset of assets" class="asset-card">
        <h3>{{ asset.assetName }}</h3>
        <p><strong>Type:</strong> {{ asset.assetType }}</p>
        <p><strong>Location:</strong> {{ asset.location }}</p>
        <p><strong>Status:</strong> <span [class]="getStatusClass(asset.status)">{{ asset.status }}</span></p>
        <button (click)="viewDetails(asset.id)">View Details</button>
      </div>
    </div>
  `,
  styles: [`
    .asset-grid {
      display: grid;
      grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
      gap: 20px;
      margin-top: 20px;
    }
    .asset-card {
      border: 1px solid #ddd;
      border-radius: 8px;
      padding: 15px;
      background-color: #f9f9f9;
    }
    .status-operational { color: green; }
    .status-maintenance { color: orange; }
    .status-outofservice { color: red; }
    button {
      background-color: #007acc;
      color: white;
      border: none;
      padding: 8px 16px;
      border-radius: 4px;
      cursor: pointer;
    }
  `]
})
export class AssetListComponent implements OnInit {
  assets: Asset[] = [];

  constructor(private assetService: AssetService) { }

  ngOnInit(): void {
    this.loadAssets();
  }

  loadAssets(): void {
    this.assetService.getAssets().subscribe(
      (data) => {
        this.assets = data;
      }
    );
  }

  getStatusClass(status: string): string {
    return `status-${status.toLowerCase().replace(' ', '')}`;
  }

  viewDetails(id: number): void {
    console.log('View details for asset:', id);
  }
}