async function loadCommits() {
    const username = document.getElementById("username").value;
    const repository = document.getElementById("repo").value;
    const commits = document.getElementById("commits");
    
    commits.innerHTML = "";

    await fetch(`https://api.github.com/repos/${username}/${repository}/commits`)
        .then(response => {
            if (!response.ok) {
                commits.innerHTML = `<li>Error: ${response.status} (Not Found)</li>`;
            }
            return response.json();
        })
        .then(data => {
            data.forEach(commit => {
                const li = document.createElement("li");
                li.textContent = `${commit.commit.author.name}: ${commit.commit.message}`;
                commits.appendChild(li);
            });
        })
}