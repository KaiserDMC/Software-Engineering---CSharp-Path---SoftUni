package main

import (
	"fmt"
	"strconv"
)

func main() {
	var sumStr, periodStr, percentageStr string

	fmt.Scanln(&sumStr)
	fmt.Scanln(&periodStr)
	fmt.Scanln(&percentageStr)

	sumFloat, _ := strconv.ParseFloat(sumStr, 64)
	periodInt, _ := strconv.ParseInt(periodStr, 10, 64)
	percentageFloat, _ := strconv.ParseFloat(percentageStr, 64)

	calculatedSum := sumFloat + float64(periodInt)*((sumFloat*percentageFloat/100)/12)

	fmt.Printf("%v", calculatedSum)
}
