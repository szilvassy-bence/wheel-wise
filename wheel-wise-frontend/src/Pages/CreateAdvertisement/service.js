
export function yearCounter() {
    let years = [];
    for (let i = new Date().getFullYear(); i >= 1900; i--) {
        years.push(i);
    }
    return years;
}