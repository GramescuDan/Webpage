import { Component, OnInit } from '@angular/core';
import {IArticle} from "../../models/article";
import {FaqsService} from "../../services/faqs.service";


@Component({
  selector: 'app-news-section',
  templateUrl: './news-section.component.html',
  styleUrls: ['./news-section.component.scss']
})
export class NewsSectionComponent implements OnInit {
  faqs: IArticle[];

  constructor(
    private readonly _faqService : FaqsService
  ) {
  }

  ngOnInit(): void {
    this._faqService.get().subscribe(faqs => this.faqs = faqs);
  }

}
