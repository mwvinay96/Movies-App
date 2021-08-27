import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Movie } from '../models/movie';

@Injectable()
export class MovieService {
  constructor(private http: HttpClient) {
  }

  getAllMovies(): Observable<Movie[]> {
    return this.http
      .get('https://localhost:5001/api/Movies/allMovies')
      .pipe(map((data: any) => data));
  }

  getMovieById(imdbId: string): Observable<Movie> {
    return this.http
      .get('https://localhost:5001/api/Movies/movie?imdbID=' + imdbId)
      .pipe(map((data: any) => data));
  }

  addMovie(movieForm:any):Observable<void>{
    return this.http.post("https://localhost:5001/api/Movies",movieForm)
    .pipe(map((data: any) => data));
  }
}
