package main

import "fmt"

func main() {
	var numberTabs, salary int
	fmt.Scan(&numberTabs)
	fmt.Scan(&salary)

	var webpage string
	for i := 0; i < numberTabs; i++ {
		fmt.Scan(&webpage)

		if webpage == "Facebook" {
			salary -= 150
		} else if webpage == "Instagram" {
			salary -= 100
		} else if webpage == "Reddit" {
			salary -= 50
		}

		if salary <= 0 {
			fmt.Printf("You have lost your salary.")
			return
		}
	}

	fmt.Println(salary)
}
