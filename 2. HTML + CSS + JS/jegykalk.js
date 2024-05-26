function kalkulal(){
    let name = document.getElementById("nevInput").value
    let email = document.getElementById("emailInput").value
    let adatvedelmi = document.getElementById("szerzodes").checked
    let szektor = document.getElementById("typeInput").value
    let szemelyek = document.getElementById("szemelyek").value
    if(name == "" || email == "" || adatvedelmi == false) return alert("A név és e-mail mező kitöltése, valamint az adatvédelmi tájékoztató elfogadása kötelező!")

    let jegyarak = {
        1:250000,
        2:225000,
        3:200000,
        4:175000,
        5:150000,
        6:125000,
        7:100000
    }
    document.getElementById("eredmeny").innerText = jegyarak[szektor] * szemelyek
}