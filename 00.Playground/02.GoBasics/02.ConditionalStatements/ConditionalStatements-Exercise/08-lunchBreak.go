package main

import (
	"fmt"
	"math"
)

func main() {
	// reader := bufio.NewReader(os.Stdin)
	// seriesName, _ := reader.ReadString('\n')
	// seriesName = strings.TrimSpace(seriesName)
	var seriesName string
	fmt.Scan(&seriesName)

	var episodeLength, breakLength int64
	fmt.Scan(&episodeLength)
	fmt.Scan(&breakLength)

	timeForRest := float64(breakLength) * 0.125
	timeForRelax := float64(breakLength) * 0.25

	leftTime := float64(breakLength) - (timeForRest + timeForRelax)

	timeDifference := leftTime - float64(episodeLength)

	if timeDifference >= 0 {
		fmt.Printf("You have enough time to watch %v and left with %v minutes free time.", seriesName, math.Ceil(timeDifference))
	} else {
		fmt.Printf("You don't have enough time to watch %v, you need %v more minutes.", seriesName, math.Ceil(math.Abs(timeDifference)))
	}
}
