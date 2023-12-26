package main

import "fmt"

func main() {
	var screeningType string
	var rows, cols int64
	fmt.Scanln(&screeningType)
	fmt.Scanln(&rows)
	fmt.Scanln(&cols)

	var ticketPrice float64

	switch screeningType {
	case "Premiere":
		ticketPrice = 12
	case "Normal":
		ticketPrice = 7.5
	case "Discount":
		ticketPrice = 5
	}

	cost := float64(rows) * float64(cols) * ticketPrice

	fmt.Printf("%.2f leva", cost)
}
