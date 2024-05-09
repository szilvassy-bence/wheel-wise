import { useContext, useState } from "react";
import CarTypeFormSelect from "../../Components/CarTypeFormSelect"
import { AuthContext } from "../Layout/Layout";


export default function AdminEditor() {

    const {user} = useContext(AuthContext);
    const [carTypes, setCarTypes] = useState(null);
    const [carTypeModel, setCarTypeModel] = useState({  brand: "", model: "" })

    const fetchCarTypeData = async () => {
        try {
            const response = await fetch("/api/CarType");
            const data = await response.json();
            setCarTypes(data);
            console.log(data);
        } catch (error) {
            console.error("Error fetching car type data", error);
        }
    }
    const handleInputChange = (e, setData) => {
        const { name, value } = e.target;
        setData((prevData) => ({
          ...prevData, [name]: value
        }))
      }

    async function addCarType(){
        console.log(carTypeModel.brand, carTypeModel.model)
        try {
            const response = await fetch(`/api/cartype`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${user.token}`
                },
                body: JSON.stringify(carTypeModel) 
            });
    
            if (!response.ok) {
                throw new Error("Can't post cartype");
            }
    
            console.log('New cartype added');
        } catch (err) {
            console.error(err);
        }            
    }


    return (
        <div id="simple-filter-wrapper">
            <div id="simple-filter-content">
                <h2>Editor</h2>
                <form onSubmit={addCarType}>
                    <h3>CarType</h3>
                    <label>
                        <span>Add </span>
                        <label>
                            <span>Brand: </span>
                            <input required name="brand" value={carTypeModel.brand} onChange={(e)=>handleInputChange(e, setCarTypeModel)}></input>
                        </label>
                        <label>
                            <span>Model: </span>
                            <input required name="model" value={carTypeModel.model} onChange={(e)=>handleInputChange(e, setCarTypeModel)}></input>
                        </label>
                    </label>
                    <button>Add CarType</button>
                </form>
                {/*<form onSubmit={e => submitForm(e)} >
                            <div id="simple-filter-form" >

                                <CarTypeFormSelect formData={formData}
                                                   selectBrand={selectBrand}
                                                   selectedBrand={selectedBrand}
                                                   getUniqueBrands={getUniqueBrands}
                                                   carTypeModels={carTypeModels}
                                                   selectModel={selectModel}/>

                                <label className="simple-filter-label simple-filter-items">
                                    <span>From Year</span>
                                    <select value={formData.fromYear} className="quick-form" name="from-year"
                                            placeholder="From year" onChange={e => setFromYear(e)}>
                                        <option>Min Year</option>
                                        {service.yearCounter().map(year => (
                                            <option key={year} value={year}>{year}</option>))}
                                    </select>
                                </label>
                                <label className="simple-filter-label simple-filter-items">
                                    <span>Till Year</span>
                                    <select value={formData.tillYear} className="quick-form" name="till-year"
                                            placeholder="Till year" onChange={e => setTillYear(e)}>
                                        <option>Max Year</option>
                                        {service.yearCounter().map(year => (
                                            <option key={year} value={year}>{year}</option>))}
                                    </select>
                                </label>
                                <PriceFormRange adsMinPrice={adsMinPrice} adsMaxPrice={adsMaxPrice} setFilterMinPrice={setFilterMinPrice} setFilterMaxPrice={setFilterMaxPrice}/>
                            </div>
                            <button className="form-submit-btn" type="submit">
                                Submit
                            </button>
                        </form>) 
                                        (<p>Loading...</p>)*/}
            </div>
        </div>
    )
}