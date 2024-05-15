function solve() {
    const textArea = document.getElementsByTagName("textarea")[0];
    const addButtons = document.getElementsByClassName("add-product");
    const checkoutButton = document.getElementsByClassName("checkout")[0];
    const products = [];
    let totalPrice = 0;

    for (const button of Array.from(addButtons)) {
        const product = button.parentNode.parentNode;

        const productName = product.querySelector(".product-title").textContent;
        const productPrice = product.querySelector(".product-line-price").textContent;

        console.log(productPrice);
        button.addEventListener("click", (e) => {
            if (!products.includes(productName)) {
                products.push(productName);
            }

            totalPrice += Number(productPrice);

            textArea.textContent += `Added ${productName} for ${Number(productPrice).toFixed(2)} to the cart.\n`;
        })
    }

    checkoutButton.addEventListener("click", (e) => {
        textArea.textContent += `You bought ${products.join(", ")} for ${totalPrice.toFixed(2)}.`;
        checkoutButton.disabled = true;

        for (const addBtn of addButtons) {
            addBtn.disabled = true;
        }
    })
}