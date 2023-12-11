//window.addEventListener("load", solve);

function solve() {
    const studentInput = document.getElementById("student");
    const universityInput = document.getElementById("university");
    const scoreInput = document.getElementById("score");
    const nextBtn = document.getElementById("next-btn");
    const previewList = document.getElementById("preview-list");

    nextBtn.addEventListener("click", () => {
        if (studentInput.value !== "" || universityInput.value !== "" || scoreInput.value !== "") {
            nextBtn.disabled = true;
            inputStudentData();
        }
    });

    function inputStudentData() {
        const listItem = document.createElement("li");
        listItem.classList.add("application");
        const article = document.createElement("article");
        article.style.display = "flex";
        const h4 = document.createElement("h4");
        h4.textContent = studentInput.value;
        const p = document.createElement("p");
        p.textContent = `University: ${universityInput.value}`;
        const pp = document.createElement("p");
        pp.textContent = `Score: ${scoreInput.value}`;

        const editBtn = document.createElement("button");
        editBtn.classList.add("action-btn", "edit");
        editBtn.textContent = "Edit";
        const applyBtn = document.createElement("button");
        applyBtn.classList.add("action-btn", "apply");
        applyBtn.textContent = "Apply";

        article.appendChild(h4);
        article.appendChild(p);
        article.appendChild(pp);

        listItem.appendChild(article);
        listItem.appendChild(editBtn);
        listItem.appendChild(applyBtn);

        studentInput.value = "";
        universityInput.value = "";
        scoreInput.value = "";

        previewList.appendChild(listItem);

        editBtn.addEventListener("click", editStudentData);
        applyBtn.addEventListener("click", applyForScholarship);
    }

    function editStudentData() {
        const article = this.parentElement.querySelector("article");

        const h4 = article.querySelector("h4");
        const p1 = article.querySelector("p:nth-child(2)");
        const p2 = article.querySelector("p:nth-child(3)");

        studentInput.value = h4.textContent;
        universityInput.value = p1.textContent.substring(12);
        scoreInput.value = p2.textContent.substring(7);

        nextBtn.disabled = false;
        article.parentElement.remove();
    }

    function applyForScholarship() {
        const articlePreview = this.parentElement.querySelector("article");

        const studentName = articlePreview.querySelector("h4");
        const universityName = articlePreview.querySelector("p:nth-child(2)");
        const studentScore = articlePreview.querySelector("p:nth-child(3)");

        const list = document.createElement("li");
        list.classList.add("application");
        const art = document.createElement("article");
        art.style.display = "flex";
        const h4 = document.createElement("h4");
        h4.textContent = studentName.textContent;
        const p = document.createElement("p");
        p.textContent = `${universityName.textContent}`;
        const pp = document.createElement("p");
        pp.textContent = `${studentScore.textContent}`;

        art.appendChild(h4);
        art.appendChild(p);
        art.appendChild(pp);

        list.appendChild(art);
        document.getElementById("candidates-list").appendChild(list);

        nextBtn.disabled = false;

        articlePreview.parentElement.remove();
    }
}