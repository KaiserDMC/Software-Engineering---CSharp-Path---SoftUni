package main

import "fmt"

func main() {
	var city string
	var sales float64
	fmt.Scanln(&city)
	fmt.Scanln(&sales)

	var commission float64

	if sales < 0 {
		fmt.Println("error")
		return
	}

	switch city {
	case "Sofia":
		if sales >= 0 && sales <= 500 {
			commission = 0.05
		} else if sales > 500 && sales <= 1000 {
			commission = 0.07
		} else if sales > 1000 && sales <= 10000 {
			commission = 0.08
		} else if sales > 10000 {
			commission = 0.12
		}

	case "Varna":
		if sales >= 0 && sales <= 500 {
			commission = 0.045
		} else if sales > 500 && sales <= 1000 {
			commission = 0.075
		} else if sales > 1000 && sales <= 10000 {
			commission = 0.1
		} else if sales > 10000 {
			commission = 0.13
		}
	case "Plovdiv":
		if sales >= 0 && sales <= 500 {
			commission = 0.055
		} else if sales > 500 && sales <= 1000 {
			commission = 0.08
		} else if sales > 1000 && sales <= 10000 {
			commission = 0.12
		} else if sales > 10000 {
			commission = 0.145
		}
	default:
		fmt.Println("error")
		return
	}

	finalCommission := sales * commission

	fmt.Printf("%.2f", finalCommission)
}
