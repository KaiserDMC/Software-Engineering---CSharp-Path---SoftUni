package main

import (
	"fmt"
	"math"
	"strconv"
)

func main() {
	var width, length, height int
	var command string
	fmt.Scanln(&width)
	fmt.Scanln(&length)
	fmt.Scanln(&height)

	totalSpace := int64(width * length * height)

	for {
		fmt.Scanln(&command)

		if command == "Done" {
			fmt.Printf("%v Cubic meters left.", totalSpace)
			break
		}

		currCubic, _ := strconv.ParseInt(command, 10, 64)
		totalSpace -= currCubic

		if totalSpace <= 0 {
			fmt.Printf("No more free space! You need %v Cubic meters more.", math.Abs(float64(totalSpace)))
			break
		}
	}
}
