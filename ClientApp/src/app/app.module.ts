 
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AssetListComponent } from './components/asset-list/asset-list.component';
import { AssetDetailComponent } from './components/asset-detail/asset-detail.component';
import { AppRoutingModule } from './app-routing.module';
import { AssetHealthComponent } from './components/asset-health/asset-health.component';

@NgModule({
  declarations: [
    AppComponent,
    AssetListComponent,
    AssetDetailComponent,
    AssetHealthComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }