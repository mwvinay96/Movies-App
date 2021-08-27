import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Movie } from '../models/movie';

@Injectable()
export class MovieService {
  constructor(private http: HttpClient) {}

  baseUrl = 'http://localhost:3000/api/Movies';
  getAllMovies(): Observable<Movie[]> {
    return this.http
      .get(this.baseUrl + '/allMovies')
      .pipe(map((data: any) => data));
  }

  getMovieById(imdbId: string): Observable<Movie> {
    return this.http
      .get(this.baseUrl + '/movie?imdbID=' + imdbId)
      .pipe(map((data: any) => data));
  }

  addMovie(movieForm: any): Observable<void> {
    return this.http
      .post(this.baseUrl, movieForm)
      .pipe(map((data: any) => data));
  }
}
