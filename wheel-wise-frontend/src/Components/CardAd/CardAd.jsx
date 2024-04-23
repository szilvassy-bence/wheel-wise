import {ListGroup} from "react-bootstrap";
import "./CardAd.css";

function CardAd({ad, handleClick}) {
    
    return (
        <>
            <div id={ad.id} className={ad.highlighted ? "highlighted ad-card" : "ad-card"}>
                {ad.highlighted && <img className="highlighted-img" variant="top" src="./highlighted-3.png"/>}
                <div className="card-img-wrapper">
                    <img className="card-img" variant="top" src="./car.jpg"/>
                </div>
                <div className="card-content-wrapper">
                    <h3>{ad.title}</h3>
                    <div className="card-price">
                        <svg class="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15.583 8.445h.01M10.86 19.71l-6.573-6.63a.993.993 0 0 1 0-1.4l7.329-7.394A.98.98 0 0 1 12.31 4l5.734.007A1.968 1.968 0 0 1 20 5.983v5.5a.992.992 0 0 1-.316.727l-7.44 7.5a.974.974 0 0 1-1.384.001Z"/>
                        </svg>
                        <h4>{ad.car.price} Ft</h4>
                    </div>
                    <ul>
                        <li>{ad.car.carType.brand} {ad.car.carType.model}</li>
                        <li>{ad.car.year}</li>
                    </ul>
                </div>
                <div className="card-footer">
                    <button className="card-btn card-detail-btn">Details</button>
                    <button className="card-btn card-favorite-btn">
                        <svg class="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="none" viewBox="0 0 24 24">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 7.757v8.486M7.757 12h8.486M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z"/>
                        </svg>
    
                    </button>
                    <button className="card-btn card-favorite-btn">
                        <svg class="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="none" viewBox="0 0 24 24">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M7 11c.889-.086 1.416-.543 2.156-1.057a22.323 22.323 0 0 0 3.958-5.084 1.6 1.6 0 0 1 .582-.628 1.549 1.549 0 0 1 1.466-.087c.205.095.388.233.537.406a1.64 1.64 0 0 1 .384 1.279l-1.388 4.114M7 11H4v6.5A1.5 1.5 0 0 0 5.5 19v0A1.5 1.5 0 0 0 7 17.5V11Zm6.5-1h4.915c.286 0 .372.014.626.15.254.135.472.332.637.572a1.874 1.874 0 0 1 .215 1.673l-2.098 6.4C17.538 19.52 17.368 20 16.12 20c-2.303 0-4.79-.943-6.67-1.475"/>
                        </svg>
    
    
                    </button>
                    
                </div>
                
            </div>
        </>
    );
}

export default CardAd