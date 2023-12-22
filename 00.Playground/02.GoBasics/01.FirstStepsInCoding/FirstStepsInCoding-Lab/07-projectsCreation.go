package main

import (
	"fmt"
	"strconv"
)

func main() {
	var architectName, numberProjStr string
	fmt.Scanln(&architectName)
	fmt.Scanln(&numberProjStr)

	numProjects, _ := strconv.ParseInt(numberProjStr, 10, 64)
	hoursToComplete := numProjects * 3

	fmt.Printf("The architect %v will need %v hours to complete %v project/s.", architectName, hoursToComplete, numProjects)
}
