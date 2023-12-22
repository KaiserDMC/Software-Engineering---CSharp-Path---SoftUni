package main

import (
	"fmt"
	"strconv"
)

func main() {
	var chickenStr, fishStr, veganStr string

	fmt.Scanln(&chickenStr)
	fmt.Scanln(&fishStr)
	fmt.Scanln(&veganStr)

	countChicken, _ := strconv.ParseInt(chickenStr, 10, 64)
	countFish, _ := strconv.ParseInt(fishStr, 10, 64)
	countVegan, _ := strconv.ParseInt(veganStr, 10, 64)

	totalPriceNoDessert := float64(countChicken)*10.35 + float64(countFish)*12.40 + float64(countVegan)*8.15
	dessertPrice := totalPriceNoDessert * 0.2

	finalPrice := totalPriceNoDessert + dessertPrice + 2.5

	fmt.Printf("%v", finalPrice)
}
