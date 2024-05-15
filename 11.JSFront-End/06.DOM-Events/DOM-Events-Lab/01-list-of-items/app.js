function addItem() {
    const inputField = document.getElementById('newItemText');
    const itemsList = document.getElementById('items');
    
    const li = document.createElement('li');
    li.textContent = inputField.value;
    itemsList.appendChild(li);
    inputField.value = '';
}