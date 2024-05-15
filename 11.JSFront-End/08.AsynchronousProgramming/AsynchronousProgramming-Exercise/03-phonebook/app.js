function attachEvents() {
    const baseUrl = "http://localhost:3030/jsonstore/phonebook";
    const loadBtn = document.getElementById("btnLoad");
    const phonebookList = document.getElementById("phonebook");
    const createBtn = document.getElementById("btnCreate");

    loadBtn.addEventListener("click", async (e) => {
        phonebookList.innerHTML = "";
        
        const promise = await fetch(`${baseUrl}`);
        const response = await promise.json();

        Object.values(response).forEach(phone => {
            const rowElement = document.createElement("li");
            rowElement.textContent = `${phone.person}: ${phone.phone}`;

            const deleteBtn = document.createElement("button");
            deleteBtn.textContent = "Delete";
            deleteBtn.value = phone._id;
            rowElement.appendChild(deleteBtn);

            deleteBtn.addEventListener("click", (e) => deletePhone(e));
            
            phonebookList.appendChild(rowElement);
        });
    });

   async function deletePhone(e) {
        const id = e.target.value;
        await fetch(`${baseUrl}/${id}`, {
            method: "DELETE"
        });
        
        loadBtn.click();
    }
    
    createBtn.addEventListener("click", async (e) => {
        const person = document.getElementById("person").value;
        const phone = document.getElementById("phone").value;

        const promise = await fetch(`${baseUrl}`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ person, phone })
        });

        const response = await promise.json();

        document.getElementById("person").value = "";
        document.getElementById("phone").value = "";

        loadBtn.click();
    });
}

attachEvents();