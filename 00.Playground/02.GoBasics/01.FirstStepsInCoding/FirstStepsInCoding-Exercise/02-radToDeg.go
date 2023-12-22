package main

import (
	"fmt"
	"math"
	"strconv"
)

func main() {
	var radiansStr string
	fmt.Scanln(&radiansStr)

	radians, _ := strconv.ParseFloat(radiansStr, 64)

	degrees := radians * (180 / math.Pi)

	fmt.Printf("%v", degrees)
}
