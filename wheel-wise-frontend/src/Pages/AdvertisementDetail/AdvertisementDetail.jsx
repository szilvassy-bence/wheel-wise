import {useParams} from 'react-router-dom'
import { useEffect, useState } from 'react'; 
import Card from 'react-bootstrap/Card';
import ListGroup from 'react-bootstrap/ListGroup';

function AdvertisementDetail(){
    console.log("Advertisement detail page");
    const [advertisement, setAdvertisement] = useState(null);

    const {id} = useParams();


    useEffect(()=>{
        async function fetchAd(){
            const resp = await fetch(`/api/Ads/${id}`);
            const ad = await resp.json();
            setAdvertisement(ad);
        }
        fetchAd();
    }, [id])

    return(
        <div style={{ display: 'flex', justifyContent: 'center' }}>
            {!advertisement && <p>Loading...</p>}
            {advertisement && (
                <Card id={advertisement.id} style={{ width: '50rem' }} >
                    <Card.Header>{advertisement.title}</Card.Header>
                    <Card.Body>
                        <ListGroup className="list-group-flush">
                            <ListGroup.Item>Year:   {advertisement.car.year}</ListGroup.Item>
                            <ListGroup.Item>Color:  {advertisement.car.color.name}</ListGroup.Item>
                            <ListGroup.Item>Price: {advertisement.car.price} EUR</ListGroup.Item>
                            <ListGroup.Item>Transmission: {advertisement.car.transmission.name}</ListGroup.Item>
                            <ListGroup.Item>Mileage: {advertisement.car.mileage} KM</ListGroup.Item>
                            <ListGroup.Item>Power: {advertisement.car.power} HP</ListGroup.Item>
                            <ListGroup.Item>Fuel Type: {advertisement.car.fuelType.name} HP</ListGroup.Item>
                        </ListGroup>
                    </Card.Body>
                </Card>
            )}
        
        </div>
    )
}
export default AdvertisementDetail
