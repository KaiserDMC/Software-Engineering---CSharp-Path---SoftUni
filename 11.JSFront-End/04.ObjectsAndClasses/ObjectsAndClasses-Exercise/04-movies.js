function movieJson(inputArr) {
    let movies = {};

    for (const element of inputArr) {
        if (element.includes("addMovie ")) {
            let [command, name] = element.split("addMovie ");
            movies[name] = {};
            movies[name].name = name;
        } else if (element.includes(" directedBy ")) {
            let [name, director] = element.split(" directedBy ");

            if (name in movies) {
                movies[name].director = director;
            }
        } else if (element.includes(" onDate ")) {
            let [name, date] = element.split(" onDate ");

            if (name in movies) {
                movies[name].date = date;
            }
        }
    }

    for (const key in movies) {
        if (Object.keys(movies[key]).length === 3) {
            console.log(JSON.stringify(movies[key]));
        }
    }
}

movieJson(['addMovie Fast and Furious', 'addMovie Godfather', 'Inception directedBy Christopher Nolan', 'Godfather directedBy Francis Ford Coppola', 'Godfather onDate 29.07.2018', 'Fast and Furious onDate 30.07.2018', 'Batman onDate 01.08.2018', 'Fast and Furious directedBy Rob Cohen']);
movieJson(['addMovie The Avengers', 'addMovie Superman', 'The Avengers directedBy Anthony Russo', 'The Avengers onDate 30.07.2010', 'Captain America onDate 30.07.2010', 'Captain America directedBy Joe Russo']);