import axios from 'axios'
import React, { useEffect, useState } from 'react'

export default function Rating() {
    let [viewpoints, setViewpoints] = useState([])
    let [chosenViewPoint, setChosenViewPoint] = useState("")
    let [email, setEmail] = useState("")
    let [rating, setRating] = useState(10)
    let [comment, setComment] = useState("")
    let [conditions, setConditions] = useState(false)
    let [error, setError] = useState("")

    useEffect(() => {
        axios.get("https://viewpoint.jedlik.cloud/api/viewpoints").then(resp => setViewpoints(resp.data))
    }, [])

    function errorMsg() {
        if (error === "") return
        else return (
            <div class="error">
                <span>{error}</span>
                <span onClick={() => setError("")}>x</span>
            </div>
        )
    }

    function postData() {
        if (chosenViewPoint === "") {
            setError("Válasszon egy kilátót!")
            return
        }
        if (email === "") {
            setError("Adja meg az email címét!")
            return
        }
        if (comment === "") {
            setError("Adjon meg megjegyzést!")
            return
        }
        if (conditions === false) {
            setError("Fogadja el a felhasználási feltételeket!")
            return
        }
        setError("")

        let postJSON = {
            viewpointId: parseInt(chosenViewPoint),
            email: email,
            rating: parseInt(rating),
            comment: comment
        }

        axios.post("https://viewpoint.jedlik.cloud/api/rate", postJSON).then(resp => (alert(`A kilátó értékelése ${resp.data.average}, ${resp.data.count} látogató véleménye alapján`), window.location.href = "/home")).catch(err => setError(err.request.response.message));
    }
    return (
        <>
            <h1 class="text-center">Kilátók értékelése</h1>
            <div class="form">

                <div class="data">
                    <label for="viewpoint">Kilátó:</label>
                    <select name="viewpointId" id="viewpoint" value={chosenViewPoint} onChange={e => setChosenViewPoint(e.target.value)}>
                        <option value="">Kérem válasszon</option>
                        {viewpoints.map(e => <option value={e.id}>{e.viewpointName} ({e.mountain})</option>)}
                    </select>
                </div>

                <div class="data">
                    <label for="email">Az Ön e-mail címe:</label>
                    <input type="text" id="email" name="email" value={email} onChange={e => setEmail(e.target.value)} />
                </div>

                <div class="data">
                    <label for="rating">Értékelés:</label>
                    <input type="range" min="1" max="10" id="rating" name="rating" value={rating} onChange={e => setRating(e.target.value)} />
                </div>

                <div class="data">
                    <label for="rating">Megjegyzsés:</label>
                    <textarea id="comment" name="comment" rows="3" value={comment} onChange={e => setComment(e.target.value)}></textarea>
                </div>

                <div class="data">
                    <input type="checkbox" id="acceptedConditions" name="acceptedConditions" onChange={e => setConditions(e.target.checked)} />
                    <label for="acceptedConditions">Felhasználási feltételeket elfogadom</label>
                </div>

                <div class="data">
                    <input type="button" value="Küldés" style={{ margin: "0 220px", width: "160px" }} onClick={e => postData()}/>
                </div>

                {errorMsg()}

            </div>

        </>
    )
}
