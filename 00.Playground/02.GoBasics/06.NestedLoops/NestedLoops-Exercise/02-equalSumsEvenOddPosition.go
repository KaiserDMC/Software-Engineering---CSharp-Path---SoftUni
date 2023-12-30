package main

import (
	"fmt"
	"strconv"
)

func main() {
	var firstStr, secondStr string
	fmt.Scanln(&firstStr)
	fmt.Scanln(&secondStr)

	start, _ := strconv.ParseInt(firstStr, 10, 64)
	end, _ := strconv.ParseInt(secondStr, 10, 64)

	for i := start; i <= end; i++ {
		currNumber := strconv.FormatInt(i, 10)

		oddSum := 0
		evenSum := 0
		for j := 0; j < len(currNumber); j++ {
			digit, _ := strconv.ParseInt(string(currNumber[j]), 10, 64)

			if j%2 == 0 {
				evenSum += int(digit)
			} else {
				oddSum += int(digit)
			}
		}

		if oddSum == evenSum {
			fmt.Printf("%v ", i)
		}
	}
}
