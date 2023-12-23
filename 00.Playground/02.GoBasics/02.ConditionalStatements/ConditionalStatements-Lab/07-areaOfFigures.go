package main

import (
	"fmt"
	"math"
)

func main() {
	var figureStr string
	fmt.Scan(&figureStr)

	var sideOne, sideTwo float64
	switch figureStr {
	case "square":
		fmt.Scan(&sideOne)
		fmt.Printf("%.3f", sideOne*sideOne)
	case "rectangle":
		fmt.Scan(&sideOne)
		fmt.Scan(&sideTwo)
		fmt.Printf("%.3f", sideOne*sideTwo)
	case "circle":
		fmt.Scan(&sideOne)
		fmt.Printf("%.3f", math.Pow(sideOne, 2)*math.Pi)
	case "triangle":
		fmt.Scan(&sideOne)
		fmt.Scan(&sideTwo)
		fmt.Printf("%.3f", (sideOne*sideTwo)/2)
	}
}
