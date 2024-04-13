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
    if (e.target.value == "Select Brand") {
        setFormData({...formData, brand: e.target.value, model: "Select Model"})
    } else {
        setFormData({...formData, brand: e.target.value})
    }
}

export {yearCounter, getUniqueBrands, selectBrand};