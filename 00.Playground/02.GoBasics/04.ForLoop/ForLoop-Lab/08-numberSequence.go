package main

import (
	"fmt"
	"math"
)

func main() {
	var n int
	fmt.Scan(&n)

	var min, max, number int64

	// min = (1 << 63) - 1
	min = math.MaxInt64
	max = math.MinInt64
	for i := 0; i < n; i++ {
		fmt.Scan(&number)

		if number > max {
			max = number
		}

		if number < min {
			min = number
		}
	}

	fmt.Printf("Max number: %v\n", max)
	fmt.Printf("Min number: %v", min)
}
