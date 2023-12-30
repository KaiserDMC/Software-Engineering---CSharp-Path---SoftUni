package main

import (
	"fmt"
	"strconv"
)

func main() {
	var deposit string
	var total float64

	for {
		fmt.Scanln(&deposit)

		if deposit == "NoMoreMoney" {
			break
		}

		depositFloat, _ := strconv.ParseFloat(deposit, 10)

		if depositFloat <= 0 {
			fmt.Printf("Invalid operation!\n")
			break
		}

		total += depositFloat
		fmt.Printf("Increase: %.2f\n", depositFloat)
	}

	fmt.Printf("Total: %.2f", total)
}
