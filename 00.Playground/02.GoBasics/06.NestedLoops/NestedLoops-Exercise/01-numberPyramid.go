package main

import "fmt"

func main() {
	var n int
	fmt.Scan(&n)

	current := 1
	isBigger := false
	for i := 1; i <= n; i++ {
		for j := 1; j <= i; j++ {
			if current > n {
				isBigger = true
				break
			}

			fmt.Printf("%v ", current)
			current++
		}

		if isBigger {
			break
		}

		fmt.Printf("\n")
	}
}
