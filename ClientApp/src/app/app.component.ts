 
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <div class="container">
      <h1>Asset Monitoring Dashboard</h1>
      <router-outlet></router-outlet>
    </div>
  `,
  styles: [`
    .container {
      padding: 20px;
      font-family: Arial, sans-serif;
    }
    h1 {
      color: #333;
      border-bottom: 2px solid #007acc;
      padding-bottom: 10px;
    }
  `]
})
export class AppComponent {
  title = 'watch-assets-frontend';
}