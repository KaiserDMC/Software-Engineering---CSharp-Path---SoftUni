package main

import "fmt"

func main() {
	var inputSpeed float64

	fmt.Scan(&inputSpeed)

	if inputSpeed <= 10 {
		fmt.Println("slow")
	} else if inputSpeed <= 50 {
		fmt.Println("average")
	} else if inputSpeed <= 150 {
		fmt.Println("fast")
	} else if inputSpeed <= 1000 {
		fmt.Println("ultra fast")
	} else {
		fmt.Println("extremely fast")
	}
}
