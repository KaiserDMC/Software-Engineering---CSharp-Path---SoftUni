function validate() {
    const input = document.getElementById('email');

    input.addEventListener('change', onChange);

    function onChange(event) {
        const email = event.target.value;
        const pattern = /^[a-z]+@[a-z]+\.[a-z]+$/;
        
        if (pattern.test(email)) {
            event.target.classList.remove('error');
        } else {
            event.target.classList.add('error');
        }
    }
}