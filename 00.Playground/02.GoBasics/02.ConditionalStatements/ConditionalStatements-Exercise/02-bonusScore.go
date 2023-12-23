package main

import "fmt"

func main() {
	var inputNumber int64
	fmt.Scan(&inputNumber)

	var bonusPoints float64

	if inputNumber <= 100 {
		bonusPoints = 5
	} else if inputNumber > 1000 {
		bonusPoints = float64(inputNumber) * 0.1
	} else {
		bonusPoints = float64(inputNumber) * 0.2
	}

	if inputNumber%2 == 0 {
		bonusPoints += 1
	}

	if inputNumber%10 == 5 {
		bonusPoints += 2
	}

	fmt.Printf("%v\n", bonusPoints)
	fmt.Printf("%v", float64(inputNumber)+bonusPoints)
}
