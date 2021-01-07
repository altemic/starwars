import { Component, OnInit } from '@angular/core';
import {HttpService} from '../../services/http.service';
import {MatTableDataSource} from '@angular/material/table';
import {FilmDto} from '../../models/FilmDto';
import {EventService} from '../../services/event.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  get displayedColumns(): string[] {
    return ['externalId', 'episodeId', 'title', 'releaseDate', 'details'];
  }

  // Not suitable for server side pagination
  dataSource: MatTableDataSource<FilmDto> = new MatTableDataSource<FilmDto>();

  constructor(
    private httpService: HttpService,
    private eventService: EventService) { }

  ngOnInit(): void {
    this.httpService.GetFilms().subscribe(films => {
      this.dataSource.data = films;
    });
  }

  showDetails(dto: FilmDto): void {
    if (dto.externalId != null) {
      this.eventService.showDetails(dto.externalId);
    }
  }
}
