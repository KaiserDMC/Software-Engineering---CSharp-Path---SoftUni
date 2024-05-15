function focused() {
    let inputs = document.getElementsByTagName('input');
    
    Array.from(inputs).forEach(input => {
        input.addEventListener('focus', (e) => {
            e.target.parentNode.className = 'focused';
        });
        input.addEventListener('blur', (e) => {
            e.target.parentNode.className = '';
        });
    });
}