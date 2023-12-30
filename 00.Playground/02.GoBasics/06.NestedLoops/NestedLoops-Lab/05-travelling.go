package main

import "fmt"

func main() {
	var destination string
	fmt.Scanln(&destination)

	for {
		if destination == "End" {
			break
		}

		var minimumBudget, leftToSave, sumSaved float64
		fmt.Scanln(&minimumBudget)

		leftToSave += sumSaved

		for leftToSave < minimumBudget {
			fmt.Scanln(&sumSaved)
			leftToSave += sumSaved
		}

		if leftToSave >= minimumBudget {
			fmt.Printf("Going to %s!\n", destination)
		}

		fmt.Scanln(&destination)
	}
}
