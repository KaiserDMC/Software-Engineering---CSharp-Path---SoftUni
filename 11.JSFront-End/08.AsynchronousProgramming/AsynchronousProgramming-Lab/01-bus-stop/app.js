function getInfo() {
    const baseUrl = "http://localhost:3030/jsonstore/bus/businfo";
    const stopIdValue = document.getElementById('stopId').value;
    const stopName = document.getElementById('stopName');
    const buses = document.getElementById('buses');

    fetch(`${baseUrl}/${stopIdValue}`)
        .then(res => res.json())
        .then(data => {
            stopName.textContent = data.name;
            buses.innerHTML = '';

            Object.entries(data.buses).forEach(([busId, time]) => {
                const li = document.createElement('li');
                li.textContent = `Bus ${busId} arrives in ${time} minutes`;

                buses.appendChild(li);
            });
        })
        .catch(err => {
            stopName.textContent = 'Error';
            buses.innerHTML = '';
        });
}