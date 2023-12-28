package main

import (
	"fmt"
	"math"
)

func main() {
	var n int
	var oddNumber, evenNumber, sumOdd, sumEven int64
	fmt.Scan(&n)

	for i := 0; i < n; i++ {
		if i%2 == 0 {
			fmt.Scan(&evenNumber)

			sumEven += evenNumber
			continue
		}

		fmt.Scan(&oddNumber)
		sumOdd += oddNumber
	}

	if sumEven == sumOdd {
		fmt.Printf("Yes\n")
		fmt.Printf("Sum = %v", sumEven)
	} else {
		fmt.Printf("No\n")
		fmt.Printf("Diff = %v", math.Abs(float64(sumEven)-float64(sumOdd)))
	}
}
