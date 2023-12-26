package main

import "fmt"

func main() {
	var input int64
	var day string

	fmt.Scanln(&input)

	switch input {
	case 1:
		day = "Monday"
	case 2:
		day = "Tuesday"
	case 3:
		day = "Wednesday"
	case 4:
		day = "Thursday"
	case 5:
		day = "Friday"
	case 6:
		day = "Saturday"
	case 7:
		day = "Sunday"
	default:
		day = "Error"
	}

	fmt.Println(day)
}
