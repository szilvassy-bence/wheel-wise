import {useLoaderData, useParams} from "react-router-dom"
import { useEffect, useState } from "react"; 
import "./AdvertisementDetail.css"

function AdvertisementDetail(){
    const ad = useLoaderData();
    return(
        <div id="ad-detail-wrapper">
            <div>
                <h1>{ad.title}</h1>
                <p>{ad.car.carType.brand} {ad.car.carType.model}</p>
                <p>{ad.car.year}</p>
                <p>Car Type: {ad.car.carType.brand} {ad.car.carType.model}</p>
                <p>Year:   {ad.car.year}</p>
                <p>Color:  {ad.car.color.name}</p>
            </div>
            <div>
                <p>Price: {ad.car.price} EUR</p>
                <p>Transmission: {ad.car.transmission.name}</p>
                <p>Mileage: {ad.car.mileage} KM</p>
                <p>Fuel Type: {ad.car.fuelType.name} HP</p>
                <p>Power: {ad.car.power} HP</p>
            </div>
        </div>
    )
}
export default AdvertisementDetail
