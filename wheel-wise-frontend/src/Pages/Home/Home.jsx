import {useEffect, useState} from 'react';
import {useNavigate} from 'react-router-dom';
import CardAd from '../../Components/Advertisement/CardAd';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import AdvertisementList from "../../Components/AdvertisementList"
import AdFilter from "../../Components/AdFilter/index.js";


function Home() {
    const [allAdData, setAllAdData] = useState(null);
    const navigate = useNavigate();

    const fetchAdData = async () => {
        try {
            const response = await fetch('/api/Ads');
            const data = await response.json();
            setAllAdData(data);
            console.log(data);
        } catch (error) {
            console.error('Error fetching advertisement data', error);
        }
    }


    useEffect(() => {
        fetchAdData();
    }, []);

    function handleClick(e) {
        console.log(e.target);
        const id = e.target.id;
        console.log(`ad id: ${id}`);
        navigate(`/advertisement/${id}`);
    }

    return (<Container fluid>
            <div>
                {/* big banner comes here */}
                <AdFilter/>
                {allAdData ? (
                    
                    <AdvertisementList allAdData={allAdData} handleClick={handleClick} title={"Advertisement"}/>
                    )
                    :
                    (
                    <p>Loading...</p>
                    )}

            </div>
        </Container>)
}

export default Home

