package main

import "fmt"

func main() {
	var input string
	fmt.Scan(&input)

	var currNumber, sum int64

	for _, v := range input {
		if string(v) == "a" {
			currNumber = 1
		} else if string(v) == "e" {
			currNumber = 2
		} else if string(v) == "i" {
			currNumber = 3
		} else if string(v) == "o" {
			currNumber = 4
		} else if string(v) == "u" {
			currNumber = 5
		}

		sum += currNumber

		currNumber = 0
	}

	fmt.Println(sum)
}
