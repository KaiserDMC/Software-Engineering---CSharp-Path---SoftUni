package main

import "fmt"

func main() {
	var input, counter int
	fmt.Scan(&input)

	for i := 0; i <= input; i++ {
		for j := 0; j <= input; j++ {
			for k := 0; k <= input; k++ {
				if i+j+k == input {
					counter++
				}
			}
		}
	}

	fmt.Println(counter)
}
