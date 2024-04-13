import CardAd from '../../Components/CardAd';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

export default function AdvertisementList({allAdData, handleClick, title}) {
    return (
        <Container>
            <div className="mt-5">
                <h2>{title}</h2>
                <Row className="mt-3 gy-4">
                    {allAdData.map((ad) => (
                        <Col md="6" xl="3" key={ad.id}>
                            <CardAd ad={ad} handleClick={handleClick}></CardAd>
                        </Col>))}
                </Row>
            </div>
        </Container>
    )

}
