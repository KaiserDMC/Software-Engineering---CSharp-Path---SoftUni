package main

import (
	"fmt"
	"strconv"
)

func main() {
	var numberStr string

	fmt.Scanln(&numberStr)

	number, _ := strconv.ParseInt(numberStr, 10, 64)

	if number%2 == 0 {
		fmt.Println("even")
	} else {
		fmt.Println("odd")
	}
}
