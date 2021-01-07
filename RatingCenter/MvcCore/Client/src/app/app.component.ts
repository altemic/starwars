import {Component} from '@angular/core';
import {EventService, VisibleComponent} from './services/event.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Client';

  public constructor(private eventService: EventService) {
  }

  isListVisible(): boolean {
    return this.eventService.visibleComponent === VisibleComponent.LIST;
  }

  isDetailsVisible(): boolean {
    return this.eventService.visibleComponent === VisibleComponent.DETAILS;
  }
}
