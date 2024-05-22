import { useEffect, useState, useContext } from "react"; 
import { AuthContext, FavoriteContext } from "../Layout/Layout";
import { useLoaderData, useParams, useNavigate } from "react-router-dom";
import AdvertisementForm from "../../Components/AdvertisementForm/AdvertisementForm";
import Modal from "../../Components/AdSuccessfulModal/AdModal";
import "./CreateAd.css"

export default function CreateOrModifyAd(){

    const params = useParams();
    const navigate = useNavigate();
    const adProps = useLoaderData();

    const { user } = useContext(AuthContext);
    const [favorites, setFavorites, userAds, setUserAds] = useContext(FavoriteContext);
    const [isModalOpen, setIsModalOpen] = useState(false);

    const[adToUpdate, setAdToUpdate] = useState(null)
    const[adEquipmentsToUpdate, setAdEquipmentsToUpdate] = useState(null)

    useEffect(() => {
        if (params.adid) {
            const fetchAdForUpdate = async () => {
                try {
                    const response = await fetch(`/api/Ads/${params.adid}`);
                    const data = await response.json();
                    console.log(data)
                    const equipmentsFromData = Object.fromEntries(
                        data.car.equipments.map(eq => [eq.id, true])
                    );
                    setAdEquipmentsToUpdate(equipmentsFromData)
                    setAdToUpdate({
                        brand: data.car.carType.brand,
                        model: data.car.carType.model,
                        color: data.car.color.name,
                        fuelType: data.car.fuelType.name,
                        transmission: data.car.transmission.name,
                        status: data.car.status === 0 ? "New" : data.car.status === 1 ? "Used" : "Broken",
                        year: data.car.year,
                        price: data.car.price,
                        mileage: data.car.mileage,
                        power: data.car.power,
                        title: data.title,
                        description: data.description
                    })
                } catch (error) {
                    console.error("Error fetching data", error);
                }
            }
            fetchAdForUpdate();
        }
    }, [params]);

    async function advertisementPost(dataToSend){
        try {
            const response = await fetch("/api/Ads", {
                method: "POST", 
                headers: {
                    "Content-Type": "application/json", 
                    'Authorization': `Bearer ${user.token}`
                }, 
                body: JSON.stringify(dataToSend)
            });
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`)
            }
            const data = await response.json();
            setUserAds([...userAds, data]);
            setIsModalOpen(true);
        } catch (error) {
            console.error(error)
        }
    }

    async function advertisementModification(dataToSend){
        try {
            const response = await fetch(`/api/Ads/${params.adid}`, {
                method: "PUT", 
                headers: {
                    "Content-Type": "application/json", 
                    'Authorization': `Bearer ${user.token}`
                }, 
                body: JSON.stringify(dataToSend)
            });

            if (!response.ok) {
                throw new Error(response.status)
            }
            const data = await response.json();
            console.log(data)
            const updatedUserAds = userAds.map(ad => (ad.id === data.id ? data : ad));
            setUserAds(updatedUserAds);
            setIsModalOpen(true);
        } catch (error) {
            console.error(error)
        }
    }

    async function handleAdCreationOrModification(data){
        let dataTosend = {...data,
            UserName: user.userName
        }
        console.log(dataTosend)
        
        if (!params.adid) {
            await advertisementPost(dataTosend)
        } else {
            await advertisementModification(dataTosend)
        }
      }

      const closeModal = () => {
        setIsModalOpen(false);
        navigate(`/users/${user.userName}`)
    };

    return(
        <>
            {!params.adid && <AdvertisementForm adProps={adProps} handleSubmit={handleAdCreationOrModification}/>}
            {params.adid && adToUpdate !== null && <AdvertisementForm adProps={adProps} updateData={adToUpdate} 
            equipmentsToUpdate={adEquipmentsToUpdate} handleSubmit={handleAdCreationOrModification}/>}
            <Modal isOpen={isModalOpen} onClose={closeModal} isCreate={!params.adid ? true : false}/>
        </>

    )
}