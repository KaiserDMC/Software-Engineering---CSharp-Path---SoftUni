package main

import "fmt"

func main() {
	var input string

	fmt.Scanln(&input)

	switch input {
	case "Monday", "Tuesday", "Wednesday", "Thursday", "Friday":
		fmt.Println("Working day")
	case "Saturday", "Sunday":
		fmt.Println("Weekend")
	default:
		fmt.Println("Error")
	}
}
