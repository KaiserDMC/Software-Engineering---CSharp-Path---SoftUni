import { html } from '../../node_modules/lit-html/lit-html.js';
import { getBookById, deleteBookById, getBookTotalLikes, likeBookApi, isUserAlreadyLiked } from '../api/data.js';


const detailsTemplate = (isCreator, data, onDelete, bookTotalLikes, likeBook, userAlreadyLiked) => html `
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${data.title}</h3>
        <p class="type">Type: ${data.type}</p>
        <p class="img"><img src=${data.imageUrl}></p>
        <div class="actions">
            <!-- Edit/Delete buttons ( Only for creator of this book )  -->
            ${isCreator ? html` <a class="button" href="/edit/${data._id}">Edit</a>
            <a @click=${onDelete} class="button" href="javascript:void(0)">Delete</a>` : ''}


            <!-- Bonus -->
            <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
            ${!isCreator && !userAlreadyLiked ? html`<a @click=${likeBook} class="button"
                href="javascript:void(0)">Like</a>` : ''}

            <!-- ( for Guests and Users )  -->
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: ${bookTotalLikes}</span>
            </div>
            <!-- Bonus -->
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${data.description}</p>
    </div>
</section>
`;

const detailsTemplateGuests = (data, bookTotalLikes) => html `
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${data.title}</h3>
        <p class="type">Type: ${data.type}</p>
        <p class="img"><img src=${data.imageUrl}></p>
        <div class="actions">

            <!-- ( for Guests and Users )  -->
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: ${bookTotalLikes}</span>
            </div>

        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${data.description}</p>
    </div>
</section>
`;

export async function detailsPage(ctx) {
    const id = ctx.params.id;
    const book = await getBookById(id);
    const isCreator = sessionStorage.getItem('userId') === book._ownerId;
    const bookTotalLikes = await getBookTotalLikes(id);

    const isUser = sessionStorage.getItem('userId');

    if (isUser==null) {
      ctx.render(detailsTemplateGuests( book, bookTotalLikes)); 
    }else{

      let userAlreadyLiked = await isUserAlreadyLiked(id, sessionStorage.getItem('userId'));

     console.log(userAlreadyLiked);
      if (userAlreadyLiked == 0) {
          userAlreadyLiked = false;
      }
      if (userAlreadyLiked == 1) {
          userAlreadyLiked = true;
      }

      ctx.render(detailsTemplate(isCreator, book, onDelete, bookTotalLikes, likeBook, userAlreadyLiked));
}

    async function onDelete() {
        const confirmed = confirm('Are you sure?');
        if (confirmed) {
            await deleteBookById(id);
            ctx.page.redirect('/catalog');
        }
    }

    async function likeBook(e) {
        const aTag = e.target;
        aTag.style.display = 'none';
        await likeBookApi(id);
        let likesSpan = document.getElementById('total-likes').textContent;
        const likesCount = likesSpan.split(' ')[1];
        likesSpan = `Likes: ${Number(likesCount) + 1}`;
        console.log(likesCount);
        console.log(likesSpan);
        ctx.page.redirect('/details/' + id);

    }
}