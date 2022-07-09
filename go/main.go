package main

import (
	"fmt"
)

func main() {
	res := maxProfit([]int{7, 1, 5, 3, 6, 4})
	fmt.Println(res)
}

func maxProfit(prices []int) int {
	min := prices[0]
	max := 0

	for i := 1; i < len(prices); i++ {
		dif := prices[i] - min

		if dif > max {
			max = dif
		}

		if prices[i] < min {
			min = prices[i]
		}
	}

	return max
}
