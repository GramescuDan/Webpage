import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-text-button',
  templateUrl: './text-button.component.html',
  styleUrls: ['./text-button.component.scss']
})
export class TextButtonComponent {

  @Input() text="Submit";
  @Input() hrefId = " " ;


}
