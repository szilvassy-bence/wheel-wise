import {useEffect, useState} from "react";
import Form from 'react-bootstrap/Form';
import Button from "react-bootstrap/Button";

export default function AdFilter() {
    const [carTypes, setCarTypes] = useState(null);
    const [selectedBrand, setSelectedBrand] = useState(null);
    const [carTypeModels, setCarTypeModels] = useState(null);

    const [formData, setFormData] = useState({
        brand: "",
        model: "",
        minPrice: 0,
        maxPrice: 0,
        fromYear: "",
        tillYear: ""
    })

    const fetchCarTypeData = async () => {
        try {
            const response = await fetch('/api/CarType');
            const data = await response.json();
            setCarTypes(data);
            console.log(data);
        } catch (error) {
            console.error('Error fetching car type data', error);
        }
    }
    useEffect(() => {
        fetchCarTypeData();
    }, []);

    function yearCounter() {
        let years = [];
        for (let i = new Date().getFullYear(); i >= 1900; i--) {
            years.push(i);
        }
        return years;
    }

    function getUniqueBrands() {
        let brands = [];
        carTypes.map(x => {
            if (!brands.includes(x.brand)) {
                brands.push(x.brand);
            }
        })
        return brands.sort();
    }

    function selectBrand(e) {
        console.log(e.target.value);
        setSelectedBrand(e.target.value);
        setFormData({...formData, brand: e.target.value})
    }

    function selectModel(e) {
        console.log(e.target.value);
        setFormData({...formData, model: e.target.value})
    }
    function setMinPrice(e) {
        console.log(e.target.value);
        setFormData({...formData, minPrice: e.target.value})
    }
    function setMaxPrice(e) {
        console.log(e.target.value);
        setFormData({...formData, maxPrice: e.target.value})
    }
    function setFromYear(e) {
        console.log(e.target.value);
        setFormData({...formData, fromYear: e.target.value})
    }
    function setTillYear(e) {
        console.log(e.target.value);
        setFormData({...formData, tillYear: e.target.value})
    }

    useEffect(() => {
        console.log(`selected brand: ${selectedBrand}`);
        if (selectedBrand != null) {
            let modelsFilteredByBrands = [];
            console.log(`selected brand: ${selectedBrand}`);
            carTypes.forEach(c => {
                if (c.brand == selectedBrand) {
                    modelsFilteredByBrands.push(c.model);
                }
            });
            modelsFilteredByBrands.sort();
            setCarTypeModels(modelsFilteredByBrands);
        }
    }, [selectedBrand])

    async function submitForm(e) {
        e.preventDefault();
        console.log(e.target);

        console.log(formData);

        //send fetch request to post new book
        /*const response = await fetch('/api/new-todo', {
            method: 'POST',
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify(newTodo)
        }*/
    }

    //Maximum year shouldnt be smaller than minimum
    return (
        <div>
            {carTypes ? (<Form onSubmit={e =>submitForm(e)} id="filterForm">
                <Form.Select aria-label="brand" value={formData.brand} onChange={e => selectBrand(e)}>
                    <option>Select Brand</option>
                    {getUniqueBrands().map(b => (
                        <option key={b} value={b}>{b}</option>
                    ))
                    }
                </Form.Select>
                {selectedBrand != null && carTypeModels != null ? (
                        <Form.Select aria-label="model" value={formData.model} onChange={e => selectModel(e)}>
                            <option>Select Model</option>
                            {carTypeModels.map(m => (
                                <option key={m} value={m}>{m}</option>
                            ))
                            }
                        </Form.Select>)
                    :
                    (
                        <Form.Select aria-label="model" disabled={true}>
                            <option>Select Model</option>
                        </Form.Select>)
                }
                <Form.Label htmlFor="minimumPriceInput">Minimum Price</Form.Label>
                <Form.Control
                    type="number"
                    id="minimumPriceInput"
                    aria-describedby="mincarprice"
                    value={formData.minPrice}
                    onChange={e => setMinPrice(e)}
                />
                <Form.Label htmlFor="maximumPriceInput">Maximum Price</Form.Label>
                <Form.Control
                    type="number"
                    id="maximumPriceInput"
                    aria-describedby="maxcarprice"
                    value={formData.maxPrice}
                    onChange={e => setMaxPrice(e)}
                />
                <Form.Select aria-label="fromyear" value={formData.fromYear} onChange={e => setFromYear(e)}>
                    <option>From</option>
                    {yearCounter().map(year => (
                        <option key={year} value={year}>{year}</option>))
                    }
                </Form.Select>
                <Form.Select aria-label="tillyear" value={formData.tillYear} onChange={e => setTillYear(e)}>
                    <option>Till</option>
                    {yearCounter().map(year => (
                        <option key={year} value={year}>{year}</option>))
                    }
                </Form.Select>
                <Button variant="primary" type="submit">
                    Submit
                </Button>
            </Form>) : (<p>Loading...</p>)}
        </div>
    )
}