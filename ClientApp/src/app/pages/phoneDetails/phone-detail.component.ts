import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { PhonesService } from 'src/app/services/phones.service';

@Component({
  selector: 'app-phone-detail',
  templateUrl: './phone-detail.component.html',
  styleUrls: ['./phone-detail.component.scss']
})
export class PhoneDetailComponent implements OnInit, OnDestroy {

  private paramSub: Subscription;
  private phoneSub: Subscription;
  phone: any;
  loading: boolean = true;

  activeImg: number = 0;

  constructor(private phonesService: PhonesService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.paramSub = this.route.params.subscribe(param => {
      this.loading = true;
      this.phoneSub = this.phonesService.getPhone(+param['id']).subscribe(
        data => {
          this.phone = data;
          console.log(this.phone);
          this.loading = false;
        },
        error => {
          console.log(error);
          this.loading = false;
        },
        () => { this.phoneSub.unsubscribe(); this.loading = false; }
      )
    });
  }

  changeImage(index: number) {
    this.activeImg = index;
  }

  ngOnDestroy(): void {
    this.paramSub.unsubscribe();
  }

}
