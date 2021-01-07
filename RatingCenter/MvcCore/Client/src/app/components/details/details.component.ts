import { Component, OnInit } from '@angular/core';
import { EventService } from '../../services/event.service';
import { HttpService } from '../../services/http.service';
import { FilmDto } from '../../models/FilmDto';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {

  filmDetails: FilmDto = new FilmDto();
  isLoading = false;

  constructor(
    private httpService: HttpService,
    private eventService: EventService) { }

  ngOnInit(): void {
    this.isLoading = true;
    this.eventService.observeVisibleFilmDetailsId().subscribe(result => {
      if (result !== '-1') {
        this.httpService.GetFilmDetails(result).subscribe(details => {
          this.filmDetails = details;
          this.isLoading = false;
        });
      }
    });
  }

  goBack(): void {
    // As hidden is used not ngIf - no request will be sent to backend
    this.eventService.showList();
  }

}
