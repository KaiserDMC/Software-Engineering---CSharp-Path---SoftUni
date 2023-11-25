function sumTable() {
    const singleCost = Array.from(document.querySelectorAll("tr td:nth-child(2)"));
    let totalSum = 0;

    singleCost.forEach((single) => {
        if (single.id !== "sum") {
            totalSum += Number(single.textContent);
        }
    });

    document.getElementById("sum").textContent = totalSum;
}