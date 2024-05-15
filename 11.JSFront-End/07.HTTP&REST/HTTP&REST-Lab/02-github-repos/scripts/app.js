function loadRepos() {
    fetch("https://api.github.com/users/testnakov/repos")
        .then(response => response.text())
        .then(responseBody => {
            document.getElementById("res").textContent = responseBody;
        });
}