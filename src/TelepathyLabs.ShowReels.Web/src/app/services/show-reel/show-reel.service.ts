import { Injectable } from '@angular/core';
import configs from '../../../assets/config.json';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { ShowReel } from '../../models/show-reel';
import { map } from 'rxjs/operators';
import { VideoClip } from '../../models/video-clip';
import { TimeCode } from '../../models/time-code';

@Injectable({
  providedIn: 'root'
})
export class ShowReelService {

  private ShowReelsApiBaseUrl: string = configs.ShowReelsApiBaseUrl;
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };
  
  constructor(private httpClient: HttpClient) { 
  }
  
  getShowReel(): Observable<ShowReel[]> {
    return this.httpClient.get<ShowReel[]>(`${this.ShowReelsApiBaseUrl}showreel`)
      .pipe(map(showReels => showReels.map(s => { 
        var videoClips = s.VideoClips.map(v => {
          var startTimeCode = new TimeCode(
            v.StartTimeCode.Hours, 
            v.StartTimeCode.Minutes, 
            v.StartTimeCode.Seconds, 
            v.StartTimeCode.Frames, 
            v.StartTimeCode.FramesPerSecond
          );
          var endTimeCode = new TimeCode(
            v.EndTimeCode.Hours, 
            v.EndTimeCode.Minutes, 
            v.EndTimeCode.Seconds, 
            v.EndTimeCode.Frames, 
            v.EndTimeCode.FramesPerSecond
          );

          return new VideoClip(v.Name, v.Description, v.VideoDefinition, v.VideoStandard, startTimeCode, endTimeCode);
        });
        return new ShowReel(s.Name, s.Description, s.VideoDefinition, s.VideoStandard, videoClips);
      })));
  }

  saveShowReel(showReel: ShowReel): Observable<object> {
    return this.httpClient.post(`${this.ShowReelsApiBaseUrl}showreel`,showReel, this.httpOptions);
  }
}
