package main

import "fmt"

func main() {
	var budget, numberFisherman int64
	var season string
	fmt.Scanln(&budget)
	fmt.Scanln(&season)
	fmt.Scanln(&numberFisherman)

	var boatPrice float64
	switch season {
	case "Spring":
		boatPrice = 3000
	case "Summer", "Autumn":
		boatPrice = 4200
	case "Winter":
		boatPrice = 2600
	}

	if numberFisherman <= 6 {
		boatPrice *= 0.9
	} else if numberFisherman >= 7 && numberFisherman <= 11 {
		boatPrice *= 0.85
	} else if numberFisherman >= 12 {
		boatPrice *= 0.75
	}

	if season != "Autumn" && numberFisherman%2 == 0 {
		boatPrice *= 0.95
	}

	if float64(budget) >= boatPrice {
		fmt.Printf("Yes! You have %.2f leva left.", float64(budget)-boatPrice)
	} else {
		fmt.Printf("Not enough money! You need %.2f leva.", boatPrice-float64(budget))
	}
}
