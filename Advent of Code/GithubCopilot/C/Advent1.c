#include <stdio.h>
#include <math.h>
//The elves bought too much eggnog again - 150 liters this time. To fit it all into your refrigerator, you'll need to move it into smaller containers. You take an inventory of the capacities of the available containers. For example, suppose you have containers of size 20, 15, 10, 5, and 5 liters. If you need to store 25 liters, there are four ways to do it:
//15 and 10
//20 and 5 (the first 5)
//20 and 5 (the second 5)
//15, 5, and 5
//Filling all containers entirely, how many different combinations of containers can exactly fit all 150 liters of eggnog?

//The input data is given through standard input on the following format: The first row contains the number of available containers Each following line contains the capacity of a container. All capacities are integers and indicate liters. 

//The output data should be printed to standard output given in the following format: One line with the answer. 

int power(int base, int exponent) {
    int i, result;
    result = 1;
    for (i = 0; i < exponent; i++) {
        result *= base;
    }
    return result;
}

int main() {
	int i, j, k, l, m, n, o, p, q, r, s, t, u, v, z, count, temp;
	int input[20];
	int output[20];
	int numContainers, sum, numSolutions;
	
	numSolutions = 0;
	sum = 150;
	
	for (i = 0; i < 20; i++) {
		input[i] = 0;
		output[i] = 0;
	}
	
	scanf("%d", &numContainers);
	
	for (i = 0; i < numContainers; i++) {
		scanf("%d", &input[i]);
	}
    int powerCap = power(2, numContainers);
	
	for (i = 0; i < powerCap; i++) {
		temp = i;
		for (j = 0; j < numContainers; j++) {
			output[j] = temp % 2;
			temp = temp / 2;
		}
		sum = 0;
		for (k = 0; k < numContainers; k++) {
			sum += input[k] * output[k];
		}
		if (sum == 150) {
			numSolutions++;
		}
	}
	
	printf("%d", numSolutions);
	
	return 0;
}