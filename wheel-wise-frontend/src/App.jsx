import {useEffect, useState} from 'react'
import './App.css'

function App() {
    const [allCarData, setAllCarData] = useState([]);
    const fetchCarData = async () => {
        try {
            const response = await fetch('http://localhost:5242/api/Car');
            const data = await response.json();
            setAllCarData(data);
            Console.log(`$data is ${data}`)
        } catch (error) {
            console.error('Error fetching car data', error);
        }
    }


useEffect(() => {
    fetchCarData();
}, []);

return
(
    <div>
        <h1>Car Data</h1>
        {carData ? (
            <ul>
                {allCarData.map((car) => (
                    <li>{car.brand}</li>
                ))}
            </ul>
        ) : (
            <p>Loading...</p>
        )}
    </div>
)
    
}

export default App
