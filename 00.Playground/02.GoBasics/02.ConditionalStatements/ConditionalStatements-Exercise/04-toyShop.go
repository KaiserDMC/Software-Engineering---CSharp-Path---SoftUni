package main

import (
	"fmt"
	"math"
)

func main() {
	var tripCost float64
	var numberPuzzles, numberDolls, numberBears, numberMinions, numberTrucks int64

	fmt.Scan(&tripCost)
	fmt.Scan(&numberPuzzles)
	fmt.Scan(&numberDolls)
	fmt.Scan(&numberBears)
	fmt.Scan(&numberMinions)
	fmt.Scan(&numberTrucks)

	totalWinnings := float64(numberPuzzles)*2.6 + float64(numberDolls)*3 + float64(numberBears)*4.1 + float64(numberMinions)*8.2 + float64(numberTrucks)*2

	totalToys := numberPuzzles + numberDolls + numberBears + numberMinions + numberTrucks

	if totalToys >= 50 {
		totalWinnings *= 0.75
	}

	totalWinnings *= 0.9

	difference := totalWinnings - tripCost

	if difference >= 0 {
		fmt.Printf("Yes! %.2f lv left.", difference)
	} else {
		fmt.Printf("Not enough money! %.2f lv needed.", math.Abs(difference))
	}
}
