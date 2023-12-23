package main

import (
	"fmt"
)

func main() {
	var worldRecord, distance, timeSeconds float64

	fmt.Scan(&worldRecord)
	fmt.Scan(&distance)
	fmt.Scan(&timeSeconds)

	swimTime := distance * timeSeconds
	waterResistance := float64(int64(distance/15)) * 12.5
	swimTime += waterResistance

	if swimTime >= worldRecord {
		fmt.Printf("No, he failed! He was %.2f seconds slower.", swimTime-worldRecord)
	} else {
		fmt.Printf("Yes, he succeeded! The new world record is %.2f seconds.", swimTime)
	}
}
