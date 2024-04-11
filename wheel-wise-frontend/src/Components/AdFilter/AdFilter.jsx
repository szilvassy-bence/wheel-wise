import {useEffect, useState} from "react";
import Form from 'react-bootstrap/Form';
import Button from "react-bootstrap/Button";

export default function AdFilter() {
    const [carTypes, setCarTypes] = useState(null);
    const [selectedBrand, setSelectedBrand] = useState(null);
    const [carTypeModels, setCarTypeModels] = useState(null);

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
        //console.log(e.target);

        //get the data from the form
        const form = document.getElementById('filterForm');
        const formData = new FormData(form);
        const filter = Object.fromEntries(formData);
        filter.
        //newTodo.createdAt = new Date(newTodo.createdAt);
        console.log(filter);

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
                <Form.Select aria-label="brand" onChange={e => selectBrand(e)}>
                    <option>Select Brand</option>
                    {getUniqueBrands().map(b => (
                        <option key={b} value={b}>{b}</option>
                    ))
                    }
                </Form.Select>
                {selectedBrand != null && carTypeModels != null ? (
                        <Form.Select aria-label="model">
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
                    type="text"
                    id="minPriceControl"
                    aria-describedby="mincarprice"
                />
                <Form.Text id="minimumPriceInput" value="" muted placeholder="Minimum Price">
                </Form.Text>
                <Form.Label htmlFor="maximumPriceInput">Maximum Price</Form.Label>
                <Form.Control
                    type="text"
                    id="maxPriceControl"
                    aria-describedby="maxcarprice"
                />
                <Form.Text id="maximumPriceInput" value="" muted placeholder="Maximum Price">
                </Form.Text>
                <Form.Select aria-label="fromyear">
                    <option>From</option>
                    {yearCounter().map(year => (
                        <option key={year} value={year}>{year}</option>))
                    }
                </Form.Select>
                <Form.Select aria-label="tillyear">
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