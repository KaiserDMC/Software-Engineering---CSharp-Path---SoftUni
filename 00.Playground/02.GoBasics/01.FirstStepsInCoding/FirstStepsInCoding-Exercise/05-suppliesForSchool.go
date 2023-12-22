package main

import (
	"fmt"
	"strconv"
)

func main() {
	var penStr, markerStr, literStr, percStr string

	fmt.Scanln(&penStr)
	fmt.Scanln(&markerStr)
	fmt.Scanln(&literStr)
	fmt.Scanln(&percStr)

	numberPens, _ := strconv.ParseInt(penStr, 10, 64)
	numberMarkers, _ := strconv.ParseInt(markerStr, 10, 64)
	litreCleanex, _ := strconv.ParseInt(literStr, 10, 64)
	percentageDiscount, _ := strconv.ParseInt(percStr, 10, 64)

	var totalMoneyNeeded float64

	totalMoneyNeeded = float64(numberPens)*5.80 + float64(numberMarkers)*7.20 + float64(litreCleanex)*1.2
	totalMoneyNeeded -= totalMoneyNeeded * float64(percentageDiscount) / 100

	fmt.Printf("%v", totalMoneyNeeded)
}
