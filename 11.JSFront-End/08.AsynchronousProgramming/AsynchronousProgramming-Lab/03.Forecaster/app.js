function attachEvents() {
    const locationInput = document.getElementById('location');
    const submitBtn = document.getElementById('submit');
    const forecastDiv = document.getElementById('forecast');
    const currentDiv = document.getElementById('current');
    const upcomingDiv = document.getElementById('upcoming');
    const symbols = {
        Sunny: '&#x2600;',
        'Partly sunny': '&#x26C5;',
        Overcast: '&#x2601;',
        Rain: '&#x2614;',
        Degrees: '&#176;'
    };

    const baseUrlLocations = "http://localhost:3030/jsonstore/forecaster/locations";
    const baseUrlToday = "http://localhost:3030/jsonstore/forecaster/today/";
    const baseUrlUpcoming = "http://localhost:3030/jsonstore/forecaster/upcoming/";

    function createTodayElements(todayData) {
        const forecastsDiv = document.createElement('div');
        forecastsDiv.classList.add('forecasts');
        const symbolSpan = document.createElement('span');
        symbolSpan.classList.add('condition', 'symbol');
        symbolSpan.innerHTML = symbols[todayData.forecast.condition];
        const conditionSpan = document.createElement('span');
        conditionSpan.classList.add('condition');
        const nameSpan = document.createElement('span');
        nameSpan.classList.add('forecast-data');
        nameSpan.textContent = todayData.name;
        const degreeSpan = document.createElement('span');
        degreeSpan.classList.add('forecast-data');
        degreeSpan.innerHTML = `${todayData.forecast.low}${symbols.Degrees}/${todayData.forecast.high}${symbols.Degrees}`;
        const weatherSpan = document.createElement('span');
        weatherSpan.classList.add('forecast-data');
        weatherSpan.textContent = todayData.forecast.condition;

        // Append elements
        conditionSpan.appendChild(nameSpan);
        conditionSpan.appendChild(degreeSpan);
        conditionSpan.appendChild(weatherSpan);
        forecastsDiv.appendChild(symbolSpan);
        forecastsDiv.appendChild(conditionSpan);
        currentDiv.appendChild(forecastsDiv);
    }

    function createUpcomingElements(upcomingData) {
        upcomingData.forecast.forEach(day => {

            const forecastsInfoDiv = document.createElement('div');
            forecastsInfoDiv.classList.add('forecast-info');
            const forecastsSpan = document.createElement('span');
            forecastsSpan.classList.add('upcoming');
            const symbolSpan = document.createElement('span');
            symbolSpan.classList.add('symbol');
            symbolSpan.innerHTML = symbols[day.condition];
            const degreesSpan = document.createElement('span');
            degreesSpan.classList.add('forecast-data');
            degreesSpan.innerHTML = `${day.low}${symbols.Degrees}/${day.high}${symbols.Degrees}`;
            const weatherSpan = document.createElement('span');
            weatherSpan.classList.add('forecast-data');
            weatherSpan.textContent = day.condition;
            
            // Append elements
            forecastsInfoDiv.appendChild(symbolSpan);
            forecastsInfoDiv.appendChild(degreesSpan);
            forecastsInfoDiv.appendChild(weatherSpan);

            upcomingDiv.appendChild(forecastsInfoDiv);
        });
    }

    async function getWeather() {
        forecastDiv.style.display = 'block';

        try {
            const locationResponse = await fetch(`${baseUrlLocations}`);
            const locationData = await locationResponse.json();
            const locationInfo = locationData.find(l => l.code === locationInput.value);

            const todayResponse = await fetch(`${baseUrlToday}/${locationInfo.code}`);
            const todayData = await todayResponse.json();

            const upcomingResponse = await fetch(`${baseUrlUpcoming}/${locationInfo.code}`);
            const upcomingData = await upcomingResponse.json();

            // Create elements
            createTodayElements(todayData);
            createUpcomingElements(upcomingData);
        } catch {
            currentDiv.textContent = 'Error';
            upcomingDiv.textContent = '';
        }
    }

    submitBtn.addEventListener('click', getWeather);
}

attachEvents();