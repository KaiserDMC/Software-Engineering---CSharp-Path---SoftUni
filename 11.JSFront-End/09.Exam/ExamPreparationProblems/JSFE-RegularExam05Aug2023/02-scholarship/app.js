window.addEventListener("load", solve);

function solve() {
    let studentInput = document.getElementById("student");
    let universityInput = document.getElementById("university");
    let scoreInput = document.getElementById("score");
    const nextBtn = document.getElementById("next-btn");
    const previewList = document.getElementById("preview-list");
    let formElement = document.querySelector("form");

    nextBtn.addEventListener("click", inputStudentData);

    function inputStudentData() {
        if (
            studentInput.value == "" ||
            universityInput.value == "" ||
            scoreInput.value == ""
        ) {
            return;
        }

        let taskLiElement = document.createElement("li");
        taskLiElement.classList.add("application");

        let taskArticleElement = document.createElement("article");

        let titleHeadingElement = document.createElement("h4");
        titleHeadingElement.textContent = studentInput.value;
        let taskTitle = studentInput.value;
        let categoryPElement = document.createElement("p");
        categoryPElement.textContent = `University: ${universityInput.value}`;
        let taskCategory = universityInput.value;

        let contentPElement = document.createElement("p");
        contentPElement.textContent = `Score: ${scoreInput.value}`;
        let taskContent = scoreInput.value;

        taskArticleElement.appendChild(titleHeadingElement);
        taskArticleElement.appendChild(categoryPElement);
        taskArticleElement.appendChild(contentPElement);

        let editBtn = document.createElement("button");
        editBtn.classList.add("action-btn");
        editBtn.classList.add("edit");
        editBtn.textContent = "edit";
        editBtn.addEventListener("click", editStudentData);

        let postBtn = document.createElement("button");
        postBtn.classList.add("action-btn");
        postBtn.classList.add("apply");
        postBtn.textContent = "apply";
        postBtn.addEventListener("click", applyForScholarship);

        taskLiElement.appendChild(taskArticleElement);
        taskLiElement.appendChild(editBtn);
        taskLiElement.appendChild(postBtn);

        previewList.appendChild(taskLiElement);
        formElement.reset();
        nextBtn.disabled = true;

        function editStudentData() {
            nextBtn.disabled = false;

            studentInput.value = taskTitle;
            universityInput.value = taskCategory;
            scoreInput.value = taskContent;

            previewList.removeChild(taskLiElement);
        }

        function applyForScholarship() {
            const articlePreview = this.parentElement.querySelector("article");
            const universityName = articlePreview.querySelector("p:nth-child(2)");
            const studentScore = articlePreview.querySelector("p:nth-child(3)");

            const [e, a] = this.parentElement.querySelectorAll("button");
            e.remove();
            a.remove();
            articlePreview.parentElement.remove();

            const list = document.createElement("li");
            list.classList.add("application");
            const art = document.createElement("article");
            const h4 = document.createElement("h4");
            h4.textContent = taskTitle;
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
        }
    }
}