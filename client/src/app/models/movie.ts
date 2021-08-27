export interface Movie {
  language: string;
  location: string;
  plot: string;
  poster: string;
  soundEffects?: string[] | null;
  stills?: string[] | null;
  title: string;
  imdbID: string;
  listingType: string;
  imdbRating: string;
}
