package main

import "fmt"

func main() {
	var numberOfGroups, peoplePerGroup int
	fmt.Scanln(&numberOfGroups)

	var musala, monbland, kilimanjaro, k2, everest int
	var totalPeople float64

	for i := 0; i < numberOfGroups; i++ {
		fmt.Scanln(&peoplePerGroup)

		if peoplePerGroup <= 5 {
			musala += peoplePerGroup
		} else if peoplePerGroup <= 12 {
			monbland += peoplePerGroup
		} else if peoplePerGroup <= 25 {
			kilimanjaro += peoplePerGroup
		} else if peoplePerGroup <= 40 {
			k2 += peoplePerGroup
		} else {
			everest += peoplePerGroup
		}

		totalPeople += float64(peoplePerGroup)
	}

	percentMusala := float64(musala) / totalPeople * 100
	percentMonbland := float64(monbland) / totalPeople * 100
	percentKilimanjar := float64(kilimanjaro) / totalPeople * 100
	percentK2 := float64(k2) / totalPeople * 100
	percentEverest := float64(everest) / totalPeople * 100

	fmt.Printf("%.2f%%\n", percentMusala)
	fmt.Printf("%.2f%%\n", percentMonbland)
	fmt.Printf("%.2f%%\n", percentKilimanjar)
	fmt.Printf("%.2f%%\n", percentK2)
	fmt.Printf("%.2f%%\n", percentEverest)
}
