import CardAd from '../../Components/CardAd';
import "./AdvertisementList.css";

export default function AdvertisementList({allAdData, title, favorites, setFavorites, user}) {
    return (
            <div id="ad-list-wrapper">
                <h2>{title}</h2>
                <div id="ad-list-content">
                    {allAdData.map((ad) => (
                        <CardAd ad={ad} favorites={favorites} setFavorites={setFavorites} user={user} deleteButtonCheck={false}></CardAd>
                        ))}
                </div>
            </div>
    )
}
