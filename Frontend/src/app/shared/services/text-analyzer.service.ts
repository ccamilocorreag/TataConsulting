import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { TextAnalyzer } from '../models/text-analyzer.model';
import { TextAnalyzerResult } from '../models/text-result.model';

@Injectable()
export class TextAnalyzerService {

  constructor(private http: HttpClient) { }

  analyzeText(textAnalyzer: TextAnalyzer): Observable<TextAnalyzerResult> {
    return this.http.post<TextAnalyzerResult>('https://localhost:44315/api/TextAnalyzer/AnalyzeText', textAnalyzer);
  }
}
