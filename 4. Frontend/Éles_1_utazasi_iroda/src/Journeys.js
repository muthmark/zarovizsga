import axios from "axios";
import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";

export default function Journeys() {
  let [journeys, setJourneys] = useState([]);

  useEffect(() => {
    axios
      .get("https://utazasi-iroda.jedlik.cloud/api/journeys")
      .then((response) => setJourneys(response.data));
  }, []);
  return (
    <div style={{ textAlign: "center" }}>
      <h1>Kínálatunk</h1>
      <table class="table">
        <thead>
          <tr>
            <th scope="col">Ország</th>
            <th scope="col">Utazási mód</th>
            <th scope="col">Indulás</th>
            <th scope="col">Max létszám</th>
            <th scope="col">Leírás</th>
            <th scope="col">Fénykép</th>
          </tr>
        </thead>
        <tbody>
          {journeys.map(x => (
          <tr>
            <td>{x.country}</td>
            <td>{x.vehicle.type}</td>
            <td>{x.departure}</td>
            <td>{x.capacity}</td>
            <td>{x.description}<button><Link to="/registration" state={{chosen: x.id}} style={{all: "unset"}}>Érdekel</Link></button></td>
            <td>
              <img src={x.pictureUrl} height={200} alt="" />
            </td>
          </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
