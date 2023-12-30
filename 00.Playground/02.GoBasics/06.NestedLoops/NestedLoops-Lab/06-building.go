package main

import "fmt"

func main() {
	var floors, rooms int
	fmt.Scanln(&floors)
	fmt.Scanln(&rooms)

	for i := floors; i >= 1; i-- {
		for j := 0; j < rooms; j++ {
			if i == floors {
				fmt.Printf("L%v%v ", i, j)
				continue
			}

			if i%2 == 0 {
				fmt.Printf("O%v%v ", i, j)
			} else {
				fmt.Printf("A%v%v ", i, j)
			}
		}

		fmt.Printf("\n")
	}
}
