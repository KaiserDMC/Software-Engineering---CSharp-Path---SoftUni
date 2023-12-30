package main

import "fmt"

func main() {
	var studentName string
	var grade, averageGrade, sumGrade float64
	var gradeCounter, failCounter int
	fmt.Scanln(&studentName)

	for {
		fmt.Scanln(&grade)

		if grade < 4 {
			failCounter++
		}

		if failCounter > 1 {
			fmt.Printf("%v has been excluded at %v grade", studentName, gradeCounter)
			break
		}

		gradeCounter++
		sumGrade += grade
		if gradeCounter == 12 {
			averageGrade = sumGrade / float64(gradeCounter)

			fmt.Printf("%v graduated. Average grade: %.2f", studentName, averageGrade)
			break
		}
	}
}
