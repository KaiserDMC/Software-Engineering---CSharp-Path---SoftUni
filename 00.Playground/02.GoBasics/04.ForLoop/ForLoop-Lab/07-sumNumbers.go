package main

import "fmt"

func main() {
	var n, number int
	fmt.Scan(&n)

	var sum int64
	for i := 0; i < n; i++ {
		fmt.Scan(&number)

		sum += int64(number)
	}

	fmt.Println(sum)
}
