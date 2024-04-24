import {useEffect, useState} from "react";
import {useNavigate, useLoaderData} from "react-router-dom";
import MainBanner from "../../Components/MainBanner"
import * as service from "./service.js";
import AdvertisementCarousel from "../../Components/AdvertisementCarousel"

function Home() {
    const navigate = useNavigate();
    
    return (
        <>
            <MainBanner/>
            <AdvertisementCarousel/>
        </>
    )
}

export default Home

