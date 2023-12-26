package main

import (
	"bufio"
	"fmt"
	"os"
	"strings"
)

func main() {
	var daysOfStay int64
	fmt.Scanln(&daysOfStay)

	reader := bufio.NewReader(os.Stdin)
	typeRoomInput, _ := reader.ReadString('\n')
	typeRoomInput = strings.TrimSpace(typeRoomInput)
	typeRoomFields := strings.Fields(typeRoomInput)
	typeRoom := strings.Join(typeRoomFields, " ")

	var feedback string
	fmt.Scanln(&feedback)

	nights := daysOfStay - 1
	var price float64

	switch typeRoom {
	case "room for one person":
		price = 18
	case "apartment":
		price = 25

		if nights < 10 {
			price *= 0.7
		} else if nights >= 10 && nights <= 15 {
			price *= 0.65
		} else if nights > 15 {
			price *= 0.5
		}
	case "president apartment":
		price = 35

		if nights < 10 {
			price *= 0.9
		} else if nights >= 10 && nights <= 15 {
			price *= 0.85
		} else if nights > 15 {
			price *= 0.8
		}
	}

	totalCost := price * float64(nights)

	if feedback == "positive" {
		totalCost *= 1.25
	} else if feedback == "negative" {
		totalCost *= 0.9
	}

	fmt.Printf("Total cost: %.2f\n", totalCost)
}
