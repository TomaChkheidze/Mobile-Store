import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { BrandsService } from 'src/app/services/brands.service';
import { PhonesService } from 'src/app/services/phones.service';

@Component({
  selector: 'app-phones',
  templateUrl: './phones.component.html',
  styleUrls: ['./phones.component.scss']
})
export class PhonesComponent implements OnInit {

  phones: any[] = [];
  page: number = 1;
  count: number = 9;
  pageSize: number = 3;

  brands: any[] = [];

  phonesSubscription: Subscription;
  brandsSubscription: Subscription;

  filterForm: FormGroup;

  loading: boolean = true;

  constructor(private phonesService: PhonesService, private brandsService: BrandsService, private fb: FormBuilder, private activatedRoute: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe(params => {
      this.filterForm = this.fb.group({
        searchTerm: [''],
        brand: ['0'],
        priceLow: [''],
        priceHigh: ['']
      });

      if (params['search']) { this.filterForm.get('searchTerm').setValue('' + params['search']); }
      if (params['brand'] && params['brand'] !== '0') { this.filterForm.get('brand').setValue('' + params['brand']); }
      if (params['priceLow']) { this.filterForm.get('priceLow').setValue('' + params['priceLow']); }
      if (params['priceHigh']) { this.filterForm.get('priceHigh').setValue('' + params['priceHigh']); }
      if (params['pageIndex']) { this.page = +params['pageIndex']; }
      if (params['pageSize']) { this.pageSize = +params['pageSize']; }
      this.getAllPhones();
    });

    this.getAllBrands();
  }

  getAllPhones() {
    this.loading = true;
    this.phonesSubscription = this.phonesService.getPhones(
      this.filterForm.get('searchTerm').value,
      +this.filterForm.get('brand').value,
      +this.filterForm.get('priceLow').value,
      +this.filterForm.get('priceHigh').value,
      this.page,
      this.pageSize
    ).subscribe(
      (data: any) => {
        this.phones = data.data;
        this.count = +data.count;        
        this.loading = false;
      }, error => {
        console.log(error);
        this.loading = false;
      }, () => { this.phonesSubscription.unsubscribe(); this.loading = false; }
    );
  }

  getAllBrands() {
    this.brandsSubscription = this.brandsService.getBrands().subscribe(
      (data: any[]) => {
        this.brands = data;
      }, error => {
        console.log(error);
      }, () => { this.brandsSubscription.unsubscribe(); }
    );
  }

  pageChange() {
    const queryParams: Params = {};

    if (this.page > 1) {
      queryParams.pageIndex = '' + this.page;
    }
    if (this.pageSize >= 1 && this.pageSize !== 3) {
      queryParams.pageSize = '' + this.pageSize;
    }

    this.router.navigate([], { queryParams: queryParams });
  }

  onSubmit() {
    const queryParams: Params = {};
    if (this.filterForm.get('searchTerm').value !== '') {
      queryParams.search = '' + this.filterForm.get('searchTerm').value;
    }
    if (this.filterForm.get('brand').value && '' + this.filterForm.get('brand').value !== '0') {
      queryParams.brand = '' + this.filterForm.get('brand').value;
    } else {
      delete queryParams.brand;
    }
    if (+this.filterForm.get('priceLow').value) {
      queryParams.priceLow = '' + this.filterForm.get('priceLow').value;
    }
    if (+this.filterForm.get('priceHigh').value) {
      queryParams.priceHigh = '' + this.filterForm.get('priceHigh').value;
    }

    this.router.navigate([], { queryParams: queryParams });
  }

}
