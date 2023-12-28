package main

import "fmt"

func main() {
	for i := 7; i <= 997; i++ {
		if i%10 == 7 {
			fmt.Println(i)
		}
	}
}
