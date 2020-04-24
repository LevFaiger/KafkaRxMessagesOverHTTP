import React,{ useState, useEffect }  from 'react';


function Main(props) {
    const [reservations, setReservations] = useState([]);
    const [error, setError] = useState(null);
    const [rows, SetRows] = useState(10)
    
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
     
       
       
        // POST request using fetch inside useEffect React hook
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                "Id":3,
              "Description":"R3"
            })
        };
       // fetch('http://localhost:49733/api/Reservations', requestOptions).then(response => response.json()).then(data => console.log(data));
    
    
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