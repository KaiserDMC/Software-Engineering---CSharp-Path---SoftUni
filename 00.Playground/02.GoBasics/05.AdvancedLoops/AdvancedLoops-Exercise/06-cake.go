package main

import (
	"fmt"
	"math"
	"strconv"
)

func main() {
	var width, length int
	var takenStr string
	fmt.Scanln(&width)
	fmt.Scanln(&length)

	cakeSize := int64(width * length)

	for {
		fmt.Scanln(&takenStr)

		if takenStr == "STOP" {
			fmt.Printf("%v pieces are left.", cakeSize)
			break
		}

		taken, _ := strconv.ParseInt(takenStr, 10, 64)
		cakeSize -= taken

		if cakeSize <= 0 {
			fmt.Printf("No more cake left! You need %v pieces more.", math.Abs(float64(cakeSize)))
			break
		}
	}
}
