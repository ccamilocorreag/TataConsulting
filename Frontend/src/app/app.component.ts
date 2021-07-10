import { Component } from '@angular/core';
import { TextAnalyzer } from './shared/models/text-analyzer.model';
import { TextAnalyzerResult } from './shared/models/text-result.model';
import { TextAnalyzerService } from './shared/services/text-analyzer.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [TextAnalyzerService]
})
export class AppComponent {
  title = 'TataConsultingApp';
  textAnalyzer: TextAnalyzer = new TextAnalyzer();
  textAnalyzerResult!: TextAnalyzerResult;

  constructor(private _textAnalyzerService: TextAnalyzerService) {

  }

  analyzeText() {
    this._textAnalyzerService.analyzeText(this.textAnalyzer).subscribe(
      result => {
        this.textAnalyzerResult = result;
      },
      error => console.log(error)
    );
  }
}
