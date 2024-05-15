function deleteByEmail() {
    let inputField = document.querySelector('input[name="email"]');
    let inputText = inputField.value;

    let tableRows = Array.from(document.querySelectorAll('tbody tr'));

    for (let row of tableRows) {
        let email = row.children[1].textContent;

        if (email === inputText) {
            row.remove();
            document.getElementById('result').textContent = 'Deleted.';
            return;
        } else {
            document.getElementById('result').textContent = 'Not found.';
        }
    }
}