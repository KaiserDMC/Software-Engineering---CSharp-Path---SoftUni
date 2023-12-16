window.addEventListener("load", solve);

function solve() {
    const [expense, amount, date] = document.querySelectorAll("input");
    const [addBtn, deleteBtn] = document.querySelectorAll("button");
    const [previewList, expenseList] = document.querySelectorAll("ul");
    const form = document.querySelector("form");

    addBtn.addEventListener("click", addExpense);
    deleteBtn.addEventListener("click", deleteExpense);

    function deleteExpense() {
        form.reset();
        location.reload();
    }

    function addExpense() {

        if (expense.value && amount.value && date.value) {
            const li = document.createElement("li");
            li.classList.add("expense-item");
            const article = document.createElement("article");
            const p1 = document.createElement("p");
            const p2 = document.createElement("p");
            const p3 = document.createElement("p");

            p1.textContent = `Type: ${expense.value}`;
            let expenseType = expense.value;
            p2.textContent = `Amount: ${amount.value}$`;
            let expenseAmount = amount.value;
            p3.textContent = `Date: ${date.value}`;
            let expenseDate = date.value;

            article.appendChild(p1);
            article.appendChild(p2);
            article.appendChild(p3);
            li.appendChild(article);

            const divButtons = document.createElement("div");
            divButtons.classList.add("buttons");
            const editButton = document.createElement("button");
            editButton.textContent = "edit";
            editButton.classList.add("btn", "edit");
            const okButton = document.createElement("button");
            okButton.textContent = "ok";
            okButton.classList.add("btn", "ok");

            divButtons.appendChild(editButton);
            divButtons.appendChild(okButton);
            li.appendChild(divButtons);

            previewList.appendChild(li);

            addBtn.disabled = true;
            expense.value = "";
            amount.value = "";
            date.value = "";

            editButton.addEventListener("click", editExpense);
            okButton.addEventListener("click", approveExpense);

            function editExpense() {
                expense.value = expenseType;
                amount.value = expenseAmount;
                date.value = expenseDate;

                addBtn.disabled = false;
                li.remove();
            }

            function approveExpense() {
                const liApproved = document.createElement("li");
                liApproved.classList.add("expense-item");

                const articleApproved = document.createElement("article");
                const p1Approved = document.createElement("p");
                const p2Approved = document.createElement("p");
                const p3Approved = document.createElement("p");

                p1Approved.textContent = `Type: ${expenseType}`;
                p2Approved.textContent = `Amount: ${expenseAmount}$`;
                p3Approved.textContent = `Date: ${expenseDate}`;

                articleApproved.appendChild(p1Approved);
                articleApproved.appendChild(p2Approved);
                articleApproved.appendChild(p3Approved);
                liApproved.appendChild(articleApproved);

                expenseList.appendChild(liApproved);

                addBtn.disabled = false;

                li.remove();
            }
        }
    }
}