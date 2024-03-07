import { html } from '../../node_modules/lit-html/lit-html.js';
import { getBookById, updateBook } from '../api/data.js';


const editTemplate = (book, onSubmit) => html`
<section id="edit-page" class="edit">
    <form @submit=${onSubmit} id="edit-form" action="#" method="">
        <fieldset>
            <legend>Edit my Book</legend>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" .value=${book.title}>
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description" id="description">${book.description}</textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" .value=${book.imageUrl}>
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type" .value=${book.type}>
                        <option value="Fiction" selected>Fiction</option>
                        <option value="Romance">Romance</option>
                        <option value="Mistery">Mistery</option>
                        <option value="Classic">Clasic</option>
                        <option value="Other">Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Save">
        </fieldset>
    </form>
</section>
`;


export async function editPage(ctx) {
    const id = ctx.params.id;
    const book = await getBookById(id);

    ctx.render(editTemplate(book, onSubmit));

    async function onSubmit(e) {
        e.preventDefault();
        const formData = new FormData(e.target);
        const title = formData.get('title').trim();
        const description = formData.get('description').trim();
        const imageUrl = formData.get('imageUrl').trim();
        const type = formData.get('type').trim();

        if (!title || !description || !imageUrl || !type) {
            return alert('All fields are required!');
        }

        await updateBook(id, {title, description, imageUrl, type});
        ctx.page.redirect('/details/' + id);
    }
}