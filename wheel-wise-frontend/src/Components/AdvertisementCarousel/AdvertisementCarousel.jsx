import "./AdvertisementCarousel.css";
import { useLoaderData, useNavigate } from "react-router-dom";
import { AuthContext, FavoriteContext } from "../../Pages/Layout/Layout";
import { useContext, useState, useEffect } from "react";
import CardAd from "../CardAd";


export default function AdvertisementCarousel() {

    const { user } = useContext(AuthContext);
    const [favorites, setFavorites, userAds, setUserAds] = useContext(FavoriteContext);
    const [highlightedAds, setHighlightedAds] = useState(null);
    const navigate = useNavigate();


    const fetchHighlighted = async () => {
        try {
            const res = await fetch("/api/Ads/highlighted");
            const data = await res.json();
            setHighlightedAds(data);
        } catch (e) {
            console.log(e);
        }
    }

    useEffect(() => {
        fetchHighlighted();
    }, []);

    async function handleClick() {
        console.log("Clicked.");
    }



    return (
        <div id="highlighted-ads-wrapper">
            <div id="highlighted-ads-content">
                <h1>Best offers</h1>
                <div className="carousel-container">
                    {highlightedAds && (
                        highlightedAds.map(ad => (
                            <CardAd ad={ad} favorites={favorites} setFavorites={setFavorites} user={user} userAds={userAds} setUserAds={setUserAds} deleteButtonCheck={false}></CardAd>
                        ))
                    )}
                </div>
            </div>
        </div>
    )
}