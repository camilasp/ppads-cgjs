import { useEffect, useState } from "react";
import axios from "axios";
import CardMovie from "../../components/cardMovie";

export default function HomePage() {
  const [dataMovie, setDataMovie] = useState([]);

  useEffect(() => {
    async function fetchData() {
      try {
        const response = await axios.get(process.env.REACT_APP_POPULAR_MOVIES);
        setDataMovie(response.data.slice(0, -2));
      } catch (error) {
        console.log(error);
      }
    }
    fetchData();
  }, []);

  return (
    <div className="container mx-auto flex h-auto flex-col gap-10 py-28">
      <h2 className="font-semibold text-white">Populares</h2>
      <div className="grid grid-cols-3 justify-items-center gap-5">
        {!!dataMovie && <CardMovie data={dataMovie} />}
      </div>
    </div>
  );
}
