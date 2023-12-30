package main

import "fmt"

func main() {
	var input string

	for {
		fmt.Scan(&input)

		if input == "Stop" {
			break
		}

		fmt.Println(input)
	}
}
