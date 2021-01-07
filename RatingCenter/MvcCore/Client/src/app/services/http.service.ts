import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import {FilmDto} from '../models/FilmDto';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private httpClient: HttpClient) { }

  public GetFilms(): Observable<FilmDto[]>{
    return this.httpClient.get(`https://localhost:5001/api/films`) as Observable<FilmDto[]>;
  }

  public GetFilmDetails(id: string): Observable<FilmDto>{
    return this.httpClient.get(`https://localhost:5001/api/films/${id}`) as Observable<FilmDto>;
  }

  public GetAverageRating(id: string): Observable<number>{
    return this.httpClient.get(`https://localhost:5001/api/ratings/average/${id}`) as Observable<number>;
  }
}
