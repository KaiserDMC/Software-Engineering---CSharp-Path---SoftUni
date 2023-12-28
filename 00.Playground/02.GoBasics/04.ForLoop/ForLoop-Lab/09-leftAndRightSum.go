package main

import (
	"fmt"
	"math"
)

func main() {
	var n int
	var leftNum, rightNum, sumLeft, sumRight int64
	fmt.Scan(&n)

	for i := 0; i < n; i++ {
		fmt.Scan(&leftNum)

		sumLeft += leftNum
	}

	for i := 0; i < n; i++ {
		fmt.Scan(&rightNum)

		sumRight += rightNum
	}

	if sumLeft == sumRight {
		fmt.Printf("Yes, sum = %v", sumRight)
	} else {
		fmt.Printf("No, diff = %.0f", math.Abs(float64(sumLeft)-float64(sumRight)))
	}
}
