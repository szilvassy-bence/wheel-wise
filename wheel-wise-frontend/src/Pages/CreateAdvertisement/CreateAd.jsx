import { useEffect, useState } from "react"; 
import { useParams, useNavigate } from "react-router-dom";
import "./CreateAd.css"
import Modal from "./AdSuccessfulModal/AdModal";

export default function CreateAd(){

    const params = useParams();
    const navigate = useNavigate();

    const [selectedBrand, setSelectedBrand] = useState(null);
    const [carTypeModels, setCarTypeModels] = useState(null);
    const[carProperties, setCarProperties] = useState({});
    const[user, setUser] = useState({});

    const [formData, setFormData] = useState({
        brand: "", model: "", color:"", fuelType:"", transmission:"", status:"New", year: 0, price: 0, mileage: 0, power: 0
    })

    const [checkedItems, setCheckedItems] = useState({});

    const [isModalOpen, setIsModalOpen] = useState(false);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const [carTypeResponse, colorResponse, fuelTypeResponse, transmissionTypeResponse, equipmentResponse, userResponse] = await Promise.all([
                    fetch("/api/CarType"),
                    fetch("/api/Color"),
                    fetch("/api/FuelType"),
                    fetch("/api/Transmission"),
                    fetch("/api/Equipment"),
                    fetch(`/api/user/${params.name}`)
                ]);
    
                const carTypeData = await carTypeResponse.json();
                const colorData = await colorResponse.json();
                const fuelTypeData = await fuelTypeResponse.json();
                const transmissionTypeData = await transmissionTypeResponse.json();
                const equipmentData = await equipmentResponse.json();
                const userData = await userResponse.json();
                console.log(userData)
    
                setCarProperties({
                    carTypes: carTypeData,
                    colors: colorData,
                    fuelTypes: fuelTypeData,
                    transmissionTypes: transmissionTypeData,
                    equipments: equipmentData
                });

                setFormData({
                    ...formData, color: colorData[0].name, fuelType: fuelTypeData[0].name, transmission: transmissionTypeData[0].name
                })
                setUser(userData);

            } catch (error) {
                console.error("Error fetching data", error);
            }
        };
    
        fetchData();
    }, []);
    

    function getUniqueBrands() {
        let brands = [];
        carProperties.carTypes.map(x => {
            if (!brands.includes(x.brand)) {
                brands.push(x.brand);
            }
        })
        return brands.sort();
    }

    function selectBrand(e) {
        console.log(e.target.value);
        setSelectedBrand(e.target.value);
        if (e.target.value === "Select Brand") {
            setFormData({...formData, brand: e.target.value, model: "Select Model"})
        } else {
            setFormData({...formData, brand: e.target.value})
        }
    }


    useEffect(() => {
        console.log(`selected brand: ${selectedBrand}`);
        if (selectedBrand != null) {
            let modelsFilteredByBrands = [];
            console.log(`selected brand: ${selectedBrand}`);
            carProperties.carTypes.forEach(c => {
                if (c.brand === selectedBrand) {
                    modelsFilteredByBrands.push(c.model);
                }
            });
            console.log(modelsFilteredByBrands)
            modelsFilteredByBrands.sort();
            setCarTypeModels(modelsFilteredByBrands);
        }
    }, [carProperties.carTypes, selectedBrand])


    function yearCounter() {
        let years = [];
        for (let i = new Date().getFullYear(); i >= 1900; i--) {
            years.push(i);
        }
        return years;
    }



    const handleEquipmentsChange = (event) => {
        console.log(event.target)
        setCheckedItems({
            ...checkedItems,
            [event.target.name]: event.target.checked
        });
        console.log(checkedItems);
    };

    function setSetselects(event, property){
        console.log(event.target.value);
        const { value } = event.target;
        setFormData(prevFormData => ({
            ...prevFormData,
            [property]: value
        }));
    }

    async function onSubmit(e) {
        e.preventDefault();
    
        console.log(formData);
        console.log(user);
        //console.log(carProperties)
        let dataTosend = {...formData,
            Equipments: checkedItems,
            UserName: user.identityUser.userName
        }
        console.log(dataTosend)


        const response = await fetch("/api/Ads", {
            method: "POST", headers: {"Content-Type": "application/json"}, body: JSON.stringify(dataTosend)
        });

        if (response.ok) {
            const data = await response.json();
            console.log(data);
            setIsModalOpen(true);
        } else { 
            console.error("Problem fetching data from server")
        }
      }

      const closeModal = () => {
        setIsModalOpen(false);
        console.log(params)
        navigate(`/users/${user.identityUser.userName}`)
    };
    

    return (
        <>
        {Object.keys(carProperties).length === 0 && <div>Loading</div>}
        {Object.keys(carProperties).length !== 0 &&
            <form className="CreateAdForm" onSubmit={onSubmit}>
                <fieldset><legend>Required Properties</legend>
                    <div className="control-group">
                        <div className="control">
                            <label className="ad-label" htmlFor="brand">Brand</label>
                            <select
                            name="brand"
                            id="brand"
                            value={formData.brand}
                            onChange={selectBrand}
                            required
                            >
                            <option value="" disabled>Select Brand</option>
                            {getUniqueBrands().map(b => (<option key={b} value={b}>{b}</option>))}
                            </select>
                        </div>

                        <div className="control">
                            <label className="ad-label" htmlFor="model">Model</label>
                            {(selectedBrand != null && selectedBrand != "Select Brand" ) && carTypeModels != null ? (
                            <select
                                name="model"
                                id="model"
                                value={formData.model}
                                onChange={e => setSetselects(e, "model")}
                                required
                                >
                                    <option value="" disabled>Select Model</option>
                                    {carTypeModels.map(m => (<option key={m} value={m}>{m}</option>))}
                            </select>) :(
                            <select
                                id="model"
                                disabled={true}>
                                <option>Select Model</option>
                            </select>)}
                        </div>

                    <div className="control">
                        <label className="ad-label" htmlFor="color">Color</label>
                        <select
                        name="color"
                        id="color"
                        value={formData.color}
                        onChange={e => setSetselects(e, "color")}
                        required
                        >
                        {carProperties.colors.map(color => (<option key={color.id} value={color.name}>{color.name}</option>))}
                        </select>
                    </div>

                    <div className="control">
                        <label className="ad-label" htmlFor="fuelType">Fuel Type</label>
                        <select
                        name="fuelType"
                        id="fuelType"
                        value={formData.fuelType}
                        onChange={e => setSetselects(e, "fuelType")}
                        required>
                        {carProperties.fuelTypes.map(fuel => (<option key={fuel.id} value={fuel.name}>{fuel.name}</option>))}
                        </select>
                    </div>

                    <div className="control">
                        <label className="ad-label" htmlFor="transmission">Transmission</label>
                        <select
                        name="transmission"
                        id="transmission"
                        value={formData.transmission}
                        onChange={e => setSetselects(e, "transmission")}
                        required
                        >
                        {carProperties.transmissionTypes.map(tr => (<option key={tr.id} value={tr.name}>{tr.name}</option>))}
                        </select>
                    </div>

                    <div className="control">
                        <label className="ad-label" htmlFor="status">Status</label>
                        <select
                        name="status"
                        id="status"
                        value={formData.status}
                        onChange={e => setSetselects(e, "status")}>
                        <option key="0" value="New">New</option>
                        <option key="1" value="Used">Used</option>
                        <option key="2" value="Broken">Broken</option>
                        </select>
                    </div>

                    <div className="control">
                        <label className="ad-label" htmlFor="year">Year</label>
                        <select
                            name="year"
                            id="year"
                            value={formData.year}
                            onChange={e => setSetselects(e, "year")}>
                            {yearCounter().map(year => (
                                <option key={year} value={year}>{year}</option>))}
                            </select>
                    </div>

                    <div className="control">
                        <label className="ad-label" htmlFor="price">Price</label>
                        <input type="number" min="0"
                            name="price"
                            id="price"
                            value={formData.price}
                            onChange={e => setSetselects(e, "price")}>
                            </input><span className="unit">Ft</span>
                    </div>

                    <div className="control">
                        <label className="ad-label" htmlFor="mileage">Mileage</label>
                        <input type="number"
                            name="mileage"
                            id="mileage"
                            value={formData.mileage}
                            onChange={e => setSetselects(e, "mileage")}>
                            </input><span className="unit">Km</span>
                    </div>

                    <div className="control">
                        <label className="ad-label" htmlFor="power">Power</label>
                        <input type="number" min="0"
                            name="power"
                            id="power"
                            value={formData.power}
                            onChange={(e)=> setSetselects(e, "power")}
                            >
                            </input><span className="unit">HP</span>
                    </div>
                    </div>
                    </fieldset>
           

                <div className="control checkbox-group">
                        <fieldset className="equipment-fieldset" ><legend>Equipments</legend>
                        <div className="checkbox-group">
                        {carProperties.equipments.map(eq => (
                        <div key={eq.id} className="checkbox-item">
                            <input 
                                type="checkbox" 
                                name={eq.id} 
                                id={eq.id} 
                                checked={checkedItems[eq.id] || false}
                                onChange={handleEquipmentsChange}
                                className="checkbox-input"
                                />
                                <label htmlFor={eq.id}>{eq.name}</label>
                        </div>
                         ))}
                         </div>
                         </fieldset>
                </div>

                <div className="buttons">
                    <button type="submit" className="submit-button">
                    Submit
                    </button>
                </div>

            </form>
            }
             {/* Modal */}
             <Modal isOpen={isModalOpen} onClose={closeModal} />
        </>
    )
}