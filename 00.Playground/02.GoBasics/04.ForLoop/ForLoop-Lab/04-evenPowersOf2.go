package main

import (
	"fmt"
	"math"
)

func main() {
	var n int
	fmt.Scan(&n)

	fmt.Printf("%v\n", 1)
	for i := 1; i <= n; i++ {
		if i%2 == 0 {
			fmt.Printf("%v\n", math.Pow(2, float64(i)))
		}
	}
}
