import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-text-line',
  templateUrl: './text-line.component.html',
  styleUrls: ['./text-line.component.scss']
})
export class TextLineComponent  {
  @Input() img =' ';

}
