package main

import (
	"fmt"
	"strconv"
)

func main() {
	var lengthStr, widthStr, heightStr, percentStr string

	fmt.Scanln(&lengthStr)
	fmt.Scanln(&widthStr)
	fmt.Scanln(&heightStr)
	fmt.Scanln(&percentStr)

	length, _ := strconv.ParseInt(lengthStr, 10, 64)
	width, _ := strconv.ParseInt(widthStr, 10, 64)
	height, _ := strconv.ParseInt(heightStr, 10, 64)
	percentage, _ := strconv.ParseFloat(percentStr, 64)

	tankVolume := float64(length * width * height)
	tankVolume *= 0.001
	tankVolume -= tankVolume * percentage / 100

	fmt.Printf("%v", tankVolume)
}
