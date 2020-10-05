import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { PhonesComponent } from './pages/phones/phones.component';
import { PhoneComponent } from './components/phone/phone.component';
import { PhoneDetailComponent } from './pages/phoneDetails/phone-detail.component';

import { PhonesService } from './services/phones.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    PhonesComponent,
    PhoneComponent,
    PhoneDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgbModule
  ],
  providers: [PhonesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
