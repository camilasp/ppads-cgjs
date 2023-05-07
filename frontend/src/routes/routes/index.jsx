import React from "react";
import { Route, BrowserRouter, Routes } from "react-router-dom";

import routesList from "./routes.js";

const Rotas = () => {
  return (
    <BrowserRouter>
      <Routes>
        {routesList.map((route, index) => (
          <Route key={index} path={route.path} element={<route.component />} />
        ))}
      </Routes>
    </BrowserRouter>
  );
};

export default Rotas;
