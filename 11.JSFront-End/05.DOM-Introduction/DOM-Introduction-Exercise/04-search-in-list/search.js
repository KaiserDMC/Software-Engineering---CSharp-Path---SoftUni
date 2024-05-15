function search() {
    const listOfTowns = document.querySelectorAll("ul li");
    const searchTerm = document.getElementById("searchText").value;
    let counter = 0;

    for (const townElement of listOfTowns) {
        townElement.style.textDecoration = "none";
        townElement.style.fontWeight = "normal";

        let town = townElement.textContent;

        if (town.includes(searchTerm)) {
            townElement.style.fontWeight = "bolder";
            townElement.style.textDecoration = "underline";
            counter++;
        }
    }

    document.getElementById("result").textContent = `${counter} matches found`;
}