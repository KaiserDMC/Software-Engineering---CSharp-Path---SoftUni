package main

import (
	"fmt"
	"strconv"
)

func main() {
	var inches string

	fmt.Scanln(&inches)
	inchesFloat, _ := strconv.ParseFloat(inches, 64)

	cm := inchesFloat * 2.54

	fmt.Printf("%v", cm)
}
