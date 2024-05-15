function lockedProfile() {
    const buttons = document.querySelectorAll('button');
    
    for (const button of buttons) {
        button.addEventListener("click", showMore);
    }
        
    function showMore(e) {
        const profile = e.target.parentNode;
        const isLocked = profile.querySelector('input[type="radio"][value="lock"]').checked;
        const hiddenFields = profile.querySelector('div');
        
        if (!isLocked) {
            if (e.target.textContent === 'Show more') {
                hiddenFields.style.display = 'block';
                e.target.textContent = 'Hide it';
            } else {
                hiddenFields.style.display = 'none';
                e.target.textContent = 'Show more';
            }
        }
    }
}