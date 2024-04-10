import Card from 'react-bootstrap/Card';


function Advertisement({ad}){

    return (
        <>
          <Card>
            <Card.Img variant="top" src="" />
            <Card.Body>
              <Card.Text>
                {ad.car.year}
              </Card.Text>
            </Card.Body>
          </Card>
        </>
      );
}

export default Advertisement