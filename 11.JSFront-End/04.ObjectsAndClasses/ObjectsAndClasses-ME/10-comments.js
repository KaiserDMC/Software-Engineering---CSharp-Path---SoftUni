function comments(inputArr) {
    let websiteArticles = {};
    let userList = [];

    for (const inputArrElement of inputArr) {
        if (inputArrElement.includes("user ")) {
            let userName = inputArrElement.split(" ")[1];
           
            if (!userList.includes(userName)) {
                userList.push(userName);
            }

        } else if (inputArrElement.includes("article ")) {
            let articleName = inputArrElement.slice("article ".length);

            websiteArticles[articleName] = [];
        } else {
            let userName = inputArrElement.split(" posts on ")[0];
            let [articleName, commentData] = inputArrElement.split(" posts on ")[1].split(": ");
            let [commentTitle, commentContent] = commentData.split(", ");

            let comment = {
                user: userName,
                title: commentTitle,
                content: commentContent
            };
            
            if (websiteArticles.hasOwnProperty(articleName) && userList.includes(userName)) {
                websiteArticles[articleName].push(comment);
            }
        }
    }

    let sortedArticleEntries = Object.entries(websiteArticles).sort((a, b) => b[1].length - a[1].length);
    
    for (const [articleName, comments] of sortedArticleEntries) {
        console.log(`Comments on ${articleName}`);

        let sortedComments = comments.sort((a, b) => a.user.localeCompare(b.user));

        for (const comment of sortedComments) {
            console.log(`--- From user ${comment.user}: ${comment.title} - ${comment.content}`);
        }
    }
}

comments(['user aUser123', 'someUser posts on someArticle: NoTitle, stupidComment', 'article Books', 'article Movies', 'article Shopping', 'user someUser', 'user uSeR4', 'user lastUser', 'uSeR4 posts on Books: I like books, I do really like them', 'uSeR4 posts on Movies: I also like movies, I really do', 'someUser posts on Shopping: title, I go shopping every day', 'someUser posts on Movies: Like, I also like movies very much']);
comments(['user Mark', 'Mark posts on someArticle: NoTitle, stupidComment', 'article Bobby', 'article Steven', 'user Liam', 'user Henry', 'Mark posts on Bobby: Is, I do really like them', 'Mark posts on Steven: title, Run', 'someUser posts on Movies: Like']);