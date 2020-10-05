import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PhoneDetailComponent } from './pages/phoneDetails/phone-detail.component';
import { PhonesComponent } from './pages/phones/phones.component';

const routes: Routes = [
  { path: '', redirectTo: 'phones', pathMatch: 'full' },
  { path: 'phones', component: PhonesComponent },
  { path: 'phones/:id', component: PhoneDetailComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
