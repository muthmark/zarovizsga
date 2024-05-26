import './App.css';
import 'bootstrap/dist/css/bootstrap.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import NavBar from './NavBar';
import Journeys from './Journeys';
import Registration from './Registration';

function App() {
  return (
    <>
       <BrowserRouter>
       <NavBar></NavBar>
      <Routes>
        <Route path="/" />
        <Route path="registration" element={<Registration/>}/>
        <Route path="journeys" element={<Journeys/>}/>
      </Routes>
    </BrowserRouter>
</>
  );
}

export default App;
