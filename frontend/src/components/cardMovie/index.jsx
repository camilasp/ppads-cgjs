import { AiOutlineStar, AiOutlineCalendar } from "react-icons/ai";

const IMG_URL = "https://image.tmdb.org/t/p/w500/";

export default function CardMovie({ data }) {
  const MOVIES = data;

  return (
    <>
      {MOVIES.map((movie, movieIndex) => (
        <div
          key={movieIndex}
          className="flex gap-5 rounded bg-[#1e1f28] p-5 text-white"
        >
          <img
            className="w-2/5 rounded-xl"
            src={IMG_URL + movie.posterPath}
            alt="Movie Poster"
          />

          <div className="flex w-full flex-col justify-between">
            <div className="flex flex-col gap-2">
              <h4 className="font-semibold">{movie.title}</h4>
              <div className="flex gap-10 text-white opacity-70">
                <div className="flex items-center gap-2">
                  <AiOutlineStar />
                  <small>{movie.voteAverage}</small>
                </div>
                <div className="flex items-center gap-2">
                  <AiOutlineCalendar />
                  <small>{movie.releaseDate.split(" ")[0]}</small>
                </div>
              </div>
              <div className="flex flex-wrap gap-4">
                {movie.genres.map((genre, genreIndex) => (
                  <small
                    key={genreIndex}
                    className="rounded-lg border border-green-600 bg-green-900 px-2 py-1"
                  >
                    {genre}
                  </small>
                ))}
              </div>
            </div>

            <a
              className="grid w-auto cursor-pointer place-items-center gap-2 rounded-lg bg-blue-700 px-3 py-2 text-sm font-medium text-white hover:bg-blue-800"
              href={`/Movie?m=${movie.id}`}
            >
              Ver mais +
            </a>
          </div>
        </div>
      ))}
    </>
  );
}
