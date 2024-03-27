import {useEffect, useState} from 'react'
import './App.css'

function App() {
    const [allCarData, setAllCarData] = useState(null);
    const fetchCarData = async () => {
        try {
            const response = await fetch('/api/Car');
            const data = await response.json();
            setAllCarData(data);
            console.log(`$data is ${data[0].brand}`)
        } catch (error) {
            console.error('Error fetching car data', error);
        }
    }


useEffect(() => {
    fetchCarData();
}, []);

return(
    <div>
        <h1>Car Data</h1>
        {allCarData ? (
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
