import axios from "axios"
import moment from "moment"
import { useEffect, useState } from "react"

export default function NewAd(){
    const [kategoriak, setKategoriak] = useState([])
    const [valasztottKategoria, setValasztottKategoria] = useState(0)
    const datum = moment().format("YYYY-MM-DD")
    const [leiras, setLeiras] = useState("")
    const [tehermentes, setTehermentes] = useState(true)
    const [fenykep, setFenykep] = useState("")
    const [error, setError] = useState("")

    function errorMessage(){
        if (error === "") return
        return (
            <div class="alert alert-danger alert-dismissible" role="alert">
                    <strong>{error}</strong>
                    <button type="button" class="btn-close" onClick={() => setError("")}></button>
            </div>
        )
    }

    async function sendAd(){
        if (valasztottKategoria === 0){
            setError("Válassza ki a kategóriát!")
            return
        }
        if (leiras === ""){
            setError("Adjon meg egy leírást!")
            return
        }
        if (fenykep === ""){
            setError("Adjon meg egy fényképet!")
            return
        }
        setError("")
        axios.post('http://localhost:5000/api/ujingatlan', 
        {
            kategoriaId: parseInt(valasztottKategoria),
            leiras: leiras,
            hirdetesDatuma: datum,
            tehermentes: tehermentes,
            kepUrl: fenykep
        }).then(_ => window.location.href = '/offers').catch(err => setError(err.response.data.title))
    }


    useEffect(
        () => {
            async function x(){ await axios.get('http://localhost:5000/api/kategoriak').then(response => setKategoriak(response.data))}
            x()
        },
        []
    )
    return (
        <div class="container">
        <h2 class="mb-4 text-center">Új hirdetés elküldése</h2>
        <div class="row">
            <div class="offset-lg-3 offset-md-2 col-lg-6 col-md-8 col-12">
                <div class="mb-3">
                    <label for="category" class="form-label">Ingatlan kategóriája</label>
                    <select class="form-select" name="kategoriaId" value={valasztottKategoria} onChange={e => setValasztottKategoria(e.target.value)}>
                        <option value="0">Kérem válasszon</option>
                        {kategoriak.map(kategoria => <option value={kategoria.id}>{kategoria.megnevezes}</option>)}
                    </select>
                </div>

                <div class="mb-3">
                    <label for="date" class="form-label">Hirdetés dátuma</label>
                    <input type="date" class="form-control" name="hirdetesDatuma" readOnly value={datum}/>
                </div>
                <div class="mb-3">
                    <label for="description" class="form-label">Ingatlan leírása</label>
                    <textarea class="form-control" name="leiras" rows="3" value={leiras} onChange={e => setLeiras(e.target.value)}></textarea>
                </div>
                <div class="form-check mb-3">
                    <input class="form-check-input" type="checkbox" name="tehermentes" checked value={tehermentes} onChange={e => setTehermentes(e.target.value)}/>
                    <label class="form-check-label" for="creditFree">Tehermentes ingatlan</label>
                </div>
                <div class="mb-3">
                    <label for="pictureUrl" class="form-label">Fénykép az ingatlanról</label>
                    <input type="url" class="form-control" name="kepUrl" value={fenykep} onChange={e => setFenykep(e.target.value)}/>
                </div>
                <div class="mb-3 text-center">
                    <button class="btn btn-primary px-5" onClick={sendAd}>Küldés</button>
                </div>

                {errorMessage()}
            </div>
        </div>
    </div>
    )
}