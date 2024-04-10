import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';



function CardAd({ad,handleClick}){


    return (
        <>
          <Card id={ad.id}>
            <Card.Img variant="top" src="" />
            <Card.Body>
              <Card.Text>
                {ad.car.year}
              </Card.Text>
              <Button id={ad.id} onClick={handleClick} variant="primary">See Advertisement</Button>
            </Card.Body>
          </Card>
        </>
      );
}

export default CardAd