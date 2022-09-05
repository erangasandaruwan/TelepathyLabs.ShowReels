import { Injectable } from '@angular/core';
import configs from '../../../assets/config.json';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { KeyValuePair } from './../../models/key-value-pair';

@Injectable({
  providedIn: 'root'
})
export class VideoStandardService {

  private ShowReelsApiBaseUrl: string = configs.ShowReelsApiBaseUrl;

  constructor(private httpClient: HttpClient) {

   }

  getVideoStandard(): Observable<KeyValuePair[]> {
    return this.httpClient.get<KeyValuePair[]>(`${this.ShowReelsApiBaseUrl}VideoStandard`);
  }
}
