import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Movie } from 'src/app/models/movie';
import { ListingType } from 'src/app/models/listingType';
import { MovieService } from 'src/app/services/movie.service';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-movie',
  templateUrl: './add-movie.component.html',
  styleUrls: ['./add-movie.component.css'],
})
export class AddMovieComponent implements OnInit {
  formGroup: FormGroup;
  value = 1;
  listingTypes: ListingType[] = [
    {
      key: 1,
      value: 'NOW_SHOWING',
    },
    {
      key: 2,
      value: 'UP_COMING',
    },
  ];

  constructor(
    private fb: FormBuilder,
    private movieService: MovieService,
    private router: Router
  ) {
    this.formGroup = fb.group({
      title: new FormControl(null, [Validators.required]),
      language: new FormControl(null, [Validators.required]),
      location: new FormControl(null, [Validators.required]),
      rating: new FormControl(null, [Validators.required, Validators.max(10)]),
      plot: new FormControl(null, [Validators.required]),
      poster: new FormControl(null, [Validators.required]),
      listingType: new FormControl(null, [Validators.required]),
      imdbId: new FormControl(null, [Validators.required]),
    });
  }

  ngOnInit(): void {}

  onSubmit() {
    if (this.formGroup.valid) {
      this.movieService.addMovie(this.formGroup.value).subscribe((res: any) => {
        alert('Movie succesfully added');
        this.router.navigate(['/home']);
      });
    }
  }

  movieForm_Validation_Messages = {
    title: [{ type: 'required', message: 'Username is required' }],
    language: [{ type: 'required', message: 'Language is required' }],
    location: [{ type: 'required', message: 'Location is required' }],
    plot: [{ type: 'required', message: 'Plot is required' }],
    poster: [{ type: 'required', message: 'Poster is required' }],
    ls: [{ type: 'required', message: 'ListingType is required' }],
    imdbId: [{ type: 'required', message: 'IMDB Id is required' }],
  };
}
