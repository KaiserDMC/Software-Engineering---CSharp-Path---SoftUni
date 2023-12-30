package main

import "fmt"

func main() {
	var juryNumber, counter int
	var presentationName string
	fmt.Scanln(&juryNumber)

	var currGrade, sumGrade, averageGrade, finalGrade float64
	for {
		fmt.Scanln(&presentationName)

		if presentationName == "Finish" {
			break
		}

		for i := 0; i < juryNumber; i++ {
			fmt.Scanln(&currGrade)
			sumGrade += currGrade
		}

		averageGrade = sumGrade / float64(juryNumber)

		fmt.Printf("%v - %.2f.\n", presentationName, averageGrade)

		finalGrade += averageGrade
		counter++
		averageGrade = 0
		sumGrade = 0
	}

	fmt.Printf("Student's final assessment is %.2f.", finalGrade/float64(counter))
}
