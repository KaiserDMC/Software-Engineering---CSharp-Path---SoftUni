package main

import "fmt"

func main() {
	var sum float64
	var counter int
	fmt.Scanln(&sum)

	cents := int(sum * 100)
	for {
		if cents >= 200 {
			cents -= 200
			counter++
		} else if cents >= 100 {
			cents -= 100
			counter++
		} else if cents >= 50 {
			cents -= 50
			counter++
		} else if cents >= 20 {
			cents -= 20
			counter++
		} else if cents >= 10 {
			cents -= 10
			counter++
		} else if cents >= 5 {
			cents -= 5
			counter++
		} else if cents >= 2 {
			cents -= 2
			counter++
		} else if cents >= 1 {
			cents -= 1
			counter++
		}

		if cents <= 0 {
			fmt.Println(counter)
			break
		}
	}
}
