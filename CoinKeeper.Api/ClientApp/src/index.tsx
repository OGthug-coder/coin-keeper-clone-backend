import React from "react";
import { render } from "react-dom";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import App from "./App";
import Dashboard from "./components/Dashboard/Dashboard";
import Preferences from "./components/Preferences/Preferences";
import Register from "./components/Register/Register";

const rootElement = document.getElementById("root");

render(
  <React.StrictMode>
      <BrowserRouter>
          <Routes>
              <Route path="/" element={<App />}>
                  <Route path="dashboard" element={<Dashboard/>}/>
                  <Route path="preferences" element={<Preferences />}/>
              </Route>
              <Route path="/register" element={<Register/>}/>
          </Routes>
      </BrowserRouter>
  </React.StrictMode>,
  document.getElementById('root')
);

