package main

import "fmt"

func main() {
	var input int64
	fmt.Scanln(&input)

	if input >= 100 && input <= 200 {
	} else {
		if input != 0 {
			fmt.Println("invalid")
		}
	}
}
