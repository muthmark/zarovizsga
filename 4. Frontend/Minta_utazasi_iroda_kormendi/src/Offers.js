import axios from "axios"
import { useEffect, useState } from "react"

export default function Offers(){
    let [ingatlanok, setIngatlanok] = useState([])
    
    useEffect(
        () => {
            async function x(){ await axios.get('http://localhost:5000/api/ingatlan').then(response => setIngatlanok(response.data))}
            x()
        },
        []
    )
    

    return (
        <div>
            <div className="text-center"><h1>Ajánlataink</h1></div>
            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">Kategória</th>
                        <th scope="col">Leírás</th>
                        <th scope="col">Hirdetés dátuma</th>
                        <th scope="col">Tehermentes</th>
                        <th scope="col">Fénykép</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        ingatlanok.map(ingatlan => (
                            <tr>
                                <td>{ingatlan.kategoriaNev}</td>
                                <td>{ingatlan.leiras}</td>
                                <td>{ingatlan.hirdetesDatuma}</td>
                                <td>{ingatlan.tehermentes ? "Igen" : "Nem"}</td>
                                <td><img src={ingatlan.kepUrl} height={200}/></td>
                            </tr>
                        ))
                    }
                    
                </tbody>
            </table>

        </div>
    )
}