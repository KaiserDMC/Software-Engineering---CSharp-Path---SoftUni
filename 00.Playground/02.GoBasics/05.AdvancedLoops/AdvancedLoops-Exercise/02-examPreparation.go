package main

import (
	"fmt"
)

func main() {
	var maxFailure, grade, counterTasks, failureCounter int
	var sumGrade float64
	var lastTask, taskName string
	fmt.Scanln(&maxFailure)

	for {
		if maxFailure == failureCounter {
			fmt.Printf("You need a break, %v poor grades.", failureCounter)
			break
		}

		fmt.Scanln(&taskName)

		if taskName == "Enough" {
			fmt.Printf("Average score: %.2f\n", sumGrade/float64(counterTasks))
			fmt.Printf("Number of problems: %v\n", counterTasks)
			fmt.Printf("Last problem: %v\n", lastTask)
			break
		}

		fmt.Scanln(&grade)

		if grade <= 4 {
			failureCounter++
		}

		sumGrade += float64(grade)
		counterTasks++
		lastTask = taskName
	}
}
