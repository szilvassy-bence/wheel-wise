import CardAd from '../../Components/Advertisement/CardAd';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

export default function AdvertisementList({allAdData, handleClick, title}) {
    return (
        <>
            <div className="mt-5">
                <h1>{title}</h1>
                <Row className="mt-3 gy-4">
                    {allAdData.map((ad) => (<Col md="6" xl="3" key={ad.id}>
                        <CardAd ad={ad} handleClick={handleClick}></CardAd>
                    </Col>))}
                </Row>
            </div>
            

        </>
    )

}
