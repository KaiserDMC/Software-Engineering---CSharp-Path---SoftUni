package main

import (
	"bufio"
	"fmt"
	"os"
	"strings"
)

func main() {
	reader := bufio.NewReader(os.Stdin)
	actorsName, _ := reader.ReadString('\n')
	actorsName = strings.TrimSpace(actorsName)

	var academyPoints, singlePoints, totalPoints float64
	var n int
	fmt.Scanln(&academyPoints)
	fmt.Scanln(&n)

	totalPoints = academyPoints

	for i := 0; i < n; i++ {
		academyPerson, _ := reader.ReadString('\n')
		academyPerson = strings.TrimSpace(academyPerson)

		fmt.Scanln(&singlePoints)

		totalPoints += float64(len(academyPerson)) * singlePoints / 2

		if totalPoints > 1250.5 {
			fmt.Printf("Congratulations, %v got a nominee for leading role with %.1f!", actorsName, totalPoints)
			return
		}
	}

	fmt.Printf("Sorry, %v you need %.1f more!", actorsName, 1250.5-totalPoints)
}
