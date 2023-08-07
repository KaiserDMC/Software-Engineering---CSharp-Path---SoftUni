const images = [];

const form = document.querySelector('form');
const list = document.querySelector('ul');

function renderMessages() {
  let items = '';
  for (const image of images) {
    items = `
      ${items}
      <li class="item">
        <div class="image">
          <img src="${image.image}">
        </div>
      </li>
    `;
  }

  // The above HTML should be sanitazied or not added as a pure HTML
  list.innerHTML = items;
}

function formSubmitHandler(event) {
  event.preventDefault();
  const imageInputField = event.target.querySelector('input');
  const imageUrl = imageInputField.value;

  if (!imageUrl ||
    imageUrl.trim().length === 0) {
    alert('Please insert a valid image URL.');
    return;
  }

  images.push({
    image: imageUrl,
  });

  imageInputField.value = '';

  renderMessages();
}

form.addEventListener('submit', formSubmitHandler);
