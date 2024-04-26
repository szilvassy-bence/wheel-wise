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
    const [adsMinPrice, setAdsMinPrice] = useState(0);
    const [adsMaxPrice, setAdsMaxPrice] = useState(0);
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
                setAdsMinPrice(minPrice);
                setAdsMaxPrice(maxPrice);
            };
            fetchData();
        }
    }, [allAdData]);

    
    return (
        <>
            <SimpleFilter
                setAllAdData={setAllAdData}
                adsMinPrice={adsMinPrice}
                adsMaxPrice={adsMaxPrice}
            />
            <AdvertisementList allAdData={allAdData} title={"Advertisement"}/>
        </>
    )
}