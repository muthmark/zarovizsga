import axios from 'axios'
import React, { useEffect, useState } from 'react'

export default function Viewpoints() {
    let [locations, setLocations] = useState([])
    let [viewpoint, setViewpoint] = useState([])

    useEffect(() => {
        axios.get("https://viewpoint.jedlik.cloud/api/locations").then(resp => setLocations(resp.data))
    },[])

    function getViewPoints(viewpointName){
        axios.get(`https://viewpoint.jedlik.cloud/api/locations/${viewpointName}/viewpoints`).then(resp=> setViewpoint(resp.data))
    }

  return (
    <div>
 <div class="form">
        <div class="data">
            <label for="location">Hegység:</label>
            <select name="locationId" id="location" onChange={x => getViewPoints(x.target.value)}>
                <option value="">Kérem válasszon</option>
                {locations.map(x => <option value={x.locationName}>{x.locationName}</option>)}
            </select>
        </div>
    </div>

    <div id="viewpoints">
        {viewpoint.map(e => (
            <div class="viewpoint">
            <h2>{e.viewpointName}</h2>
            <div>
                <ul>
                    <li>
                        <label>Hegység:</label>
                        <span>{e.mountain}</span>
                    </li>
                    <li>
                        <label>Magassága:</label>
                        <span>{e.height} m</span>
                    </li>
                    <li>
                        <label>Épült:</label>
                        <span>{e.built}</span>
                    </li>
                </ul>
            </div>
            <p class="description">
                {e.description}
            </p>
            <div class="image">
                <img src={e.imageUrl} alt={e.imageUrl} />
            </div>
        </div>
        ))}
        
        </div>

    </div>
  )
}
