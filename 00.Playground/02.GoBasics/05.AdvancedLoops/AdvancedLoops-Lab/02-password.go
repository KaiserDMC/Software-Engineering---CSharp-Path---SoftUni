package main

import "fmt"

func main() {
	var username, password string
	fmt.Scanln(&username)
	fmt.Scanln(&password)

	var guessedPass string
	for {
		fmt.Scanln(&guessedPass)

		if guessedPass == password {
			fmt.Printf("Welcome %v!", username)
			break
		}
	}
}
