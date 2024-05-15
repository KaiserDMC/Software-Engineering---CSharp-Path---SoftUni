window.addEventListener("load", solve);

function solve() {
    const [playerName, playerScore, playerRound] = document.getElementsByTagName("input");
    const addButton = document.querySelector("#add-btn");
    const clearButton = document.querySelector(".clear");
    const form = document.querySelector("form");

    addButton.addEventListener("click", addInformation);

    function clearInformation() {
        location.reload();
        form.reset();
    }

    clearButton.addEventListener("click", clearInformation);

    function addInformation() {
        if (playerName.value == "" || playerScore.value == "" || playerRound.value == "") {
            return;
        }

        const ul = document.querySelector("#sure-list");
        const li = document.createElement("li");
        li.classList.add("dart-item");
        const article = document.createElement("article");
        const paragraph1 = document.createElement("p");
        paragraph1.textContent = playerName.value;
        let name = paragraph1.textContent;
        const paragraph2 = document.createElement("p");
        paragraph2.textContent = `Score: ${playerScore.value}`;
        let score = paragraph2.textContent;
        const paragraph3 = document.createElement("p");
        paragraph3.textContent = `Round: ${playerRound.value}`;
        let round = paragraph3.textContent;

        article.appendChild(paragraph1);
        article.appendChild(paragraph2);
        article.appendChild(paragraph3);

        const editButton = document.createElement("button");
        editButton.textContent = "edit";
        editButton.classList.add("btn", "edit");
        editButton.addEventListener("click", editInformation);

        const okButton = document.createElement("button");
        okButton.textContent = "ok";
        okButton.classList.add("btn", "ok");
        okButton.addEventListener("click", okInformation);

        li.appendChild(article);
        li.appendChild(editButton);
        li.appendChild(okButton);
        ul.appendChild(li);

        playerName.value = "";
        playerScore.value = "";
        playerRound.value = "";
        addButton.disabled = true;

        function editInformation() {
            playerName.value = name;
            playerScore.value = score.substring(7);
            playerRound.value = round.substring(7);
            addButton.disabled = false;

            ul.removeChild(li);
        }

        function okInformation() {
            ul.removeChild(li);

            const ulScoreboard = document.querySelector("#scoreboard-list");
            const liScoreboard = document.createElement("li");
            li.classList.add("dart-item");
            const article = document.createElement("article");
            const paragraph1 = document.createElement("p");
            paragraph1.textContent = name;
            const paragraph2 = document.createElement("p");
            paragraph2.textContent = `Score: ${score.substring(7)}`;
            const paragraph3 = document.createElement("p");
            paragraph3.textContent = `Round: ${round.substring(7)}`;

            article.appendChild(paragraph1);
            article.appendChild(paragraph2);
            article.appendChild(paragraph3);

            liScoreboard.appendChild(article);
            ulScoreboard.appendChild(liScoreboard);
            addButton.disabled = false;
        }
    }
}