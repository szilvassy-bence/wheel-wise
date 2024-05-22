import { useContext, useState, useEffect } from "react";
import { AuthContext } from "../Layout/Layout";
import "./AdminEditor.css";


export default function AdminEditor() {

    //ALL
    const { user } = useContext(AuthContext);
    const [activeTab, setActiveTab] = useState('cartype');

    //CARTYPE
    const [carTypes, setCarTypes] = useState([]);
    const [carTypeModel, setCarTypeModel] = useState({ brand: "", model: "" });
    const [selectedBrand, setSelectedBrand] = useState(null);
    const [selectedModel, setSelectedModel] = useState(null);
    const [selectedCarTypeModels, setSelectedCarTypeModels] = useState(null);

    //COLOR
    const [colors, setColors] = useState([]);
    const [colorModel, setColorModel] = useState({ name: "" });
    const [selectedCarProperty, setSelectedCarProperty] = useState(null);

    //EQUIPMENT
    const [equipments, setEquipments] = useState([]);

    //ALL
    const [propModel, setPropModel] = useState(
        activeTab === 'cartype' ? { brand: "", model: "" } :
            activeTab === 'color' ? { name: "" } :
                activeTab === 'equipment' ? { type: "", name: "" } :
                    {}
    );
    const [propertyList, setPropertyList] = useState([]);
    const [uniqueProperty, setUniqueProperty] = useState(null);
    const [selectedOptions, setSelectedOptions] = useState(null);

    // METHOD FOR ALL CAR PROPERTIES (FETCH, ADD, SELECT INPUT, DELETE, TAB SWITCH)
    const handleInputChange = (e, setData) => {

        const { name, value } = e.target;

        setData((prevData) => ({
            ...prevData, [name]: value
        }));

    }


    const fetchCarProperties = async (property, setPropList) => {
        try {
            const response = await fetch(`/api/${property}`);
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            const data = await response.json();
            setPropList(data);

        } catch (error) {
            console.error(`Error fetching ${property} data`, error);
        }
    };

    //FETCH AT TABSWITCH
    useEffect(() => {

        if (activeTab === 'cartype') {
            fetchCarProperties('cartype', setCarTypes);
            setUniqueProperty("brand");
        }

        if (activeTab === 'color') {
            fetchCarProperties('color', setColors);
            setUniqueProperty(null);
        }

        if(activeTab === 'equipment') {
            fetchCarProperties('equipment', setPropertyList);
            setUniqueProperty("type");
        }

    }, [activeTab]);



    //ADD FOR ALL
    async function addCarProperty(e, carProperty, propModel, setPropList) {

        e.preventDefault();

        try {
            const response = await fetch(`/api/${carProperty}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${user.token}`
                },
                body: JSON.stringify(propModel)
            });

            if (!response.ok) {
                throw new Error(`Can't post ${propModel}`);
            }

            console.log(`New ${propModel} added`);

            await fetchCarProperties(carProperty, setPropList);

        } catch (err) {

            console.error(err);

        }
    }


    //SELECT FOR ALL
    function selectCarProperty(e) {

        const select = e.target.value;

        setSelectedCarProperty(select);

        console.log(selectedCarProperty);

    }

    //DELETE FOR ALL 
    //(propertyName for controller name in the url, 
    //optionName is the name of the options in the select input, 
    //setProplist is the list of the current property type)
    async function deleteCarProperty(e, propertyName, optionName, setPropList) {

        e.preventDefault();

        const select = e.target.elements[optionName];

        const selectedOption = select.options[select.selectedIndex];

        const propertyId = selectedOption.id;

        if (!propertyId) {
            console.error(`No ${propertyName} selected to delete.`);
            return;
        }

        try {
            const response = await fetch(`/api/${propertyName}/${propertyId}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${user.token}`
                }
            });

            if (!response.ok) {
                throw new Error(`Error ${response.status}: Can't delete ${propertyName}`);
            }

            console.log(`${selectedCarProperty} deleted`);

            await fetchCarProperties(propertyName, setPropList);

        } catch (err) {
            console.error('Error:', err);
            alert(`Failed to delete ${propertyName}: ${err.message}`);
        }

    }


    //SET TAB AND RESETING THE MODEL SO IT WILL TAKE ONLY THE CURRENT TABS MODEL VALUES
    function setTab(e, tabName) {

        e.preventDefault();

        setActiveTab(tabName);

        setCarTypeModel((prevData) => ({
            ...prevData, brand: "", model: ""
        }));

        setColorModel((prevData) => ({
            ...prevData, name: ""
        }));

        setPropModel(activeTab === 'cartype' ? { brand: "", model: "" } :
        activeTab === 'color' ? { name: "" } :
            activeTab === 'equipment' ? { type: "", name: "" } :
                {});

        setSelectedCarProperty("");
    }

    //METHODS NECESSARY ONLY FOR CARTYPE

    function getUniqueBrands() {

        let brands = [];

        carTypes.map(x => {
            if (!brands.includes(x.brand)) {
                brands.push(x.brand);
            }
        })

        return brands.sort();
    }

    useEffect(() => {

        getUniqueBrands();

    }, [carTypes])

    function selectBrand(e) {

        console.log(e.target.value);

        setSelectedBrand(e.target.value);
    }

    useEffect(() => {

        if (selectedBrand != null) {

            let modelsFilteredByBrands = [];

            carTypes.forEach(c => {
                if (c.brand === selectedBrand) {
                    modelsFilteredByBrands.push(c);
                }
            });

            modelsFilteredByBrands.sort();

            setSelectedCarTypeModels(modelsFilteredByBrands);
        }
    }, [selectedBrand, carTypes])


    //EQUIPMENT 

    //GET MULTIPLE TYPES WITH THE SAME NAME ONLY ONCE IN THE SELECTION OPTIONS
    //(need the list of the car property and the name of the multiple type)
    function getUniqueSelectionTypes(propList, uniqueProp) {

        let selection = [];

        propList.map(x => {
            if (!selection.includes(x[uniqueProp])) {
                selection.push(x[uniqueProp]);
            }
        })

        return selection.sort();
    }

    useEffect(() => {

        if (uniqueProperty !== null) {
            getUniqueSelectionTypes(propertyList, uniqueProperty);
        }

    }, [propertyList])

    useEffect(() => {

        if (selectedCarProperty !== null && uniqueProperty !== null) {

            let filteredSelection = [];

            propertyList.forEach(x => {
                if (x[uniqueProperty] === selectedCarProperty) {
                    filteredSelection.push(x);
                }
            });

            filteredSelection.sort();

            setSelectedOptions(filteredSelection);
        }
    }, [selectedCarProperty, propertyList])


    function selectModel(e) {

        setSelectedModel(e.target.value);

    }



    return (
        <div id="adminedit-wrapper">
            <div id="adminedit-content">
                <h2>Editor</h2>
                <div className="editor-toolbar">
                    <button onClick={(e) => setTab(e, 'cartype')}>CarType</button>
                    <button onClick={(e) => setTab(e, 'color')}>Color</button>
                    <button onClick={(e) => setTab(e, 'equipment')}>Equipment</button>
                </div>
                {activeTab === 'cartype' && (
                    <>
                        <form className="adminedit-form" onSubmit={(e) => addCarProperty(e, "cartype", carTypeModel, setCarTypes)}>
                            <h3>Add CarType</h3>
                            <div className="adminedit-input-group">
                                <label>
                                    <span>Brand: </span>
                                    <input required name="brand" value={carTypeModel.brand} onChange={(e) => handleInputChange(e, setCarTypeModel)} />
                                </label>
                                <label>
                                    <span>Model: </span>
                                    <input required name="model" value={carTypeModel.model} onChange={(e) => handleInputChange(e, setCarTypeModel)} />
                                </label>
                            </div>
                            <button className="form-submit-btn">Add Cartype</button>
                        </form>

                        <div className="form-separator"></div>

                        <form className="adminedit-form" onSubmit={(e) => deleteCarProperty(e, "cartype", "model", setCarTypes)}>
                            <h3>Delete CarType</h3>
                            <div className="adminedit-input-group">
                                <label className="adminedit-label adminedit-items">
                                    <span>Brand</span>
                                    <select name="brand" placeholder="Brand" onChange={selectBrand}>
                                        <option>Select Brand</option>
                                        {getUniqueBrands().map(b => (<option key={b} value={b}>{b}</option>))}
                                    </select>
                                </label>
                                <label className="adminedit-label adminedit-items">
                                    <span>Model</span>
                                    {(selectedBrand != null && selectedBrand !== "Select Brand") && selectedCarTypeModels != null ? (
                                        <select name="model" placeholder="Model" onChange={selectModel}>
                                            <option>Select Model</option>
                                            {selectedCarTypeModels.map(m => (<option key={m.id} id={m.id} value={m.model}>{m.model}</option>))}
                                        </select>) : (
                                        <select id="select-disabled" name="model" placeholder="Model" disabled={true}>
                                            <option>Select Model</option>
                                        </select>
                                    )}
                                </label>
                            </div>
                            <button className="form-submit-btn">Delete Cartype</button>
                        </form>
                    </>
                )}
                {activeTab === 'color' && (
                    <div>

                        <form className="adminedit-form" onSubmit={(e) => addCarProperty(e, "color", colorModel, setColors)}>
                            <h3>Add Color</h3>
                            <div className="adminedit-input-group">
                                <label>
                                    <span>Color </span>
                                    <input required name="name" value={colorModel.name} onChange={(e) => handleInputChange(e, setColorModel)} />
                                </label>
                            </div>
                            <button className="form-submit-btn">Add Color</button>
                        </form>

                        <form className="adminedit-form" onSubmit={(e) => deleteCarProperty(e, "color", "color", setColors)}>
                            <h3>Delete Color</h3>
                            <div className="adminedit-input-group">
                                <label className="adminedit-label adminedit-items">
                                    <span>Color</span>
                                    <select name="color" placeholder="Color" onChange={(e) => selectCarProperty(e, "color")}>
                                        <option>Select Color</option>
                                        {colors.map(c => (<option key={c.id} id={c.id} value={c.name}>{c.name}</option>))}
                                    </select>
                                </label>
                            </div>
                            <button className="form-submit-btn">Delete Color</button>
                        </form>

                    </div>
                )}
                {activeTab === 'equipment' && (
                    <div>

                        <form className="adminedit-form" onSubmit={(e) => addCarProperty(e, "equipment", propModel, setPropertyList)}>
                            <h3>Add Equipment</h3>
                            <div className="adminedit-input-group">
                                <label>
                                    <span>Type: </span>
                                    <input required name="type" value={propModel.type} onChange={(e) => handleInputChange(e, setPropModel)} />
                                </label>
                                <label>
                                    <span>Name: </span>
                                    <input required name="name" value={propModel.name} onChange={(e) => handleInputChange(e, setPropModel)} />
                                </label>
                            </div>
                            <button className="form-submit-btn">Add Equipment</button>
                        </form>

                        <form className="adminedit-form" onSubmit={(e) => deleteCarProperty(e, "equipment", "name", setPropertyList)}>
                            <h3>Delete Equipment</h3>
                            <div className="adminedit-input-group">
                                <label className="adminedit-label adminedit-items">
                                    <span>Type</span>
                                    <select name="type" placeholder="Type" onChange={selectCarProperty}>
                                        <option>Select Type</option>
                                        {getUniqueSelectionTypes(propertyList, uniqueProperty).map(b => (<option key={b} value={b}>{b}</option>))}
                                    </select>
                                </label>
                                <label className="adminedit-label adminedit-items">
                                    <span>Name</span>
                                    {(selectedCarProperty != null && selectedCarProperty !== "Select Brand") && selectedOptions != null ? (
                                        <select name="name" placeholder="Equipment" onChange={selectCarProperty}>
                                            <option>Select Equipment</option>
                                            {selectedOptions.map(x => (<option key={x.id} id={x.id} value={x.name}>{x.name}</option>))}
                                        </select>) : (
                                        <select id="select-disabled" name="model" placeholder="Model" disabled={true}>
                                            <option>Select Equipment</option>
                                        </select>
                                    )}
                                </label>
                            </div>
                            <button className="form-submit-btn">Delete Equipment</button>
                        </form>

                    </div>
                )}
            </div>
        </div>
    );

}