import { useContext, useState, useEffect } from "react";
import { AuthContext } from "../Layout/Layout";
import "./AdminEditor.css";


export default function AdminEditor() {

    //ALL

    const { user } = useContext(AuthContext);

    //CURRENT ACTIVE TABS NAME
    const [activeTab, setActiveTab] = useState('cartype');

    //THE CURRENTLY SELECTED OPTION IN THE SELECT INPUT
    const [selectedCarProperty, setSelectedCarProperty] = useState(null);

    //THE CURRENT PROPERTYMODEL
    const [propModel, setPropModel] = useState(
        activeTab === 'cartype' ? { brand: "", model: "" } :
            activeTab === 'color' ? { name: "" } :
                activeTab === 'equipment' ? { type: "", name: "" } :
                    {}
    );
    //THE CURRENT GETALL LIST OF THE CHOSEN TAB
    const [propertyList, setPropertyList] = useState([]);
    //IF THERE IS A PROPERTY WITH MULTIPLE ITERATIONS FOR SUBTYPES
    const [uniqueProperty, setUniqueProperty] = useState(null);
    //SELECTED OPTIONS ACCORDING TO THE UNIQUE PROPERTY
    const [selectedOptions, setSelectedOptions] = useState(null);


    //CHANGING TEXT INPUTS
    const handleInputChange = (e, setData) => {

        const { name, value } = e.target;

        setData((prevData) => ({
            ...prevData, [name]: value
        }));

    }

    //FETCH ALL DATA FOR CURRENT TAB
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
            fetchCarProperties('cartype', setPropertyList);
            setUniqueProperty("brand");
        }

        if (activeTab === 'color') {
            fetchCarProperties('color', setPropertyList);
            setUniqueProperty(null);
        }

        if (activeTab === 'equipment') {
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

            const newPropModel = activeTab === 'cartype' ? { brand: "", model: "" } :
                activeTab === 'color' ? { name: "" } :
                    activeTab === 'equipment' ? { type: "", name: "" } :
                        {};

            setPropModel(newPropModel);

        } catch (err) {

            console.error(err);

        }
    }

    //SELECT INPUT FOR ALL
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


    //SET ACTIVE TAB AND RESETING THE MODEL AND SELECTED INPUT
    function setTab(e, tabName) {

        e.preventDefault();

        setActiveTab(tabName);

        const newPropModel = tabName === 'cartype' ? { brand: "", model: "" } :
            tabName === 'color' ? { name: "" } :
                tabName === 'equipment' ? { type: "", name: "" } :
                    {};

        setPropModel(newPropModel);

        setSelectedCarProperty("");
    }

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

    }, [propertyList, selectedOptions])

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
                        <form className="adminedit-form" onSubmit={(e) => addCarProperty(e, "cartype", propModel, setPropertyList)}>
                            <h3>Add CarType</h3>
                            <div className="adminedit-input-group">
                                <label>
                                    <span>Brand: </span>
                                    <input required name="brand" value={propModel.brand} onChange={(e) => handleInputChange(e, setPropModel)} />
                                </label>
                                <label>
                                    <span>Model: </span>
                                    <input required name="model" value={propModel.model} onChange={(e) => handleInputChange(e, setPropModel)} />
                                </label>
                            </div>
                            <button className="form-submit-btn">Add Cartype</button>
                        </form>

                        <div className="form-separator"></div>

                        <form className="adminedit-form" onSubmit={(e) => deleteCarProperty(e, "cartype", "model", setPropertyList)}>
                            <h3>Delete CarType</h3>
                            <div className="adminedit-input-group">
                                <label className="adminedit-label adminedit-items">
                                    <span>Brand</span>
                                    <select name="brand" placeholder="Brand" onChange={(e) =>selectCarProperty(e)}>
                                        <option>Select Brand</option>
                                        {getUniqueSelectionTypes(propertyList, uniqueProperty).map(b => (<option key={b} value={b}>{b}</option>))}
                                    </select>
                                </label>
                                <label className="adminedit-label adminedit-items">
                                    <span>Model</span>
                                    {(selectedCarProperty != null && selectedCarProperty !== "Select Brand") && selectedOptions != null ? (
                                        <select name="model" placeholder="Model" onChange={(e) =>selectCarProperty(e)}>
                                            <option>Select Model</option>
                                            {selectedOptions.map(m => (<option key={m.id} id={m.id} value={m.model}>{m.model}</option>))}
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

                        <form className="adminedit-form" onSubmit={(e) => addCarProperty(e, "color", propModel, setPropertyList)}>
                            <h3>Add Color</h3>
                            <div className="adminedit-input-group">
                                <label>
                                    <span>Color </span>
                                    <input required name="name" value={propModel.name} onChange={(e) => handleInputChange(e, setPropModel)} />
                                </label>
                            </div>
                            <button className="form-submit-btn">Add Color</button>
                        </form>

                        <form className="adminedit-form" onSubmit={(e) => deleteCarProperty(e, "color", "name", setPropertyList)}>
                            <h3>Delete Color</h3>
                            <div className="adminedit-input-group">
                                <label className="adminedit-label adminedit-items">
                                    <span>Color</span>
                                    <select name="name" placeholder="Color" onChange={(e) => selectCarProperty(e)}>
                                        <option>Select Color</option>
                                        {propertyList.map(c => (<option key={c.id} id={c.id} value={c.name}>{c.name}</option>))}
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
                                        <select id="select-disabled" name="name" placeholder="Equipment" disabled={true}>
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