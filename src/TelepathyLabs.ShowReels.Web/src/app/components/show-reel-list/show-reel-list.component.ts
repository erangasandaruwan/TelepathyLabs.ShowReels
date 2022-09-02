import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { KeyValuePair } from 'src/app/models/key-value-pair';
import { ShowReel } from 'src/app/models/show-reel';
import { VideoDefinitionService } from '../../services/video-definition/video-definition.service';
import { VideoStandardService } from '../../services/video-standard/video-standard.service';
import { ShowReelService } from '../../services/show-reel/show-reel.service';

@Component({
  selector: 'show-reel-list',
  templateUrl: './show-reel-list.component.html',
  styleUrls: ['./show-reel-list.component.css'],
})
export class ShowReelListComponent implements OnInit {

  constructor(
    private showReelService: ShowReelService,
    private videoDefinitionService: VideoDefinitionService,
    private videoStandardService: VideoStandardService) { }

  showReels?: ShowReel[];
  videoDefinitions?: KeyValuePair[];
  videoStandards?: KeyValuePair[];

  ngOnInit(): void {
    this.showReelService.getShowReel().subscribe(response => {
      this.showReels = response;
    });

    this.videoDefinitionService.getVideoDefinition().subscribe(response => {
      this.videoDefinitions = response;
    });

    this.videoStandardService.getVideoStandard().subscribe(response => {
      this.videoStandards = response;
    });
  }

}
