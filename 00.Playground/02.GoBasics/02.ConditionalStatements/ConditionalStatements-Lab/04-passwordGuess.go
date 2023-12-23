package main

import (
	"fmt"
)

func main() {
	var passStr string
	var passwordCheck string = "s3cr3t!P@ssw0rd"

	fmt.Scan(&passStr)

	if passStr == passwordCheck {
		fmt.Println("Welcome")
	} else {
		fmt.Println("Wrong password!")
	}
}
