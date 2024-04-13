import {useEffect, useState} from "react";
import {useNavigate} from "react-router-dom";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import AdvertisementList from "../../Components/AdvertisementList"
import SimpleFilter from "../../Components/SimpleFilter";
import MainBanner from "../../Components/MainBanner"
import * as service from "./service.js";

function Home() {
    const [allAdData, setAllAdData] = useState(null);
    const [minPrice, setMinPrice] = useState(0);
    const [maxPrice, setMaxPrice] = useState(0);
    const navigate = useNavigate();

    const fetchAdData = async () => {
        try {
            const response = await fetch("/api/Ads");
            const data = await response.json();
            setAllAdData(data);
            console.log(data);
        } catch (error) {
            console.error("Error fetching advertisement data", error);
        }
    }
    
    // fetch all car data initially
    useEffect(() => {
        fetchAdData();
    }, []);

    // set the min and max prices of the current listing
    useEffect(() => {
        if (allAdData){
            setMinPrice(service.getMin(allAdData));
            setMaxPrice(service.getMax(allAdData));
        }
    }, [allAdData]);

    function handleClick(e) {
        console.log(e.target);
        const id = e.target.id;
        console.log(`ad id: ${id}`);
        navigate(`/advertisement/${id}`);
    }

    return (<>
        {/* big banner comes here */}
        <MainBanner/>
        {allAdData ? (
            <>
                <SimpleFilter 
                    setAllAdData={setAllAdData}
                    minPrice={minPrice}
                    maxPrice={maxPrice}
                />
                <AdvertisementList allAdData={allAdData} handleClick={handleClick} title={"Advertisement"}/>
            </>
                )
                :
                (
                <p>Loading...</p>
                )}

            
        </>)
}

export default Home

