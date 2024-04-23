import {useParams} from "react-router-dom"
import { useEffect, useState } from "react"; 
import {useLoaderData} from "react-router-dom";

function AdvertisementDetail(){
    console.log("Advertisement detail page");
    const [advertisement, setAdvertisement] = useState(null);

    const {id} = useParams();

    const ad = useLoaderData();
    console.log(ad);

    return(
        <div style={{ display: "flex", justifyContent: "center" }}>
            {!ad && <p>Loading...</p>}
            {ad && (
                <Card id={ad.id} style={{ width: "50rem" }} >
                    <Card.Header>{ad.title}</Card.Header>
                    <Card.Body>
                        <ListGroup className="list-group-flush">
                            <ListGroup.Item>Car Type: {ad.car.carType.brand} {ad.car.carType.model}</ListGroup.Item>
                            <ListGroup.Item>Year:   {ad.car.year}</ListGroup.Item>
                            <ListGroup.Item>Color:  {ad.car.color.name}</ListGroup.Item>
                            <ListGroup.Item>Price: {ad.car.price} EUR</ListGroup.Item>
                            <ListGroup.Item>Transmission: {ad.car.transmission.name}</ListGroup.Item>
                            <ListGroup.Item>Mileage: {ad.car.mileage} KM</ListGroup.Item>
                            <ListGroup.Item>Power: {ad.car.power} HP</ListGroup.Item>
                            <ListGroup.Item>Fuel Type: {ad.car.fuelType.name} HP</ListGroup.Item>
                        </ListGroup>
                    </Card.Body>
                </Card>
            )}
        
        </div>
    )
}
export default AdvertisementDetail
