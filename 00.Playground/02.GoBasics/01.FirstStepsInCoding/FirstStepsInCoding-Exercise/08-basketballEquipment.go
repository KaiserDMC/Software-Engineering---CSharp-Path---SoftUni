package main

import (
	"fmt"
	"strconv"
)

func main() {
	var yearlyTaxStr string

	fmt.Scanln(&yearlyTaxStr)

	yearlyTaxInt, _ := strconv.ParseInt(yearlyTaxStr, 10, 64)

	var sneakers float64 = float64(yearlyTaxInt) * 0.6
	var jersey float64 = sneakers * 0.8
	var ball float64 = jersey * 0.25
	var accessories float64 = ball * 0.2

	totalExpenses := float64(yearlyTaxInt) + sneakers + jersey + ball + accessories

	fmt.Printf("%v", totalExpenses)
}
