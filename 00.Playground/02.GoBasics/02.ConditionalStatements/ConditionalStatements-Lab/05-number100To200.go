package main

import "fmt"

func main() {
	var inputNumber int64

	fmt.Scan(&inputNumber)

	if inputNumber < 100 {
		fmt.Println("Less than 100")
	} else if inputNumber > 200 {
		fmt.Println("Greater than 200")
	} else {
		fmt.Println("Between 100 and 200")
	}
}
