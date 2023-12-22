package main

import (
	"fmt"
	"strconv"
)

func main() {
	var nylonStr, paintStr, detStr, hoursStr string

	fmt.Scanln(&nylonStr)
	fmt.Scanln(&paintStr)
	fmt.Scanln(&detStr)
	fmt.Scanln(&hoursStr)

	nylonInt, _ := strconv.ParseInt(nylonStr, 10, 64)
	paintInt, _ := strconv.ParseInt(paintStr, 10, 64)
	detInt, _ := strconv.ParseInt(detStr, 10, 64)
	hoursInt, _ := strconv.ParseInt(hoursStr, 10, 64)

	totalNylon := float64(nylonInt+2) * 1.5
	totalPaint := float64(paintInt) * 1.1 * 14.5
	totalDetergent := float64(detInt) * 5
	totalBags := 0.4
	totalHours := (totalNylon + totalPaint + totalDetergent + totalBags) * 0.3 * float64(hoursInt)

	finalTotal := totalNylon + totalPaint + totalDetergent + totalBags + totalHours

	fmt.Printf("%v", finalTotal)
}
