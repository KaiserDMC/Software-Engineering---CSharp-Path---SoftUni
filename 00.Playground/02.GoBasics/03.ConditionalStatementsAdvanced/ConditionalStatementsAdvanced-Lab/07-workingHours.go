package main

import "fmt"

func main() {
	var hour int64
	var day string
	fmt.Scanln(&hour)
	fmt.Scanln(&day)

	switch day {
	case "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday":
		if hour >= 10 && hour < 18 {
			fmt.Println("open")
		} else {
			fmt.Println("closed")
		}
	default:
		fmt.Println("closed")
	}
}
