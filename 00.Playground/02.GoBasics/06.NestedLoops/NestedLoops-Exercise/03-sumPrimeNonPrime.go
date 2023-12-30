package main

import (
	"fmt"
	"math"
	"strconv"
)

func main() {
	var input string
	var primeSum, nonPrimeSum int64

	for {
		fmt.Scanln(&input)

		if input == "stop" {
			break
		}

		number, _ := strconv.ParseInt(input, 10, 64)

		if number < 0 {
			fmt.Printf("Number is negative.\n")
			continue
		}

		if isPrime(number) {
			primeSum += number
		} else {
			nonPrimeSum += number
		}
	}

	fmt.Printf("Sum of all prime numbers is: %v\n", primeSum)
	fmt.Printf("Sum of all non prime numbers is: %v", nonPrimeSum)
}

func isPrime(num int64) bool {
	if num < 2 {
		return false
	}

	for i := 2; i <= int(math.Sqrt(float64(num))); i++ {
		if int(num)%i == 0 {
			return false
		}
	}

	return true
}
