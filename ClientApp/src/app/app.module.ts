import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { AssetListComponent } from './components/asset-list/asset-list.component';
import { AssetDetailComponent } from './components/asset-detail/asset-detail.component';
import { AppRoutingModule } from './app-routing.module';
import { AssetHealthComponent } from './components/asset-health/asset-health.component';
import { AssetSearchComponent } from './components/asset-search/asset-search.component';

@NgModule({
  declarations: [
    AppComponent,
    AssetListComponent,
    AssetDetailComponent,
    AssetHealthComponent,
    AssetSearchComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }