package main

import (
	"fmt"
	"math"
	"strconv"
)

func main() {
	var number string
	var max int64
	max = math.MinInt64

	for {
		fmt.Scan(&number)

		if number == "Stop" {
			fmt.Print(max)
			break
		}

		currentNum, _ := strconv.ParseInt(number, 10, 64)

		if currentNum > max {
			max = currentNum
		}
	}
}
