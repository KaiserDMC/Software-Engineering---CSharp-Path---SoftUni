function solve() {
    document.querySelector('#btnSend').addEventListener('click', onClick);

    function onClick() {
        const inputString = document.querySelector("#inputs textarea").value;
        const inputArray = Array.from(JSON.parse(inputString));
        let restaurants = {};

        for (const currentLine of inputArray) {
            let [restaurantName, workers] = currentLine.split(" - ");
            let workerInformation = workers.split(", ")

            let currentRestaurantWorkers = [];
            let currentRestaurantSalarySum = 0;
            let bestSalary = -1;

            if (restaurants.hasOwnProperty(restaurantName)) {
                currentRestaurantWorkers = restaurants[restaurantName].workers;
                bestSalary = restaurants[restaurantName].bestSalary;
                currentRestaurantSalarySum = restaurants[restaurantName].averageSalary * currentRestaurantWorkers.length;
            }

            for (const workerInf of workerInformation) {
                let [workerName, workerSalary] = workerInf.split(" ");

                let worker = {
                    workerName,
                    workerSalary: Number(workerSalary)
                }

                if (worker.workerSalary > bestSalary) {
                    bestSalary = worker.workerSalary
                }

                currentRestaurantSalarySum += worker.workerSalary;
                currentRestaurantWorkers.push(worker);
            }

            let currentRestaurantAvgSalary = currentRestaurantSalarySum / currentRestaurantWorkers.length;

            restaurants[restaurantName] = {
                restaurantName,
                averageSalary: currentRestaurantAvgSalary,
                bestSalary,
                workers: currentRestaurantWorkers
            }
        }

        let sortedRestaurant = Object.entries(restaurants).sort((a, b) => b[1].averageSalary - a[1].averageSalary);
        let bestRestaurant = sortedRestaurant[0][1];

        document.querySelector("#bestRestaurant p").textContent = `Name: ${bestRestaurant.restaurantName} Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;

        let sortedWorkers = bestRestaurant.workers.sort((a, b) => b.workerSalary - a.workerSalary);
        let outputWorker = "";

        for (const sortedWorker of sortedWorkers) {
            outputWorker += `Name: ${sortedWorker.workerName} With Salary: ${sortedWorker.workerSalary} `;
        }

        document.querySelector("#workers p").textContent = outputWorker;
    }
}