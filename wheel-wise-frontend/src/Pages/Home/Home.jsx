import { useEffect, useState } from 'react'
import Advertisement from '../../Components/Advertisement/Advertisement';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

function Home() {
    const [allAdData, setAllAdData] = useState(null);
    const fetchAdData = async () => {
        try {
            const response = await fetch('/api/Ads');
            const data = await response.json();
            setAllAdData(data);
            console.log(`$data is ${data[0].car.year}`)
        } catch (error) {
            console.error('Error fetching advertisement data', error);
        }
    }


    useEffect(() => {
        fetchAdData();
    }, []);

    return (
        <Container fluid>
        <div>
            <h1>Advertisements</h1>
            {allAdData ? (
                <Row>
                    {allAdData.map((ad) => (
                        <Col md="6" xl="3"><Advertisement ad={ad}></Advertisement></Col>
                    ))}
                    {allAdData.map((ad) => (
                        <Col md="6" xl="3">{ad.car.year}</Col>
                    ))}
                    {allAdData.map((ad) => (
                        <Col md="6" xl="3">{ad.car.year}</Col>
                    ))}
                    {allAdData.map((ad) => (
                        <Col md="6" xl="3">{ad.car.year}</Col>
                    ))}
                    {allAdData.map((ad) => (
                        <Col md="6" xl="3">{ad.car.year}</Col>
                    ))}
                    {allAdData.map((ad) => (
                        <Col md="6" xl="3">{ad.car.year}</Col>
                    ))}
                </Row>
            ) : (
                <p>Loading...</p>
            )}
        </div>
        </Container>
    )
}
export default Home

