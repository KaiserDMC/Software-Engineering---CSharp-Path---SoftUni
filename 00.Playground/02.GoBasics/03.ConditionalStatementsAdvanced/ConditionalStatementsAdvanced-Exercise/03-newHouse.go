package main

import "fmt"

func main() {
	var flower string
	var amountFlowers, budget int64
	fmt.Scanln(&flower)
	fmt.Scanln(&amountFlowers)
	fmt.Scanln(&budget)

	flowers := map[string]float64{
		"Roses":     5,
		"Dahlias":   3.8,
		"Tulips":    2.8,
		"Narcissus": 3,
		"Gladiolus": 2.5,
	}

	price := flowers[flower] * float64(amountFlowers)

	switch flower {
	case "Roses":
		if amountFlowers > 80 {
			price *= 0.9
		}
	case "Dahlias":
		if amountFlowers > 90 {
			price *= 0.85
		}
	case "Tulips":
		if amountFlowers > 80 {
			price *= 0.85
		}
	case "Narcissus":
		if amountFlowers < 120 {
			price *= 1.15
		}
	case "Gladiolus":
		if amountFlowers < 80 {
			price *= 1.2
		}
	}

	if float64(budget) >= price {
		fmt.Printf("Hey, you have a great garden with %v %v and %.2f leva left.", amountFlowers, flower, float64(budget)-price)
	} else {
		fmt.Printf("Not enough money, you need %.2f leva more.", price-float64(budget))
	}
}
