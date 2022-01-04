import {Component, Input, OnInit} from '@angular/core';
import {IArticle} from "../../models/article";
import {FaqsService} from "../../services/faqs.service";
import {NewsService} from "../../services/news.service";


@Component({
  selector: 'app-news-section',
  templateUrl: './news-section.component.html',
  styleUrls: ['./news-section.component.scss']
})
export class NewsSectionComponent implements OnInit {
  faqs: IArticle[];

  constructor(
    private readonly _faqService : FaqsService, private readonly _newsService: NewsService
  ) {
  }
  @Input() article : "f" | "n" ;

  ngOnInit(): void {
    if(this.article == "f"){
      this._faqService.get().subscribe(faqs => this.faqs = faqs);
    }else{
      this._newsService.get().subscribe(news=> this.faqs=news);
    }

  }

}
