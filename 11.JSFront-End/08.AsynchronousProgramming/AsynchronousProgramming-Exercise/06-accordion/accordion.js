async function solution() {
    const baseUrl = "http://localhost:3030/jsonstore/advanced/articles/list";
    const baseUrlDetails = "http://localhost:3030/jsonstore/advanced/articles/details";
    const response = await fetch(baseUrl);
    const result = await response.json();

    for (const resultElement of Object.values(result)) {
        const accordionDiv = document.createElement("div");
        accordionDiv.classList.add("accordion");
        
        const headDiv = document.createElement("div");
        headDiv.classList.add("head");
        const spanHead = document.createElement("span");
        spanHead.innerText = resultElement.title;
        const btnHead = document.createElement("button");
        btnHead.id = resultElement._id;
        btnHead.classList.add("button");
        btnHead.textContent = "More";

        headDiv.appendChild(spanHead);
        headDiv.appendChild(btnHead);
        accordionDiv.appendChild(headDiv);

        const extraDiv = document.createElement("div");
        extraDiv.classList.add("extra");
        const para = document.createElement("p");
        extraDiv.appendChild(para);
        extraDiv.style.display = "none";

        accordionDiv.appendChild(extraDiv);

        btnHead.addEventListener("click", async (e) => {
            const currentAccordion = e.currentTarget.closest(".accordion");
            const currentExtraDiv = currentAccordion.querySelector(".extra");
            const currentButton = currentAccordion.querySelector("button");

            currentExtraDiv.style.display = currentExtraDiv.style.display === "none" ? "block" : "none";

            if (currentExtraDiv.style.display === "block") {
                const response = await fetch(`${baseUrlDetails}/${e.currentTarget.id}`);
                const result = await response.json();

                const paragraph = currentAccordion.querySelector(".extra p");
                paragraph.textContent = result.content;

                currentButton.textContent = "Less";
            } else {
                currentButton.textContent = "More";
            }
        });
        
        document.getElementById("main").appendChild(accordionDiv);
    }
}

solution();