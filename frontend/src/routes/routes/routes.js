import HomePage from "../../pages/home";
import Login from "../../pages/login";
import Register from "../../pages/register";
import MovieView from "../../pages/movieView";
import SurpriseMe from "../../pages/surpriseMe";
import UserPage from "../../pages/user";

// Routes List
const routesList = [
  {
    path: "/",
    component: HomePage,
  },
  {
    path: "Login",
    component: Login,
  },
  {
    path: "Register",
    component: Register,
  },
  {
    path: "Movie",
    component: MovieView,
  },
  {
    path: "SurpriseMe",
    component: SurpriseMe,
  },
  {
    path: "User",
    component: UserPage,
  },
];

export default routesList; // Export the List
