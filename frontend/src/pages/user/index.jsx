import { useEffect, useState } from "react";
import axios from "axios";

import CardMovie from "../../components/cardMovie";

export default function UserPage() {
  const [userId] = useState(localStorage.getItem("userId"));
  const [dataUser, setDataUser] = useState([]);
  const [userMovieList, setUserMovieList] = useState([]);

  useEffect(() => {
    async function fetchData() {
      var movieList = [];
      try {
        const response = await axios.get(
          `${process.env.REACT_APP_USER}?guid=${userId}`
        );

        for (let i = 0; i < response.data.movies.length; i++) {
          let movieId = response.data.movies[i];

          try {
            const response = await axios.get(
              `${process.env.REACT_APP_MOVIE_INFO}?guid=${userId}&id=${movieId}`
            );
            let genreList = [];

            for (let j = 0; j < response.data.movie.genres.length; j++) {
              const jsonObj = response.data.movie.genres[j].name;

              const list = [];
              for (let key in jsonObj) {
                list.push(jsonObj[key]);
              }

              genreList.push(list);
            }

            let dataMovie = {
              id: response.data.movie.id,
              title: response.data.movie.title,
              genres: genreList,
              releaseDate: response.data.movie.releaseDate,
              posterPath: response.data.movie.posterPath,
              voteAverage: response.data.movie.voteAverage,
            };

            movieList.push(dataMovie);
          } catch (error) {
            console.log(error);
          }
        }

        setUserMovieList(movieList);
        setDataUser(response.data);
      } catch (error) {}
    }
    fetchData();
  }, [userId]);

  return (
    <div className="container mx-auto flex h-auto flex-col gap-10 py-28 text-white">
      <div className="flex items-center justify-between">
        <h2 className="font-semibold">{dataUser.name}</h2>
        <div className="flex gap-5">
          <button
            className="ease rounded border border-red-600 px-4 py-4 text-xs font-bold uppercase text-white shadow outline-none transition-all duration-150 hover:bg-red-700 hover:shadow-md"
            onClick={() => {
              let initUser = { logged: false };
              localStorage.setItem("logged", JSON.stringify(initUser));
              localStorage.setItem(
                "userId",
                "00000000-0000-0000-0000-000000000000"
              );
              window.location.pathname = "/";
            }}
          >
            Fazer Logoff
          </button>
        </div>
      </div>

      <div className="space-y-4">
        <h4>Meus filmes</h4>

        <div className="grid grid-cols-3 justify-items-center gap-5">
          {!!userMovieList && <CardMovie data={userMovieList} />}
        </div>
      </div>
    </div>
  );
}
