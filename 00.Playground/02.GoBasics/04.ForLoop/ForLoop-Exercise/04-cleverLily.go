package main

import (
	"fmt"
	"math"
)

func main() {
	var n int
	var washingMachine, soldFor float64
	fmt.Scan(&n)
	fmt.Scan(&washingMachine)
	fmt.Scan(&soldFor)

	var money, sum float64
	for i := 1; i <= n; i++ {
		if i%2 == 0 {
			money += 10
			sum += money - 1
		} else {
			sum += soldFor
		}
	}

	difference := sum - washingMachine

	if difference >= 0 {
		fmt.Printf("Yes! %.2f", difference)
	} else {
		fmt.Printf("No! %.2f", math.Abs(difference))
	}
}
