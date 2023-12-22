package main

import (
	"fmt"
	"strconv"
)

func main() {
	var pagesStr, pagePerHourStr, daysStr string

	fmt.Scanln(&pagesStr)
	fmt.Scanln(&pagePerHourStr)
	fmt.Scanln(&daysStr)

	pagesInBook, _ := strconv.ParseInt(pagesStr, 10, 64)
	singlePageHour, _ := strconv.ParseInt(pagePerHourStr, 10, 64)
	numberDays, _ := strconv.ParseInt(daysStr, 10, 64)

	totalHours := (pagesInBook / singlePageHour) / numberDays

	fmt.Printf("%v", totalHours)
}
