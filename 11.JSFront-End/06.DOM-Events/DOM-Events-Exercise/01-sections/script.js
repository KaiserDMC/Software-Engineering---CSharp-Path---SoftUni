function create(words) {
    const content = document.getElementById("content");

    for (const w of words) {
        let currentDiv = document.createElement("div");
        let paragraph = document.createElement("p");

        paragraph.textContent = w;
        paragraph.style.display = "none";

        currentDiv.appendChild(paragraph);
        currentDiv.addEventListener("click", (e) => {
            paragraph.style.display = "";
        });
        
        content.appendChild(currentDiv);
    }
}