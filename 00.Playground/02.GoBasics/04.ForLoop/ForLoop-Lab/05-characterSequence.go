package main

import (
	"fmt"
)

func main() {
	var input string
	fmt.Scan(&input)

	for _, v := range input {

		fmt.Println(string(v))
	}
}
