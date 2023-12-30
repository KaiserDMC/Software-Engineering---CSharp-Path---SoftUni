package main

import "fmt"

func main() {
	var start, end, magicNumber, counter int
	var magicFound bool
	fmt.Scanln(&start)
	fmt.Scanln(&end)
	fmt.Scanln(&magicNumber)

	magicFound = false
	for i := start; i <= end; i++ {
		for j := start; j <= end; j++ {
			sum := i + j

			counter++
			if sum == magicNumber {
				fmt.Printf("Combination N:%v (%v + %v = %v)\n", counter, i, j, sum)
				magicFound = true
				return
			}
		}
	}

	if !magicFound {
		fmt.Printf("%v combinations - neither equals %v", counter, magicNumber)
	}
}
