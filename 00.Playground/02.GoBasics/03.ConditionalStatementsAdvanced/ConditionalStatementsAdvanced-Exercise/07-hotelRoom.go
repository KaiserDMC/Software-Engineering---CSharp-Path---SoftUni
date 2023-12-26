package main

import "fmt"

func main() {
	var month string
	var numberNights int64
	fmt.Scanln(&month)
	fmt.Scanln(&numberNights)

	var studio, apartment float64
	switch month {
	case "May", "October":
		studio = 50 * float64(numberNights)
		apartment = 65 * float64(numberNights)

		if numberNights > 7 && numberNights <= 14 {
			studio *= 0.95
		}
		if numberNights > 14 {
			studio *= 0.7
		}
	case "June", "September":
		studio = 75.2 * float64(numberNights)
		apartment = 68.7 * float64(numberNights)

		if numberNights > 14 {
			studio *= 0.8
		}
	case "July", "August":
		studio = 76 * float64(numberNights)
		apartment = 77 * float64(numberNights)
	}

	if numberNights > 14 {
		apartment *= 0.9
	}

	fmt.Printf("Apartment: %.2f lv.\n", apartment)
	fmt.Printf("Studio: %.2f lv.", studio)
}
