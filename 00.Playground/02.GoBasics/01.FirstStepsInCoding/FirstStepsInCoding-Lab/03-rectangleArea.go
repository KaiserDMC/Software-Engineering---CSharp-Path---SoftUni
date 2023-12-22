package main

import (
	"fmt"
	"strconv"
	"strings"
)

func main() {
	var a string
	var b string

	fmt.Scanln(&a)
	fmt.Scanln(&b)

	aInt, _ := strconv.Atoi(strings.TrimSpace(a))
	bInt, _ := strconv.Atoi(strings.TrimSpace(b))

	area := aInt * bInt

	fmt.Printf("%v", area)
}
