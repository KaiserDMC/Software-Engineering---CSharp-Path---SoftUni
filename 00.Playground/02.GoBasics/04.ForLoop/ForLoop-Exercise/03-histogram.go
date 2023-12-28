package main

import "fmt"

func main() {
	var n, p1, p2, p3, p4, p5 int
	fmt.Scan(&n)

	var currNumber int64
	for i := 0; i < n; i++ {
		fmt.Scan(&currNumber)

		if currNumber < 200 {
			p1++
		} else if currNumber < 400 {
			p2++
		} else if currNumber < 600 {
			p3++
		} else if currNumber < 800 {
			p4++
		} else {
			p5++
		}
	}

	fmt.Printf("%.2f%%\n", float64(p1)/float64(n)*100)
	fmt.Printf("%.2f%%\n", float64(p2)/float64(n)*100)
	fmt.Printf("%.2f%%\n", float64(p3)/float64(n)*100)
	fmt.Printf("%.2f%%\n", float64(p4)/float64(n)*100)
	fmt.Printf("%.2f%%\n", float64(p5)/float64(n)*100)
}
