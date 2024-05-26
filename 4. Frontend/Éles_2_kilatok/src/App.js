import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import 'bootstrap/dist/css/bootstrap.css';
import Navbar from './Navbar';
import Viewpoints from './Viewpoints';
import Rating from './Rating';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
      <Navbar />
        <Routes>
          <Route path='/' />
          <Route path='home' element={<Viewpoints />} />
          <Route path='rating' element={<Rating />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
