import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssetListComponent } from './components/asset-list/asset-list.component';
import { AssetSearchComponent } from './components/asset-search/asset-search.component';

const routes: Routes = [
  { path: '', component: AssetListComponent },
  { path: 'assets', component: AssetListComponent },
  { path: 'search', component: AssetSearchComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }