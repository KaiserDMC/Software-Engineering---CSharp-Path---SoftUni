package main

import (
	"fmt"
	"math"
)

func main() {
	var budget float64
	var numberGpu, numberCpu, numberRam int64

	fmt.Scan(&budget)
	fmt.Scan(&numberGpu)
	fmt.Scan(&numberCpu)
	fmt.Scan(&numberRam)

	totalGpu := float64(numberGpu) * 250
	totalCpu := totalGpu * 0.35 * float64(numberCpu)
	totalRam := totalGpu * 0.1 * float64(numberRam)

	totalCost := totalGpu + totalCpu + totalRam

	if numberGpu > numberCpu {
		totalCost *= 0.85
	}

	difference := budget - totalCost

	if difference >= 0 {
		fmt.Printf("You have %.2f leva left!", difference)
	} else {
		fmt.Printf("Not enough money! You need %.2f leva more!", math.Abs(difference))
	}
}
