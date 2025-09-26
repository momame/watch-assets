import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <div class="container">
      <nav class="navbar">
        <h1>Asset Monitoring Dashboard</h1>
        <ul class="nav-links">
          <li><a routerLink="/assets" routerLinkActive="active">All Assets</a></li>
          <li><a routerLink="/search" routerLinkActive="active">Search Assets</a></li>
          <li><a routerLink="/dashboard" routerLinkActive="active">Performance</a></li>
        </ul>
      </nav>
      <router-outlet></router-outlet>
    </div>
  `,
  styles: [`
    .container {
      padding: 20px;
      font-family: Arial, sans-serif;
    }
    .navbar {
      display: flex;
      justify-content: space-between;
      align-items: center;
      margin-bottom: 30px;
      border-bottom: 2px solid #007acc;
      padding-bottom: 10px;
    }
    .nav-links {
      display: flex;
      list-style: none;
      margin: 0;
      padding: 0;
      gap: 20px;
    }
    .nav-links a {
      text-decoration: none;
      color: #333;
      padding: 8px 16px;
      border-radius: 4px;
    }
    .nav-links a.active {
      background-color: #007acc;
      color: white;
    }
    h1 {
      color: #333;
    }
  `]
})
export class AppComponent {
  title = 'watch-assets-frontend';
}