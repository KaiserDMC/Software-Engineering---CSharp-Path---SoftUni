package main

import "fmt"

func main() {
	var fruit, dayOfWeek string
	var quantity float64
	fmt.Scanln(&fruit)
	fmt.Scanln(&dayOfWeek)
	fmt.Scanln(&quantity)

	fruitPricing := map[string]float64{
		"banana":     2.5,
		"apple":      1.2,
		"orange":     0.85,
		"grapefruit": 1.45,
		"kiwi":       2.70,
		"pineapple":  5.50,
		"grapes":     3.85,
	}

	fruitPricingWeekend := map[string]float64{
		"banana":     2.7,
		"apple":      1.25,
		"orange":     0.90,
		"grapefruit": 1.60,
		"kiwi":       3.0,
		"pineapple":  5.60,
		"grapes":     4.20,
	}

	var cost float64
	_, exists := fruitPricing[fruit]

	switch dayOfWeek {
	case "Monday", "Tuesday", "Wednesday", "Thursday", "Friday":
		if exists {
			cost = quantity * fruitPricing[fruit]
		} else {
			fmt.Println("error")
			return
		}
	case "Saturday", "Sunday":
		if exists {
			cost = quantity * fruitPricingWeekend[fruit]
		} else {
			fmt.Println("error")
			return
		}
	default:
		fmt.Println("error")
		return
	}

	fmt.Printf("%.2f", cost)
}
