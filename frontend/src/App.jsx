// Components
import HeaderMenu from "./components/headerMenu";
import Rotas from "./routes/routes";

function App() {
  const isLogged = JSON.parse(localStorage.getItem("logged"));

  if (!isLogged) {
    let initUser = { logged: false };
    localStorage.setItem("logged", JSON.stringify(initUser));
    localStorage.setItem("userId", "00000000-0000-0000-0000-000000000000");
  }

  return (
    <div className="h-screen bg-[#15161C]">
      <HeaderMenu></HeaderMenu>
      <Rotas></Rotas>
    </div>
  );
}

export default App;
