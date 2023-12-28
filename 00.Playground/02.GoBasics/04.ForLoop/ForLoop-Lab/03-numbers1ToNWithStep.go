package main

import "fmt"

func main() {
	var n int
	fmt.Scan(&n)

	for i := 1; i <= n; i += 3 {
		fmt.Println(i)
	}
}
