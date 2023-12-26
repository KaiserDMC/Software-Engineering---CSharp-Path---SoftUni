package main

import (
	"fmt"
	"math"
)

func main() {
	var examHour, examMinutes, arrivalHour, arrivalMinutes int64
	fmt.Scanln(&examHour)
	fmt.Scanln(&examMinutes)
	fmt.Scanln(&arrivalHour)
	fmt.Scanln(&arrivalMinutes)

	totalExamMinutes := examHour*60 + examMinutes
	totalArrivalMinutes := arrivalHour*60 + arrivalMinutes

	difference := totalArrivalMinutes - totalExamMinutes
	hours := difference / 60
	minutes := difference % 60

	if difference > 0 {
		fmt.Printf("Late\n")
		if hours > 0 {
			fmt.Printf("%v:%02d hours after the start", hours, minutes)
		} else {
			fmt.Printf("%v minutes after the start", minutes)
		}
	} else if difference >= -30 && difference <= 0 {
		fmt.Printf("On time\n")
		if difference != 0 {
			fmt.Printf("%v minutes before the start", math.Abs(float64(minutes)))
		}
	} else {
		fmt.Printf("Early\n")

		if hours != 0 {
			fmt.Printf("%v:%02d hours before the start", math.Abs(float64(hours)), int64(math.Abs(float64(minutes))))
		} else {
			fmt.Printf("%02d minutes before the start", int64(math.Abs(float64(minutes))))
		}
	}
}
