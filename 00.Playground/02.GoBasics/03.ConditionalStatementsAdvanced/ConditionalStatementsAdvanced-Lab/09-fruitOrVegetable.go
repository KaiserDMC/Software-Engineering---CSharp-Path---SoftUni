package main

import (
	"fmt"
	"slices"
)

func main() {
	var input string
	fmt.Scanln(&input)

	fruits := []string{"banana", "apple", "kiwi", "cherry", "lemon", "grapes"}
	vegetables := []string{"tomato", "cucumber", "pepper", "carrot"}

	if slices.Contains(fruits, input) {
		fmt.Println("fruit")
	} else if slices.Contains(vegetables, input) {
		fmt.Println("vegetable")
	} else {
		fmt.Println("unknown")
	}
}

// Without "slices"
func Contains(slice []string, value string) bool {
	for _, item := range slice {
		if item == value {
			return true
		}
	}
	return false
}
