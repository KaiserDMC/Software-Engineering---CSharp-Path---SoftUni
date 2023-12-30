package main

import "fmt"

func main() {
	var n, k int
	fmt.Scan(&n)

	k = 1
	for {
		if k <= n {
			fmt.Println(k)
			k = k*2 + 1
		} else {
			break
		}

	}
}
