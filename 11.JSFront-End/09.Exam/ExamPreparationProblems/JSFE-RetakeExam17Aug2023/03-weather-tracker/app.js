function attachEvents() {
    const baseUrl = "http://localhost:3030/jsonstore/tasks";
    const loadHistoryButton = document.getElementById("load-history");
    const editWeatherButton = document.getElementById("edit-weather");
    const historyDiv = document.querySelector("#history #list");
    const [locationInput, temperatureInput, dateInput] = document.getElementsByTagName("input");
    const addWeatherButton = document.getElementById("add-weather");
    loadHistoryButton.addEventListener("click", loadHistory);
    addWeatherButton.addEventListener("click", addWeather);

    function loadHistory() {
        historyDiv.innerHTML = "";
        editWeatherButton.disabled = true;

        fetch(baseUrl)
            .then(response => response.json())
            .then(data => {
                Object.values(data).forEach((obj) => {
                    const div = document.createElement("div");
                    div.classList.add("container");

                    const h2 = document.createElement("h2");
                    h2.textContent = obj.location;
                    div.appendChild(h2);

                    const h3Date = document.createElement("h3");
                    h3Date.textContent = obj.date;
                    div.appendChild(h3Date);

                    const h3Temperature = document.createElement("h3");
                    h3Temperature.textContent = obj.temperature;
                    h3Temperature.id = "celsius";
                    div.appendChild(h3Temperature);

                    const buttonsContainer = document.createElement("div");
                    buttonsContainer.id = "buttons-container";

                    const changeBtn = document.createElement("button");
                    changeBtn.textContent = "Change";
                    changeBtn.classList.add("change-btn");
                    buttonsContainer.appendChild(changeBtn);

                    const deleteBtn = document.createElement("button");
                    deleteBtn.textContent = "Delete";
                    deleteBtn.classList.add("delete-btn");
                    buttonsContainer.appendChild(deleteBtn);

                    div.appendChild(buttonsContainer);
                    historyDiv.appendChild(div);

                    const id = obj._id;

                    changeBtn.addEventListener("click", (e) => changeWeather(h2.textContent, h3Temperature.textContent, h3Date.textContent, id));

                    deleteBtn.addEventListener("click", () => {
                        fetch(`${baseUrl}/${id}`, {
                            method: "DELETE"
                        }).then(() => {
                            loadHistory();
                        });
                    });
                });
            });
    }

    function addWeather() {
        const location = locationInput.value;
        const temperature = temperatureInput.value;
        const date = dateInput.value;

        if (location && temperature && date) {
            const newWeather = {
                location,
                temperature,
                date
            };

            fetch(baseUrl, {
                method: "POST",
                headers: {"Content-Type": "application/json"},
                body: JSON.stringify(newWeather)
            })
                .then(data => {
                    loadHistory();
                });
        }

        locationInput.value = "";
        temperatureInput.value = "";
        dateInput.value = "";
    }

    async function changeWeather(location, temperature, date, id) {
        editWeatherButton.disabled = false;
        addWeatherButton.disabled = true;
        
        locationInput.value = location;
        temperatureInput.value = temperature;
        dateInput.value = date;

        editWeatherButton.addEventListener("click", async () => {
            const newLocation = locationInput.value;
            const newTemperature = temperatureInput.value;
            const newDate = dateInput.value;

            if (newLocation && newTemperature && newDate) {
                const newWeather = {
                    location: newLocation,
                    temperature: newTemperature,
                    date: newDate
                };

                await fetch(`${baseUrl}/${id}`, {
                    method: "PUT",
                    headers: {"Content-Type": "application/json"},
                    body: JSON.stringify(newWeather)
                }).then(response => response.json())
                    .then(data => {
                        loadHistory();
                    });
            }

            locationInput.value = "";
            temperatureInput.value = "";
            dateInput.value = "";
        });
    }
}

attachEvents()