import React from 'react';
import logo from './logo.svg';
import './App.css';
import Main from './Main'

function App() {
  return (
    <div className="App">
      <Main>
        {(reservations) => {
          return (
          <div>
            <h4>List of reservations</h4>
            {reservations.map(reservation => (
              <div><span>description:</span><span>{reservation.description}</span>
                <span>id:</span><span>{reservation.id}</span>
                <span>checkInDate:</span><span>{reservation.checkInDate}</span>
              </div>
            ))}
          </div>)
          
        }
      }
      </Main>
    </div>
  );
}

export default App;
