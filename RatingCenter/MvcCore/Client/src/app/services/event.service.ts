import { Injectable } from '@angular/core';
import {BehaviorSubject, Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  // -1 for list
  private visibleFilmId = new BehaviorSubject<string>('-1');

  constructor() { }

  get visibleComponent(): VisibleComponent {
    return this.visibleFilmId.getValue() === '-1'
      ? VisibleComponent.LIST
      : VisibleComponent.DETAILS;
  }

  get visibleFilmDetailsId(): string | undefined {
    return this.visibleFilmId.getValue();
  }

  showList(): void {
    this.visibleFilmId.next('-1');
  }

  showDetails(id: string): void {
    this.visibleFilmId.next(id);
  }

  observeVisibleFilmDetailsId(): Observable<string> {
    return this.visibleFilmId.asObservable();
  }
}

export enum VisibleComponent {
  LIST ,
  DETAILS
}
