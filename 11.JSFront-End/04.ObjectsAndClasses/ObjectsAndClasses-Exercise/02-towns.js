function townObjects(inputArr) {
    for (const inputArrElement of inputArr) {
        let [town, latitude, longitude] = inputArrElement.split(" | ");
        
        latitude = parseFloat(latitude).toFixed(2);
        longitude = parseFloat(longitude).toFixed(2);
        
        let city = {
            town,
            latitude,
            longitude
        }
        
        console.log(city);
    }
}

townObjects(['Sofia | 42.696552 | 23.32601', 'Beijing | 39.913818 | 116.363625']);
townObjects(['Plovdiv | 136.45 | 812.575']);