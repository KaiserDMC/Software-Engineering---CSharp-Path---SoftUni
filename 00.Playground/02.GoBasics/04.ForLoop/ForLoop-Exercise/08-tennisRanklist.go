package main

import (
	"fmt"
	"math"
)

func main() {
	var numberOfTour, initialRanking, winner int
	fmt.Scanln(&numberOfTour)
	fmt.Scanln(&initialRanking)

	var tournamentResult string
	var points float64

	for i := 0; i < numberOfTour; i++ {
		fmt.Scanln(&tournamentResult)

		if tournamentResult == "W" {
			points += 2000
			winner++
		} else if tournamentResult == "F" {
			points += 1200
		} else if tournamentResult == "SF" {
			points += 720
		}
	}

	totalPoints := initialRanking + int(points)
	averagePoints := float64(points) / float64(numberOfTour)
	winAverage := float64(winner) / float64(numberOfTour) * 100

	fmt.Printf("Final points: %v\n", totalPoints)
	fmt.Printf("Average points: %v\n", math.Floor(averagePoints))
	fmt.Printf("%.2f%%", winAverage)
}
