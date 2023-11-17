function bookShelf(inputArr) {
    let shelf = {};

    for (const inputElement of inputArr) {
        if (inputElement.includes(" -> ")) {
            let [shelfId, genre] = inputElement.split(" -> ");

            if (!shelf.hasOwnProperty(shelfId)) {
                shelf[shelfId] = {
                    genre,
                    books: []
                }
            }
        } else {
            let [bookName, authorAndGenre] = inputElement.split(':').map(item => item.trim());
            let [author, genre] = authorAndGenre.split(',').map(item => item.trim());

            let matchingShelf = Object.values(shelf).find(sh => sh.genre === genre);

            if (matchingShelf) {
                matchingShelf.books.push({bookName, author});
            }
        }
    }

    let sortedShelves = Object.entries(shelf).sort((a, b) => b[1].books.length - a[1].books.length);

    for (const [id, data] of sortedShelves) {
        console.log(`${id} ${data.genre}: ${data.books.length}`);

        let sortedBooks = data.books.sort((a, b) => a.bookName.localeCompare(b.bookName));

        for (const sortedBook of sortedBooks) {
            console.log(`--> ${sortedBook.bookName}: ${sortedBook.author}`);
        }
    }
}

bookShelf(['1 -> history', '1 -> action', 'Death in Time: Criss Bell, mystery', '2 -> mystery', '3 -> sci-fi', 'Child of Silver: Bruce Rich, mystery', 'Hurting Secrets: Dustin Bolt, action', 'Future of Dawn: Aiden Rose, sci-fi', 'Lions and Rats: Gabe Roads, history', '2 -> romance', 'Effect of the Void: Shay B, romance', 'Losing Dreams: Gail Starr, sci-fi', 'Name of Earth: Jo Bell, sci-fi', 'Pilots of Stone: Brook Jay, history']);
bookShelf(['1 -> mystery', '2 -> sci-fi', 'Child of Silver: Bruce Rich, mystery', 'Lions and Rats: Gabe Roads, history', 'Effect of the Void: Shay B, romance', 'Losing Dreams: Gail Starr, sci-fi', 'Name of Earth: Jo Bell, sci-fi']);