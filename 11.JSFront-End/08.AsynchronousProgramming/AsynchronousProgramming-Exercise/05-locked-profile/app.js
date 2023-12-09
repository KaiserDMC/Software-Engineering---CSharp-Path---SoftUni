async function lockedProfile() {
    const baseUrl = "http://localhost:3030/jsonstore/advanced/profiles";
    const mainSection = document.getElementById("main");
    
    const response = await fetch(baseUrl);
    const result = await response.json();
    mainSection.innerHTML = "";
    
    let counter = 1;
    for (const profile of Object.values(result)){
        const id = profile._id;
        const username = profile.username;
        const email = profile.email;
        const age = profile.age;
        
        const container = document.createElement("div");
        container.classList.add("profile");
        container.id = id;

        container.innerHTML = `

                    <img src="./iconProfile2.png" class="userIcon" />
                    <label>Lock</label>
                    <input type="radio" name="user${counter}Locked" value="lock" checked>
                    <label>Unlock</label>
                    <input type="radio" name="user${counter}Locked" value="unlock"><br>
                    <hr>
                    <label>Username</label>
                    <input type="text" name="user${counter}Username" value="${username}" disabled readonly />
                    <div id="user${counter}HiddenFields">
                        <hr>
                        <label>Email:</label>
                        <input type="email" name="user${counter}Email" value="${email}" disabled readonly />
                        <label>Age:</label>
                        <input type="email" name="user${counter}Age" value="${age}" disabled readonly />
                    </div>

                    <button>Show more</button>        
                    `
        mainSection.appendChild(container);
        
        counter++;
        const userDetails = container.getElementsByTagName("div")[0];
        const unlockedButton = container.getElementsByTagName("input")[1];
        const lockedButton = container.getElementsByTagName("input")[0];
        const showMoreButton = container.getElementsByTagName("button")[0];
        lockedButton.checked = true;
        userDetails.style.display = "none";

        showMoreButton.addEventListener("click", () => {            
            if (unlockedButton.checked){                
                if (showMoreButton.textContent === "Show more"){
                    userDetails.style.display = "block";
                    showMoreButton.textContent = "Hide it";
                } else {
                    userDetails.style.display = "none";
                    showMoreButton.textContent = "Show more";
                }
            }
        });
    }
}