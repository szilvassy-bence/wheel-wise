export function getMin(adsArray) {
    let minPrice = Infinity;
    for (let i = 0; i < adsArray.length; i++) {
        const currentPrice = adsArray[i].car.price;
        if (currentPrice < minPrice) minPrice = currentPrice;
    }
    console.log(minPrice);
    return minPrice;
}

export function getMax(adsArray) {
    let maxPrice = -Infinity;
    for (let i = 0; i < adsArray.length; i++) {
        const currentPrice = adsArray[i].car.price;
        if (currentPrice > maxPrice) maxPrice = currentPrice;
    }
    console.log(maxPrice);
    return maxPrice;
}