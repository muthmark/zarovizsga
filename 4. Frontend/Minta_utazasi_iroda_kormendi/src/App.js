import logo from './logo.svg';
import './App.css';

function App() {
  let text = "Pelda"
  return (
    <div class="container">
        <div class="start w-100">
            <h1 class="text-center pt-2 pt-lg-4">Á.L.B. Ingatlanügynöség</h1>
            <div class="row">
                <div class="col-12 col-sm-6 text-center">
                    <a class="btn btn-primary" href="/offers">Nézze meg kínálatunkat!</a>
                </div>
                <div class="col-12 col-sm-6 text-center">
                    <a class="btn btn-primary" href="/newad">Hirdessen nálunk!</a>
                </div>
            </div>
        </div>
    </div>
  );
}

export default App;
