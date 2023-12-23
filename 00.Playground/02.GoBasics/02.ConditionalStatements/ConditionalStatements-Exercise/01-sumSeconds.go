package main

import "fmt"

func main() {
	var firstTime, secondTime, thirdTime int64
	fmt.Scan(&firstTime)
	fmt.Scan(&secondTime)
	fmt.Scan(&thirdTime)

	totalTime := firstTime + secondTime + thirdTime
	minutes := totalTime / 60
	seconds := totalTime % 60

	fmt.Printf("%v:%02d", minutes, seconds)
}
