import {Component} from '@angular/core';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';
import {ISubscriber} from "../../models/ISubscriber";
import {SubscriptionService} from "../../services/subscription.service";
import {firstValueFrom} from "rxjs";

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

/** @title Input with a custom ErrorStateMatcher */
@Component({
  selector: 'app-email-form',
  templateUrl: './email-form.component.html',
  styleUrls: ['./email-form.component.scss'],
})
export class EmailFormComponent {
  subscriber: ISubscriber
  constructor(private readonly _subscriptionService : SubscriptionService) {
  }
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);

  matcher = new MyErrorStateMatcher();
  async postSubscriber():Promise<void>{
    this.subscriber = {
      email: this.emailFormControl.value,
      id: " "
    }
    await firstValueFrom(this._subscriptionService.post(this.subscriber));
  }
}
