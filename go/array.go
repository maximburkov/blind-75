package main

func MaxProfit(prices []int) int {
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
