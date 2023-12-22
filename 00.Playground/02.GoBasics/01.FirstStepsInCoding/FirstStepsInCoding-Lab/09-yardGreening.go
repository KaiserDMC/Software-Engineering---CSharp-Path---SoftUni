package main

import (
	"fmt"
	"strconv"
)

func main() {
	var yardAreaStr string
	fmt.Scanln(&yardAreaStr)

	yardArea, _ := strconv.ParseFloat(yardAreaStr, 64)

	totalCost := yardArea * 7.61
	discount := totalCost * 0.18
	totalCost -= discount

	fmt.Printf("The final price is: %.2f lv.\n", totalCost)
	fmt.Printf("The discount is: %.2f lv.", discount)
}
