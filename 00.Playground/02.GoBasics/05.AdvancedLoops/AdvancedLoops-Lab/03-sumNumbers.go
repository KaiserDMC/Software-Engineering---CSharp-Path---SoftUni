package main

import "fmt"

func main() {
	var initialNumber, currNumber, sum int64
	fmt.Scanln(&initialNumber)

	for {
		fmt.Scanln(&currNumber)

		sum += currNumber

		if sum >= initialNumber {
			fmt.Println(sum)
			break
		}
	}
}
