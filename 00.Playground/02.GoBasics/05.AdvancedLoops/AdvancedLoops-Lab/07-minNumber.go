package main

import (
	"fmt"
	"math"
	"strconv"
)

func main() {
	var number string
	var min int64
	min = math.MaxInt64

	for {
		fmt.Scan(&number)

		if number == "Stop" {
			fmt.Print(min)
			break
		}

		currentNum, _ := strconv.ParseInt(number, 10, 64)

		if currentNum < min {
			min = currentNum
		}
	}
}
