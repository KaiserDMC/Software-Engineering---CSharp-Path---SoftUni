package main

import "fmt"

func main() {
	var neededMoney, availableMoney, currMoney float64
	var action string
	var dayCounter, spendCounter int
	fmt.Scanln(&neededMoney)
	fmt.Scanln(&availableMoney)

	for {
		if availableMoney >= neededMoney {
			fmt.Printf("You saved the money for %v days.", dayCounter)
			break
		}

		fmt.Scanln(&action)
		fmt.Scanln(&currMoney)

		dayCounter++
		switch action {
		case "spend":
			availableMoney -= currMoney
			spendCounter++
		case "save":
			availableMoney += currMoney
			spendCounter = 0
		}

		if availableMoney < 0 {
			availableMoney = 0
		}

		if spendCounter == 5 {
			fmt.Printf("You can't save the money.\n")
			fmt.Printf("%v", dayCounter)
			break
		}
	}
}
