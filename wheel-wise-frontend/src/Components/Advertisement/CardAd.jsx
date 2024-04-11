import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';
import {ListGroup} from "react-bootstrap";


function CardAd({ad, handleClick}) {


    return (
        <>
            <Card id={ad.id}>
                <Card.Img variant="top" src=""/>
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