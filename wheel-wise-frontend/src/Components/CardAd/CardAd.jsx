import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';
import {ListGroup} from "react-bootstrap";
import "./CardAd.css";

function CardAd({ad, handleClick}) {
    
    return (
        <>
            <Card id={ad.id} className={ad.highlighted ? "highlighted ad-card" : "ad-card"}>
                {ad.highlighted && <Card.Img className="highlighted-img" variant="top" src="./highlighted-3.png"/>}
                <Card.Img variant="top" src="./car.jpg"/>
                <Card.Body>
                    <Card.Title>{ad.title}</Card.Title>
                        <ListGroup className="list-group-flush">
                            <ListGroup.Item> {ad.car.carType.brand} {ad.car.carType.model}</ListGroup.Item>
                            <ListGroup.Item>  {ad.car.year}</ListGroup.Item>
                            <ListGroup.Item>   {ad.car.price}</ListGroup.Item>
                            </ListGroup>
                    <Button id={ad.id} onClick={handleClick} variant="primary">See Advertisement</Button>
                </Card.Body>
            </Card>
        </>
    );
}

export default CardAd