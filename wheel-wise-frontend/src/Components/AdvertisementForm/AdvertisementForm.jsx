import { useEffect, useState, useContext, useCallback } from "react";
import { yearCounter } from "../../Pages/CreateAdvertisement/service";

export default function AdvertisementForm({ adProps, handleSubmit, updateData, equipmentsToUpdate }){

    const [selectedBrand, setSelectedBrand] = useState(updateData? updateData.brand : null);
    const [carTypeModels, setCarTypeModels] = useState(null);

    const [formData, setFormData] = useState({
        brand: updateData ? updateData.brand : "", 
        model: updateData ? updateData.model : "", 
        color: updateData ? updateData.color : adProps ? adProps.colors[0].name : "", 
        fuelType: updateData ? updateData.fuelType : adProps ? adProps.fuelTypes[0].name : "", 
        transmission: updateData ? updateData.transmission : adProps ? adProps.transmissionTypes[0].name : "", 
        status: updateData ? updateData.status : "New", 
        year: updateData ? updateData.year : 2024, 
        price: updateData ? updateData.price : 0, 
        mileage: updateData ? updateData.mileage :0, 
        power: updateData ? updateData.power: 0, 
        title: updateData ? updateData.title: "", 
        description: updateData ? updateData.description: ""
    })
    console.log(equipmentsToUpdate)

    const [checkedItems, setCheckedItems] = useState(equipmentsToUpdate ? equipmentsToUpdate : {});

    const getUniqueBrands = useCallback(() => {
        let brands = [];
        adProps.carTypes.map(x => {
            if (!brands.includes(x.brand)) {
                brands.push(x.brand);
            }
        })
        return brands.sort();
    },[adProps.carTypes]);


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
            adProps.carTypes.forEach(c => {
                if (c.brand === selectedBrand) {
                    modelsFilteredByBrands.push(c.model);
                }
            });
            console.log(modelsFilteredByBrands)
            modelsFilteredByBrands.sort();
            setCarTypeModels(modelsFilteredByBrands);
            setFormData(prevFormData => ({
                ...prevFormData,
                model: modelsFilteredByBrands[0]
            }))
        }
    }, [adProps.carTypes, selectedBrand])


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

    function onSubmit(e) {
        e.preventDefault();

        let data = {...formData,
            Equipments: checkedItems,
        }
        console.log(data)
        handleSubmit(data)        
    }

    return (
        <>
        {Object.keys(adProps).length !== 0 &&
            <form className="create-ad-form" onSubmit={onSubmit}>
                 <fieldset><legend>Title</legend>
                        <div>
                            <label className="ad-label" htmlFor="title">Title</label>
                            <input type="text"
                                name="title"
                                id="title"
                                value={formData.title}
                                onChange={e => setSetselects(e, "title")}
                                placeholder="Short title">
                                </input>
                        </div>
                    </fieldset>
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
                        {adProps.colors.map(color => (<option key={color.id} value={color.name}>{color.name}</option>))}
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
                        {adProps.fuelTypes.map(fuel => (<option key={fuel.id} value={fuel.name}>{fuel.name}</option>))}
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
                        {adProps.transmissionTypes.map(tr => (<option key={tr.id} value={tr.name}>{tr.name}</option>))}
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
                        {adProps.equipments.map(eq => (
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

                         <fieldset className="description-fieldset"><legend>Description</legend>
                            <div >
                                <label htmlFor="description"></label>
                                <textarea
                                    name="description"
                                    id="description"
                                    value={formData.description}
                                    onChange={e => setSetselects(e, "description")}
                                    placeholder="Add a description for your ad!">
                                </textarea>
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
        </>
    )
}