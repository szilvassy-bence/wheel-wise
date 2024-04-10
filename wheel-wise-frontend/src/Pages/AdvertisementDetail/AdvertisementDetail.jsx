import {useParams} from 'react-router-dom'

function AdvertisementDetail(){
    console.log("Advertisement detail page");
    const {id} = useParams();

    return(
        <div><h1>{id}</h1></div>
    )
}
export default AdvertisementDetail
