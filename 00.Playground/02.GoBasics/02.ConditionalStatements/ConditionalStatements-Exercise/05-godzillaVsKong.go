package main

import (
	"fmt"
	"math"
)

func main() {
	var filmBudget, clothingPerActor float64
	var numberOfActors int64

	fmt.Scan(&filmBudget)
	fmt.Scan(&numberOfActors)
	fmt.Scan(&clothingPerActor)

	totalCost := float64(numberOfActors) * clothingPerActor
	if numberOfActors > 150 {
		totalCost *= 0.9
	}

	totalCost += filmBudget * 0.1

	difference := filmBudget - totalCost

	if difference >= 0 {
		fmt.Printf("Action!\n")
		fmt.Printf("Wingard starts filming with %.2f leva left.", difference)
	} else {
		fmt.Printf("Not enough money!\n")
		fmt.Printf("Wingard needs %.2f leva more.", math.Abs(difference))
	}
}
