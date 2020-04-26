import React,{ useState, useEffect }  from 'react';
import { HubConnectionBuilder } from '@aspnet/signalr'

function Main(props) {
    const [reservations, setReservations] = useState([]);
    const [error, setError] = useState(null);
    const [rows, SetRows] = useState(10);

    const [hub, setHub] = useState(null)
  const [requester, setRequester] = useState(null)
    
    useEffect(() => {

      fetch('http://localhost:49733/api/Reservations')
        .then(response =>{
          if(response.ok){
            return response.json()
          }
         else{
           throw Error("Error in request");
         } 
        })
        .then(data => setReservations(data))
        .catch( err => 
          setError(err)
          );
     
       
       
 
          // SignalR implementation
         
     const hub = new HubConnectionBuilder()
     .withUrl("http://localhost:49733/reservationhub")
     //.configureLogging(signalR.LogLevel.Information)
     .build();
  
     hub.start()
     .then(() => console.log('Connection started!'))
     .catch(err => console.log('Error while establishing connection :('));;
 
     hub.on("reservationticks", data=>{
      setRequester(data)
      console.log(data);
    }) 
   
     /* hub.start().then(()=>{
      setHub(hub)
    })  */
    
    }, []);

   const  postResrvations = async ()=>{
      let index = reservations.length+1;
      for (let i =index ; i <index+ rows; i++) {
         let requestOptions = {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({
              "Id":i,
              "Description":"Reservation"+i.toString()
          })
      }
       

     let loadUsers =  await fetch('http://localhost:49733/api/Reservations', requestOptions);
    

    
    }
    
  }
  return (
    <div>
    {props.children(reservations)}

    <button onClick={postResrvations}>
      <h1>Create reservations: Amount:{rows}</h1>
    </button>
    </div>
  );
}

export default Main;