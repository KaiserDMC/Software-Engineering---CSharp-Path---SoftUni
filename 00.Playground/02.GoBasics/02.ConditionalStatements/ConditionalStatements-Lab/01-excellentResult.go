package main

import (
	"fmt"
	"strconv"
)

func main() {
	var gradeStr string

	fmt.Scanln(&gradeStr)

	grade, _ := strconv.ParseFloat(gradeStr, 64)

	if grade >= 5 {
		fmt.Printf("Excellent!")
	}
}
