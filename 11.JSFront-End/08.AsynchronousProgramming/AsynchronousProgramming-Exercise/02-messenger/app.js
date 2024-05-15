function attachEvents() {
    const sendBtn = document.getElementById("submit");
    const refreshBtn = document.getElementById("refresh");
    const msgAuthor = document.querySelector("#controls input[name=author]");
    const msgContent = document.querySelector("#controls input[name=content]");
    const textArea = document.getElementById("messages");

    const baseUrl = "http://localhost:3030/jsonstore/messenger";

    sendBtn.addEventListener("click", async (e) => {
        const message = {
            author: msgAuthor.value,
            content: msgContent.value
        }

        await fetch(`${baseUrl}`, {
            method: "POST",
            body: JSON.stringify(message)
        });

        msgAuthor.value = "";
        msgContent.value = "";
    });

    refreshBtn.addEventListener("click", async (e) => {
        const getMsg = await fetch(`${baseUrl}`);
        const response = await getMsg.json();
       
        textArea.textContent = Object.values(response).map(m => `${m.author}: ${m.content}`).join("\n");
    });
}

attachEvents();