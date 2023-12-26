package main

import "fmt"

func main() {
	var product, city string
	var quantity float64
	fmt.Scanln(&product)
	fmt.Scanln(&city)
	fmt.Scanln(&quantity)

	var cost float64

	switch product {
	case "coffee":
		if city == "Sofia" {
			cost = quantity * 0.5
		} else if city == "Plovdiv" {
			cost = quantity * 0.4
		} else if city == "Varna" {
			cost = quantity * 0.45
		}
	case "water":
		if city == "Sofia" {
			cost = quantity * 0.8
		} else if city == "Plovdiv" {
			cost = quantity * 0.7
		} else if city == "Varna" {
			cost = quantity * 0.7
		}
	case "beer":
		if city == "Sofia" {
			cost = quantity * 1.2
		} else if city == "Plovdiv" {
			cost = quantity * 1.15
		} else if city == "Varna" {
			cost = quantity * 1.1
		}
	case "sweets":
		if city == "Sofia" {
			cost = quantity * 1.45
		} else if city == "Plovdiv" {
			cost = quantity * 1.3
		} else if city == "Varna" {
			cost = quantity * 1.35
		}
	case "peanuts":
		if city == "Sofia" {
			cost = quantity * 1.6
		} else if city == "Plovdiv" {
			cost = quantity * 1.5
		} else if city == "Varna" {
			cost = quantity * 1.55
		}
	}

	fmt.Println(cost)
}
