import "./Advertisements.css";
import SimpleFilter from "../../Components/SimpleFilter";
import AdvertisementList from "../../Components/AdvertisementList";
import {useLoaderData, useNavigate} from "react-router-dom";
import {useEffect, useState} from "react";
import * as service from "./service.js";

export default function Advertisements(){
    
    const ads = useLoaderData();
    console.log(ads);

    const [allAdData, setAllAdData] = useState(ads);
    const [minPrice, setMinPrice] = useState(0);
    const [maxPrice, setMaxPrice] = useState(0);
    const navigate = useNavigate();
    
    // set the min and max prices of the current listing
    useEffect(() => {
        if (allAdData) {
            const fetchData = async () => {
                let minPrice = await service.getMin(allAdData);
                let maxPrice = await service.getMax(allAdData);
                if (minPrice == maxPrice){
                    maxPrice++;
                }
                setMinPrice(minPrice);
                setMaxPrice(maxPrice);
            };
            fetchData();
        }
    }, [allAdData]);

    function handleClick(e) {
        console.log(e.target);
        const id = e.target.id;
        console.log(`ad id: ${id}`);
        navigate(`/advertisement/${id}`);
    }
    
    return (
        <>
            <SimpleFilter
                setAllAdData={setAllAdData}
                minPrice={minPrice}
                maxPrice={maxPrice}
            />
            <AdvertisementList allAdData={allAdData} handleClick={handleClick} title={"Advertisement"}/>
        </>
    )
}