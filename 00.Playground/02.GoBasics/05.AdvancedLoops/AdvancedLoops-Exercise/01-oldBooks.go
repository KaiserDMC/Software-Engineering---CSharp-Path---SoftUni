package main

import (
	"bufio"
	"fmt"
	"os"
	"strings"
)

func main() {
	reader := bufio.NewReader(os.Stdin)
	favBook, _ := reader.ReadString('\n')
	favBook = strings.TrimSpace(favBook)
	var checkCounter int

	for {
		currBook, _ := reader.ReadString('\n')
		currBook = strings.TrimSpace(currBook)

		if currBook == "NoMoreBooks" {
			fmt.Printf("The book you search is not here!\nYou checked %v books.", checkCounter)
			break
		}

		if currBook == favBook {
			fmt.Printf("You checked %v books and found it.", checkCounter)
			break
		}
		checkCounter++
	}
}
