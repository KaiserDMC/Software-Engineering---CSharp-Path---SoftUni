function addItem() {
    let inputField = document.getElementById('newItemText');
    const itemsList = document.getElementById('items');
    
    const li = document.createElement('li');
    li.textContent = inputField.value;
    
    const a = document.createElement('a');
    a.textContent = '[Delete]';
    a.href = '#';
    a.addEventListener('click', deleteItem);
    
    li.appendChild(a);
    itemsList.appendChild(li);
    inputField.value = '';
    
    function deleteItem() {
        li.remove();
    }
}