package main

import (
	"fmt"
)

func main() {
	var inputName string
	var availableSeats, takenSeatsCounter, studentCounter, standardCounter, kidCounter, ticketsSold int
	var getOut bool

	for {
		fmt.Scanln(&inputName)

		if inputName == "Finish" {
			fmt.Printf("Total tickets: %v\n", ticketsSold)
			fmt.Printf("%.2f%% student tickets.\n", float64(studentCounter)/float64(ticketsSold)*100)
			fmt.Printf("%.2f%% standard tickets.\n", float64(standardCounter)/float64(ticketsSold)*100)
			fmt.Printf("%.2f%% kids tickets.\n", float64(kidCounter)/float64(ticketsSold)*100)
			break
		}

		fmt.Scanln(&availableSeats)
		movieName := inputName

		for i := 1; i <= availableSeats; i++ {
			var ticketType string
			fmt.Scanln(&ticketType)

			if ticketType == "student" {
				takenSeatsCounter++
				studentCounter++
			} else if ticketType == "standard" {
				takenSeatsCounter++
				standardCounter++
			} else if ticketType == "kid" {
				takenSeatsCounter++
				kidCounter++
			} else if ticketType == "End" {
				break
			}

			if ticketType == "Finish" {
				getOut = true
				break
			}
		}

		percentageFull := float64(takenSeatsCounter) / float64(availableSeats) * 100.00
		ticketsSold += takenSeatsCounter

		fmt.Printf("%v - %.2f%% full.\n", movieName, percentageFull)

		if getOut {
			break
		}

		takenSeatsCounter = 0
	}
}
