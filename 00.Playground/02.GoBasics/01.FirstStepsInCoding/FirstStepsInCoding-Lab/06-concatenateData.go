package main

import (
	"fmt"
	"strconv"
)

func main() {
	var firstName, lastName, ageStr, town string
	fmt.Scanln(&firstName)
	fmt.Scanln(&lastName)
	fmt.Scanln(&ageStr)
	fmt.Scanln(&town)

	ageInt, _ := strconv.ParseInt(ageStr, 10, 64)

	fmt.Printf("You are %v %v, a %v-years old person from %v.", firstName, lastName, ageInt, town)

}
