import { animate, state, style, transition, trigger } from "@angular/animations";
import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { ActivationStart } from "@angular/router";
import { Observable, of } from "rxjs";

import { MaestroService } from 'src/maestro-client';
import { Channel } from 'src/maestro-client/models';
import { ChannelService } from 'src/app/services/channel.service';
import { StatefulResult, statefulSwitchMap } from 'src/stateful';

@Component({
  selector: "mc-side-bar",
  templateUrl: "./side-bar.component.html",
  animations: [
    trigger("openClose", [
      state("open", style({width: "250px"})),
      state("closed", style({width: "40px"})),
      transition("open => closed", [animate("0.1s")]),
      transition("closed => open", [animate("0.1s")]),
    ]),
  ],
})
export class SideBarComponent implements OnInit {
  @Input() public opened = false;
  @Input() public fullSize = "";
  @Input() public dockedSize = "";
  @Output() public openedChange = new EventEmitter<boolean>();

  public channels$!: Observable<StatefulResult<Channel[]>>;

  public constructor(private channels: ChannelService) {
  }

  public ngOnInit(): void {
    this.channels$ = of(false).pipe(
      statefulSwitchMap(() => {
        return this.channels.getChannels();
      }),
    );
  }

  public toggleOpened(): void {
    this.opened = !this.opened;
    this.openedChange.emit(this.opened);
  }
}
