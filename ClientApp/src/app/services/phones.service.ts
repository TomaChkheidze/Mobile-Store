import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PhonesService {

  constructor(private http: HttpClient) { }

  getPhones(search: string, brand: number, priceLow: number, priceHigh: number, pageIndex: number, pageSize: number) {
    let params = new HttpParams();
    if (search && search !== "") { params = params.set('search', search); }
    if (brand && +brand !== 0) { params = params.set('brand', '' + brand); }
    if (+priceLow && +priceHigh) { params = params.set('priceLow', '' + priceLow); params = params.set('priceHigh', '' + priceHigh); }
    if (pageIndex && +pageIndex >= 1) { params = params.set('pageIndex', '' + pageIndex); }
    if (pageSize && +pageSize >= 1) { params = params.set('pageSize', '' + pageSize); }
    return this.http.get("api/phones", { params: params });
  }

  getPhone(id: number) {
    return this.http.get("api/phones/" + id);
  }
}
