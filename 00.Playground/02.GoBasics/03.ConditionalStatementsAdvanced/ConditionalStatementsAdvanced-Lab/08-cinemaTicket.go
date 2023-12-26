package main

import "fmt"

func main() {
	var dayOfWeek string
	fmt.Scanln(&dayOfWeek)

	var price int64

	switch dayOfWeek {
	case "Monday", "Tuesday", "Friday":
		price = 12
	case "Wednesday", "Thursday":
		price = 14
	case "Saturday", "Sunday":
		price = 16
	}

	fmt.Println(price)
}
