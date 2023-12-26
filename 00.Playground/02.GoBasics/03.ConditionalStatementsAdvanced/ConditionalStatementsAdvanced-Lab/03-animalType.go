package main

import "fmt"

func main() {
	var input string
	fmt.Scan(&input)

	switch input {
	case "dog":
		fmt.Println("mammal")
	case "crocodile", "tortoise", "snake":
		fmt.Println("reptile")
	default:
		fmt.Println("unknown")
	}
}
