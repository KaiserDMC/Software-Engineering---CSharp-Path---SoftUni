async function loadRepos() {
    document.getElementById("repos").innerHTML = "";

    const username = document.getElementById("username").value;
    const reposList = document.getElementById("repos");

    await fetch(`https://api.github.com/users/${username}/repos`)
        .then(response => {
            if (!response.ok) {
                if (response.status === 404) {
                    reposList.innerHTML = `<li>No repositories found for user ${username}</li>`;
                } else {
                    reposList.innerHTML = `<li>${response.status} - ${response.statusText}</li>`;
                }
            }
            return response.json()
        })
        .then(repos => {
            repos.forEach(repo => {
                const li = document.createElement("li");
                const a = document.createElement("a");
                a.href = repo.html_url;
                a.textContent = repo.full_name;
                li.appendChild(a);
                reposList.appendChild(li);
            });

        });
}