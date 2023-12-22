package main

import (
	"fmt"
	"strconv"
)

func main() {
	var input string
	fmt.Scanln(&input)

	usdFloat, _ := strconv.ParseFloat(input, 64)

	bgn := usdFloat * 1.79549

	fmt.Printf("%v", bgn)
}
