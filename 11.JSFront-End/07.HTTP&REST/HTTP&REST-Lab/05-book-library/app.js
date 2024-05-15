function attachEvents() {
    const loadBooksBtn = document.getElementById("loadBooks");
    const tableBody = document.querySelector("tbody");
    const submitBtn = document.querySelector("#form button");

    tableBody.innerHTML = "";
    let currentBookId = null;

    // Submit new book function
    const submitNewBook = async (e) => {
        e.preventDefault();

        const titleInput = document.querySelector(`input[name="title"]`);
        const authorInput = document.querySelector(`input[name="author"]`);

        const book = {
            title: titleInput.value,
            author: authorInput.value
        };

        if (currentBookId) {
            // If there's a currentBookId, it means we're editing
            await fetch(`http://localhost:3030/jsonstore/collections/books/${currentBookId}`, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(book)
            });

            currentBookId = null; // Reset currentBookId after editing
        } else {
            // If there's no currentBookId, it means we're adding a new book
            await fetch("http://localhost:3030/jsonstore/collections/books", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(book)
            });
        }

        titleInput.value = "";
        authorInput.value = "";

        await loadBooksBtn.click(); // Load books after submit
    };

    // Load books function
    const loadBooks = async (e) => {
        e.preventDefault();

        tableBody.innerHTML = "";

        await fetch("http://localhost:3030/jsonstore/collections/books")
            .then((response) => response.json())
            .then((data) => {
                Object.entries(data).forEach((book) => {
                    const tr = document.createElement("tr");
                    const tdTitle = document.createElement("td");
                    const tdAuthor = document.createElement("td");
                    const tdButtons = document.createElement("td");
                    const editBtn = document.createElement("button");
                    const deleteBtn = document.createElement("button");

                    tdTitle.textContent = book[1].title;
                    tdAuthor.textContent = book[1].author;
                    editBtn.textContent = "Edit";
                    deleteBtn.textContent = "Delete";

                    tdButtons.appendChild(editBtn);
                    tdButtons.appendChild(deleteBtn);

                    tr.appendChild(tdTitle);
                    tr.appendChild(tdAuthor);
                    tr.appendChild(tdButtons);

                    tableBody.appendChild(tr);

                    // Edit book
                    editBtn.addEventListener("click", async (e) => {
                        e.preventDefault();

                        const titleInput = document.querySelector(`input[name="title"]`);
                        const authorInput = document.querySelector(`input[name="author"]`);
                        const formTitle = document.querySelector("#form h3");
                        const submitBtn = document.querySelector("#form button");

                        const bookId = book[0];
                        titleInput.value = book[1].title;
                        authorInput.value = book[1].author;
                        formTitle.textContent = "Edit FORM";
                        submitBtn.textContent = "Save";

                        submitBtn.removeEventListener("click", submitNewBook);

                        submitBtn.addEventListener("click", async () => {
                            // Update book on Save
                            const updatedBook = {
                                title: titleInput.value,
                                author: authorInput.value
                            };

                            await fetch(`http://localhost:3030/jsonstore/collections/books/${bookId}`, {
                                method: "PUT",
                                headers: {
                                    "Content-Type": "application/json"
                                },
                                body: JSON.stringify(updatedBook)
                            });

                            formTitle.textContent = "FORM";
                            submitBtn.textContent = "Submit";
                            titleInput.value = "";
                            authorInput.value = "";
                        });
                    });

                    // Delete book
                    deleteBtn.addEventListener("click", async (e) => {
                        e.preventDefault();

                        const bookId = book[0];

                        await fetch(`http://localhost:3030/jsonstore/collections/books/${bookId}`, {
                            method: "DELETE"
                        });

                        await loadBooksBtn.click(); // Load books after delete
                    });
                })
            });
    }

    // Load all books
    loadBooksBtn.addEventListener("click", loadBooks);

    // Submit new book
    submitBtn.addEventListener("click", submitNewBook);
}

attachEvents();