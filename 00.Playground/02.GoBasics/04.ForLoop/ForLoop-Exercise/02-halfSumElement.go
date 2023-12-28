package main

import (
	"fmt"
	"math"
)

func main() {
	var n int
	fmt.Scan(&n)

	var number, sum, max int64
	max = math.MinInt64
	for i := 0; i < n; i++ {
		fmt.Scan(&number)

		sum += number

		if number > max {
			max = number
		}
	}

	difference := sum - max

	if max == difference {
		fmt.Printf("Yes\n")
		fmt.Printf("Sum = %v", max)
	} else {
		fmt.Printf("No\n")
		fmt.Printf("Diff = %.0f", math.Abs(float64(max)-float64(difference)))
	}
}
