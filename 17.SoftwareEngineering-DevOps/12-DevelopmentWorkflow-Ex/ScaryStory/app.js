window.addEventListener("load", solve);

function solve() {
  let firstNameElement = document.getElementById("first-name");
  let lastNameElement = document.getElementById("last-name");
  let ageElement = document.getElementById("age");
  let storyTitleElement = document.getElementById("story-title");
  let storyElement = document.getElementById("story");
  let publishBtnElement = document.getElementById("form-btn");
  let previewUlElement = document.getElementById("preview-list");
  let mainElement = document.getElementById("main");
  let bodyElement = document.querySelector(".body");


  publishBtnElement.addEventListener('click', onPublish);
  function onPublish(e) {
    e.preventDefault();
    if (firstNameElement.value == ''
      || lastNameElement.value == ''
      || ageElement.value == ''
      || storyTitleElement.value == ''
      || storyElement.value == '') {
      return;
    }

    let liElement = document.createElement("li");
    liElement.setAttribute('class', 'story-info');

    let articleElement = document.createElement("article");

    let fullName = document.createElement("h4");
    fullName.textContent = `Name: ${firstNameElement.value} ${lastNameElement.value}`;

    let Age = document.createElement("p");
    Age.textContent = `Age: ${ageElement.value}`;

    let StoryTitle = document.createElement("p");
    StoryTitle.textContent = `Title: ${storyTitleElement.value}`;

    let StoryText = document.createElement("p");
    StoryText.textContent = `${storyElement.value}`;


    let saveBtn = document.createElement("button");
    saveBtn.setAttribute('class', 'save-btn');
    saveBtn.textContent = 'Save Story';

    let editBtn = document.createElement("button");
    editBtn.setAttribute('class', 'edit-btn');
    editBtn.textContent = 'Edit Story';

    let deleteBtn = document.createElement("button");
    deleteBtn.setAttribute('class', 'delete-btn');
    deleteBtn.textContent = 'Delete Story';

    articleElement.appendChild(fullName);
    articleElement.appendChild(Age);
    articleElement.appendChild(StoryTitle);
    articleElement.appendChild(StoryText);

    liElement.appendChild(articleElement);
    liElement.appendChild(saveBtn);
    liElement.appendChild(editBtn);
    liElement.appendChild(deleteBtn);

    previewUlElement.appendChild(liElement);


    let editFirstName = firstNameElement.value;
    let editLastName = lastNameElement.value;
    let editAge = ageElement.value;
    let editTitle = storyTitleElement.value;
    let editStory = storyElement.value;

    firstNameElement.value = "";
    lastNameElement.value = "";
    ageElement.value = "";
    storyTitleElement.value = "";
    storyElement.value = "";

    publishBtnElement.disabled = true;

    saveBtn.addEventListener("click", onSave);
    function onSave() {
      mainElement.remove();
      let h1Saved = document.createElement("h1");
      h1Saved.textContent = "Your scary story is saved!";
      let bodyElement2 = document.createElement("div");
      bodyElement2.setAttribute('id', 'main');
      bodyElement.appendChild(bodyElement2);

      bodyElement2.appendChild(h1Saved);
    }

    editBtn.addEventListener("click", onEdit);
    function onEdit() {
      firstNameElement.value = editFirstName;
      lastNameElement.value = editLastName;
      ageElement.value = editAge;
      storyTitleElement.value = editTitle;
      storyElement.value = editStory;

      liElement.remove();

      publishBtnElement.disabled = false;
    }

    deleteBtn.addEventListener("click", onDelete);
    function onDelete() {
      liElement.remove();
      publishBtnElement.disabled = false;
    }

  }

}
