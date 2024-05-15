function attachEvents() {
    const baseUrl = "http://localhost:3030/jsonstore/tasks";
    const [addMealBtn, editMealBtn, loadMealsBtn] = document.querySelectorAll("button");
    const [foodInput, timeInput, caloriesInput] = document.querySelectorAll("input");
    const mealsContainer = document.querySelector("#meals div#list");

    loadMealsBtn.addEventListener("click", loadMeals);
    addMealBtn.addEventListener("click", addMeal);

   async function loadMeals() {
        mealsContainer.innerHTML = "";
        editMealBtn.disabled = true;
        addMealBtn.disabled = false;

        const response = await fetch(baseUrl);
        const data = await response.json();
        const meals = Object.values(data);
        
        meals.forEach(meal => {
            const mealDiv = document.createElement("div");
            mealDiv.className = "meal";
            mealDiv.id = meal._id;

            const foodP = document.createElement("h2");
            foodP.textContent = `${meal.food}`;

            const timeP = document.createElement("h3");
            timeP.textContent = `${meal.time}`;

            const caloriesP = document.createElement("h3");
            caloriesP.textContent = `${meal.calories}`;

            const divButtons = document.createElement("div");
            divButtons.className = "meal-buttons";
            const changeBtn = document.createElement("button");
            changeBtn.textContent = "Change";
            changeBtn.className = "change-meal";
            const deleteBtn = document.createElement("button");
            deleteBtn.textContent = "Delete";
            deleteBtn.className = "delete-meal";

            divButtons.appendChild(changeBtn);
            divButtons.appendChild(deleteBtn);

            mealDiv.appendChild(foodP);
            mealDiv.appendChild(timeP);
            mealDiv.appendChild(caloriesP);
            mealDiv.appendChild(divButtons);

            mealsContainer.appendChild(mealDiv);

            changeBtn.addEventListener("click", (e) => changeMeal(e, meal.food, meal.time, meal.calories, mealDiv.id));

            deleteBtn.addEventListener("click", () => {
                fetch(`${baseUrl}/${mealDiv.id}`, {
                    method: "DELETE"
                }).then(() => {
                    loadMeals();
                });
            });
        });

        async function changeMeal(e, food, time, calories, id) {
            editMealBtn.disabled = false;
            addMealBtn.disabled = true;

            foodInput.value = food;
            timeInput.value = time;
            caloriesInput.value = calories;

            e.target.parentNode.parentElement.remove();

            editMealBtn.addEventListener("click", async () => {
                if (foodInput.value !== "" && caloriesInput.value !== "" && timeInput.value !== "") {
                    const meal = {
                        food: foodInput.value,
                        time: timeInput.value,
                        calories: caloriesInput.value
                    }

                    fetch(`${baseUrl}/${id}`, {
                        method: "PUT",
                        headers: {"Content-Type": "application/json"},
                        body: JSON.stringify(meal)
                    })
                        .then(res => res.json())
                        .then(data => {
                            loadMeals();
                        });
                }

                foodInput.value = "";
                timeInput.value = "";
                caloriesInput.value = "";
            });
        }
    }

    function addMeal() {
        if (foodInput.value !== "" && caloriesInput.value !== "" && timeInput.value !== "") {
            const meal = {
                food: foodInput.value,
                time: timeInput.value,
                calories: caloriesInput.value
            }

            fetch(baseUrl, {
                method: "POST",
                headers: {"Content-Type": "application/json"},
                body: JSON.stringify(meal)
            })
                .then(data => {
                    loadMeals();
                });
        }

        foodInput.value = "";
        timeInput.value = "";
        caloriesInput.value = "";
    }
}

attachEvents()