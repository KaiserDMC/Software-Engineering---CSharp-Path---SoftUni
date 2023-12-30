package main

import (
	"fmt"
	"strconv"
)

func main() {
	var stepsPerStr string
	var goal, totalSteps int64
	goal = 10000

	for {
		fmt.Scanln(&stepsPerStr)

		if stepsPerStr == "Goinghome" {
			fmt.Scanln(&stepsPerStr)
			stepsPerDay, _ := strconv.ParseInt(stepsPerStr, 10, 64)

			totalSteps += stepsPerDay
			break
		}

		stepsPerDay, _ := strconv.ParseInt(stepsPerStr, 10, 64)

		totalSteps += stepsPerDay

		if totalSteps >= goal {
			break
		}
	}

	if totalSteps >= goal {
		fmt.Printf("Goal reached! Good job!\n")
		fmt.Printf("%v steps over the goal!", totalSteps-goal)

	} else {
		fmt.Printf("%v more steps to reach goal.", goal-totalSteps)
	}
}
