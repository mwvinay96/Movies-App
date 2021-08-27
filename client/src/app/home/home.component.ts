import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Movie } from '../models/movie';
import { MovieService } from '../services/movie.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  constructor(private movieService: MovieService, private router: Router) {}
  displayedColumns: string[] = [
    'language',
    'location',
    'title',
    'imdbID',
    'imdbRating',
  ];

  data: Movie[] = [];
  dataSource = new MatTableDataSource(this.data);

  @ViewChild(MatSort, { static: true })
  sort!: MatSort;

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  onRowClick(event: Movie) {
    this.router.navigate(['movie/' + event.imdbID]);
  }

  ngOnInit(): void {
    this.movieService.getAllMovies().subscribe((res: Movie[]) => {
      this.dataSource = new MatTableDataSource(res);
      this.dataSource.filterPredicate = function (
        data,
        filter: string
      ): boolean {
        return data.title.toLowerCase().includes(filter);
      };
      this.dataSource.sort = this.sort;
    });
  }
}
