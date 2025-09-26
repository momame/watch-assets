import { Component, OnInit } from '@angular/core';
import { AssetService } from '../../services/asset.service';

@Component({
  selector: 'app-performance-dashboard',
  template: `
    <h2>System Performance Dashboard</h2>
    <div class="dashboard-container">
      <div class="metric-card">
        <h3>System Health</h3>
        <p>Status: <span class="status-good">Healthy</span></p>
        <p>Response Time: 45ms</p>
        <p>Uptime: 99.9%</p>
      </div>
      
      <div class="metric-card">
        <h3>Asset Statistics</h3>
        <p>Total Assets: 1,247</p>
        <p>Operational: 1,123</p>
        <p>Under Maintenance: 124</p>
      </div>
      
      <div class="metric-card">
        <h3>Search Performance</h3>
        <p>Avg. Query Time: 67ms</p>
        <p>Cache Hit Rate: 85%</p>
        <p>Queries/Min: 245</p>
      </div>
    </div>
  `,
  styles: [`
    .dashboard-container {
      display: grid;
      grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
      gap: 20px;
      margin-top: 20px;
    }
    .metric-card {
      border: 1px solid #ddd;
      border-radius: 8px;
      padding: 15px;
      background-color: #f5f5f5;
    }
    .status-good {
      color: green;
      font-weight: bold;
    }
    .status-warning {
      color: orange;
      font-weight: bold;
    }
    .status-critical {
      color: red;
      font-weight: bold;
    }
  `]
})
export class PerformanceDashboardComponent implements OnInit {

  constructor(private assetService: AssetService) { }

  ngOnInit(): void {
    // Load performance metrics
  }
}