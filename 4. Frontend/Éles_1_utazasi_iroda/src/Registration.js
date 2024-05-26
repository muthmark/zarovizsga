import axios from "axios";
import React, { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";

export default function Registration() {
  const location = useLocation();
  const [valasztottUtazas, setValasztottUtazas] = useState(
    location.state === null ? "" : location.state.chosen
  );
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [resztvevok, setResztvevok] = useState(0);
  const [oltas, setOltas] = useState("");
  const [felhasznalasi, setFelhasznalasi] = useState(false);
  const [utazasok, setUtazasok] = useState([]);
  const [error, setError] = useState("");

  function errorMessage() {
    if (error === "") return;
    return (
      <div class="alert alert-danger alert-dismissible" role="alert">
        <strong>{error}</strong>
        <button
          type="button"
          class="btn-close"
          onClick={() => setError("")}
        ></button>
      </div>
    );
  }
  async function register() {
    if (valasztottUtazas === 0) {
      setError("Válassza ki az utazást!");
      return;
    }
    if (email === "") {
      setError("Adja meg az email cimét!");
      return;
    }
    if (resztvevok === 0 || resztvevok === "") {
      setError("Adja meg a résztvevők számát");
      return;
    }
    if (oltas === "") {
      setError("Adja meg az utolsó oltásának időpontját!");
      return;
    }
    if (felhasznalasi === false) {
      setError("Fogadja el a felhasználási feltételeket!");
      return;
    }
    setError("");
    axios
      .post("https://utazasi-iroda.jedlik.cloud/api/reserve", {
        journeyId: parseInt(valasztottUtazas),
        name: name,
        email: email,
        numberOfParticipants: parseInt(resztvevok),
        lastCovidVaccineDate: oltas,
        acceptedConditions: felhasznalasi,
      })
      .then(
        (x) => (
          alert(`Regisztrációját ${x.data.id}-s azonosítószámon rögzítettük.`),
          (window.location.href = "/journeys")
        )
      )
      .catch((err) => setError(err.request.response));
  }

  useEffect(() => {
    axios
      .get("https://utazasi-iroda.jedlik.cloud/api/journeys/short")
      .then((response) => setUtazasok(response.data));
  }, []);
  return (
    <div>
      <h1 class="text-center">Regisztráció</h1>
      <div class="form">
        <div class="data">
          <label for="journey">Utazás:</label>
          <select
            name="journeyId"
            id="journey"
            value={valasztottUtazas}
            onChange={(e) => setValasztottUtazas(e.target.value)}
          >
            <option value="">Kérem válasszon</option>
            {utazasok.map((utazas) => (
              <option value={utazas.id}>{utazas.destination}</option>
            ))}
          </select>
        </div>

        <div class="data">
          <label for="name">Az Ön neve:</label>
          <input
            type="text"
            id="name"
            name="name"
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
        </div>

        <div class="data">
          <label for="email">Az Ön e-mail címe:</label>
          <input
            type="text"
            id="email"
            name="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>

        <div class="data">
          <label for="numberOfParticipants">Résztvevők száma:</label>
          <input
            type="number"
            id="numberOfParticipants"
            name="numberOfParticipants"
            value={resztvevok}
            onChange={(e) => setResztvevok(e.target.value)}
          />
        </div>
        <div class="data">
          <label for="lastCovidVaccineDate">
            Utolsó COVID oltásának dátuma:
          </label>
          <input
            type="date"
            id="lastCovidVaccineDate"
            name="lastCovidVaccineDate"
            value={oltas}
            onChange={(e) => setOltas(e.target.value)}
          />
        </div>

        <div class="data">
          <input
            type="checkbox"
            id="acceptedConditions"
            name="acceptedConditions"
            value={felhasznalasi}
            onChange={(e) => setFelhasznalasi(e.target.checked)}
          />
          <label for="acceptedConditions">
            Felhasználási feltételeket elfogadom
          </label>
        </div>

        <div class="data">
          <input
            type="button"
            value="Küldés"
            style={{ margin: "0 220px", width: "160px" }}
            onClick={register}
          />
        </div>

        {errorMessage()}
      </div>
    </div>
  );
}
