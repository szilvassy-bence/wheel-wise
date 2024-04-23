import "./CarTypeFormSelect.css";

export default function CarTypeFormSelect({
                                              formData,
                                              selectBrand,
                                              selectedBrand,
                                              getUniqueBrands,
                                              carTypeModels,
                                              selectModel
                                          }) {
    return (
        <>
            <label className="simple-filter-label simple-filter-items">
                <span>Brand</span>
                <select name="brand" placeholder="Brand" onChange={(e) => selectBrand(e)}>
                    <option>Select Brand</option>
                    {getUniqueBrands().map(b => (<option key={b} value={b}>{b}</option>))}
                </select>
            </label>
            <label className="simple-filter-label simple-filter-items">
                <span>Model</span>
                {(selectedBrand != null && selectedBrand != "Select Brand") && carTypeModels != null ? (
                <select name="model" placeholder="Model" onChange={(e) => selectModel(e)}>
                    <option>Select Model</option>
                    {carTypeModels.map(m => (<option key={m} value={m}>{m}</option>))}
                </select>) : (
                <select id="select-disabled" name="model" placeholder="Model" disabled={true}>
                    <option>Select Model</option>
                </select>
                )}
            </label>
        </>
    )
}