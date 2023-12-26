package main

import "fmt"

func main() {
	var number1, number2 int64
	var operator string
	fmt.Scanln(&number1)
	fmt.Scanln(&number2)
	fmt.Scanln(&operator)

	var result float64
	var oddOrEven string

	if number2 == 0 {
		fmt.Printf("Cannot divide %v by zero", number1)
		return
	}

	switch operator {
	case "+":
		result = float64(number1) + float64(number2)
	case "-":
		result = float64(number1) - float64(number2)
	case "*":
		result = float64(number1) * float64(number2)
	case "/":
		result = float64(number1) / float64(number2)
	case "%":
		result = float64(number1 % number2)
	}

	if operator == "+" || operator == "-" || operator == "*" {
		temp := int64(result)
		if temp%2 == 0 {
			oddOrEven = "even"
		} else {
			oddOrEven = "odd"
		}

		fmt.Printf("%v %v %v = %v - %v", number1, operator, number2, result, oddOrEven)
	} else {
		if operator == "/" {
			fmt.Printf("%v %v %v = %.2f", number1, operator, number2, result)
		} else {
			fmt.Printf("%v %v %v = %v", number1, operator, number2, result)
		}
	}
}
