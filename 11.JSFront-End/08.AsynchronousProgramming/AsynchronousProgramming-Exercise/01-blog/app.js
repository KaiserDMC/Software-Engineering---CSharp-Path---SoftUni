function attachEvents() {
    const baseUrlPosts = "http://localhost:3030/jsonstore/blog/posts";
    const baseUrlComments = "http://localhost:3030/jsonstore/blog/comments";
    const postsSelect = document.getElementById("posts");
    const btnLoadPosts = document.getElementById("btnLoadPosts");
    const btnViewPost = document.getElementById("btnViewPost");

    btnLoadPosts.addEventListener("click", () => {
        postsSelect.innerHTML = "";
        
        fetch(baseUrlPosts)
            .then(res => res.json())
            .then(data => {
                Object.values(data).forEach(post => {
                    const option = document.createElement("option");
                    option.value = post.id;
                    option.textContent = post.title;
                    
                    postsSelect.appendChild(option);
                });
            });
    });

    btnViewPost.addEventListener("click", () => {
        const postId = postsSelect.value;
        const postTitle = document.getElementById("post-title");
        const postBody = document.getElementById("post-body");
        const postComments = document.getElementById("post-comments");

        postBody.innerHTML = "";
        postComments.innerHTML = "";
        
        fetch(`${baseUrlPosts}/${postId}`)
            .then(res => res.json())
            .then(data => {
                postTitle.textContent = data.title;
                postBody.textContent = data.body;
            });

        fetch(`${baseUrlComments}`)
            .then(res => res.json())
            .then(data => {
                Object.values(data).filter(p => p.postId === postId).forEach(comment => {
                    const li = document.createElement("li");
                    li.id = comment.id;
                    li.textContent = comment.text;

                    postComments.appendChild(li);
                });
            });
    });
}

attachEvents();