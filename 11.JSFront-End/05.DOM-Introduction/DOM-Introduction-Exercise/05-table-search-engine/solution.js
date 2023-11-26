function solve() {
    document.querySelector('#searchBtn').addEventListener('click', onClick);

    function onClick() {
        const tableElements = document.querySelectorAll("table tbody tr");
        const searchQuery = document.getElementById("searchField").value;
        document.getElementById("searchField").value = "";

        for (const tableElement of tableElements) {
            tableElement.classList.remove("select");

            let currentCol = Array.from(tableElement.children);

            for (const element of currentCol) {
                if (element.textContent.includes(searchQuery)) {
                    tableElement.classList.add("select");
                    break;
                }
            }

        }
    }
}