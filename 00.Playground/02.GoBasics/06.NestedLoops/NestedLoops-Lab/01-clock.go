package main

import "fmt"

func main() {
	for h := 0; h <= 23; h++ {
		for m := 0; m <= 59; m++ {
			fmt.Printf("%v:%v\n", h, m)
		}
	}
}
