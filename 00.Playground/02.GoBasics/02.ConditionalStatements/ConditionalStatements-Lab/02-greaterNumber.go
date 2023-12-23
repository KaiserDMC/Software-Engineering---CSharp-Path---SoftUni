package main

import (
	"fmt"
	"strconv"
)

func main() {
	var oneStr, twoStr string

	fmt.Scanln(&oneStr)
	fmt.Scanln(&twoStr)

	number1, _ := strconv.ParseInt(oneStr, 10, 64)
	number2, _ := strconv.ParseInt(twoStr, 10, 64)

	if number1 > number2 {
		fmt.Printf("%v", number1)
	} else {
		fmt.Printf("%v", number2)
	}
}
