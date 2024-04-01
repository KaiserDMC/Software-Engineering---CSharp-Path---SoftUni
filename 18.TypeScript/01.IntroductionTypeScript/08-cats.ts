class cat {
    name: string
    age: number

    constructor(name: string, age: number) {
        this.name = name
        this.age = age
    }

    meow(): string {
        return 'Meow'
    }
}

function solveCats(arr: string[]): void {
    let cats: cat[] = []
    for (let i = 0; i < arr.length; i++) {
        let [name, age] = arr[i].split(' ')
        cats.push(new cat(name, Number(age)))
    }

    cats.forEach(cat => {
        console.log(`${cat.name}, age ${cat.age} says ${cat.meow()}`)
    })
}

solveCats(['Mellow 2', 'Tom 5']) // Mellow, age 2 says Meow; Tom, age 5 says Meow
solveCats(['Candy 1', 'Poppy 3', 'Nyx 2']) // Candy, age 1 says Meow; Poppy, age 3 says Meow; Nyx, age 2 says Meow