import { Component, Input, OnInit } from '@angular/core';
import { KeyValuePair } from 'src/app/models/key-value-pair';
import { ShowReel } from 'src/app/models/show-reel';

@Component({
  selector: 'show-reel-info',
  templateUrl: './show-reel-info.component.html',
  styleUrls: ['./show-reel-info.component.css']
})
export class ShowReelInfoComponent implements OnInit {

  @Input() showReel?: ShowReel;
  @Input() videoDefinitions?: KeyValuePair[];
  @Input() videoStandards?: KeyValuePair[];

  constructor() { }

  ngOnInit(): void {
  }

  getVideoDefinition(key: number | undefined): string | undefined {
    return this.videoDefinitions?.filter(vd => vd.Key === key)[0].Value;
  }

  getVideoStandard(key: number | undefined): string | undefined {
    return this.videoStandards?.filter(vs => vs.Key === key)[0].Value;
  }

}
