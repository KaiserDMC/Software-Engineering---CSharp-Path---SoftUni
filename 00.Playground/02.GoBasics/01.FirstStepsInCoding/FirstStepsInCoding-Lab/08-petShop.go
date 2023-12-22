package main

import (
	"fmt"
	"strconv"
)

func main() {
	var numberDogStr, numberCatStr string
	fmt.Scanln(&numberDogStr)
	fmt.Scanln(&numberCatStr)

	dogPacksInt, _ := strconv.ParseFloat(numberDogStr, 64)
	catPacksInt, _ := strconv.ParseFloat(numberCatStr, 64)

	totalPrice := dogPacksInt*2.5 + catPacksInt*4

	fmt.Printf("%v lv.", totalPrice)
}
