package main

import "fmt"

func main() {
	var hour, minutes int64
	fmt.Scan(&hour)
	fmt.Scan(&minutes)

	totalMinutes := hour*60 + minutes
	totalMinutes += 15

	finalHour := totalMinutes / 60
	finalMinutes := totalMinutes % 60

	if finalHour > 23 {
		finalHour -= 24
	}

	fmt.Printf("%v:%02d", finalHour, finalMinutes)
}
