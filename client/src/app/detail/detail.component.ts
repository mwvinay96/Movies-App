import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Movie } from '../models/movie';
import { MovieService } from '../services/movie.service';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css'],
})
export class DetailComponent implements OnInit {
  imdbId: string = '';
  movie: Movie | null = null;
  constructor(
    private movieService: MovieService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((e) => {
      console.log(e);
      this.movieService.getMovieById(e.id).subscribe((e) => {
        this.movie = e;
        console.log(this.movie);
      });
    });
  }

  onBack() {
    this.router.navigate(['/home']);
  }
}
