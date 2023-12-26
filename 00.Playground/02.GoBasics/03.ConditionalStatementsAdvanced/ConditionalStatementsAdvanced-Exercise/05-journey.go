package main

import "fmt"

func main() {
	var budget float64
	var season string
	fmt.Scanln(&budget)
	fmt.Scanln(&season)

	var destination, typeStay string
	var cost float64
	if budget <= 100 {
		destination = "Bulgaria"
		if season == "summer" {
			typeStay = "Camp"
			cost = budget * 0.3
		} else {
			typeStay = "Hotel"
			cost = budget * 0.7
		}
	} else if budget <= 1000 {
		destination = "Balkans"
		if season == "summer" {
			typeStay = "Camp"
			cost = budget * 0.4
		} else {
			typeStay = "Hotel"
			cost = budget * 0.8
		}
	} else if budget > 1000 {
		destination = "Europe"
		typeStay = "Hotel"
		cost = budget * 0.9
	}

	fmt.Printf("Somewhere in %v\n", destination)
	fmt.Printf("%v - %.2f", typeStay, cost)
}
