package main

import "fmt"

func main() {
	var degrees int64
	var timeOfDay string
	fmt.Scanln(&degrees)
	fmt.Scanln(&timeOfDay)

	var outfit, shoes string

	switch timeOfDay {
	case "Morning":
		if degrees >= 10 && degrees <= 18 {
			outfit = "Sweatshirt"
			shoes = "Sneakers"
		} else if degrees > 18 && degrees <= 24 {
			outfit = "Shirt"
			shoes = "Moccasins"
		} else if degrees >= 25 {
			outfit = "T-Shirt"
			shoes = "Sandals"
		}
	case "Afternoon":
		if degrees >= 10 && degrees <= 18 {
			outfit = "Shirt"
			shoes = "Moccasins"
		} else if degrees > 18 && degrees <= 24 {
			outfit = "T-Shirt"
			shoes = "Sandals"
		} else if degrees >= 25 {
			outfit = "Swim Suit"
			shoes = "Barefoot"
		}
	case "Evening":
		if degrees >= 10 && degrees <= 18 {
			outfit = "Shirt"
			shoes = "Moccasins"
		} else if degrees > 18 && degrees <= 24 {
			outfit = "Shirt"
			shoes = "Moccasins"
		} else if degrees >= 25 {
			outfit = "Shirt"
			shoes = "Moccasins"
		}
	}

	fmt.Printf("It's %v degrees, get your %v and %v.", degrees, outfit, shoes)
}
