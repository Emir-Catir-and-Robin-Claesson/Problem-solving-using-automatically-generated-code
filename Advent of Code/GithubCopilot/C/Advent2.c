//The elves bought too much eggnog again - 150 liters this time. To fit it all into your refrigerator, you'll need to move it into smaller containers. You take an inventory of the capacities of the available containers. For example, suppose you have containers of size 20, 15, 10, 5, and 5 liters. If you need to store 25 liters, there are four ways to do it:
//15 and 10
//20 and 5 (the first 5)
//20 and 5 (the second 5)
//15, 5, and 5
//Filling all containers entirely, how many different combinations of containers can exactly fit all 150 liters of eggnog?
//
//The input data is given through standard input on the following format: The first row contains the number of available containers Each following line contains the capacity of a container. All capacities are integers and indicate liters. 
//
//The output data should be printed to standard output given in the following format: One line with the answer. 

#include <stdio.h>

int main(int argc, char* argv[])
{
    FILE* fp;
    int num_containers;
    int container[20];
    int i, j, k, l, m, n;
    int count = 0;
    int sum = 0;

	scanf("%d", &num_containers);
	
	for (i = 0; i < num_containers; i++) {
		scanf("%d", &container[i]);
	}

    for (i = 0; i < num_containers; i++) {
        for (j = i+1; j < num_containers; j++) {
            for (k = j+1; k < num_containers; k++) {
                for (l = k+1; l < num_containers; l++) {
                    for (m = l+1; m < num_containers; m++) {
                        for (n = m+1; n < num_containers; n++) {
                            sum = container[i] + container[j] + container[k] + container[l] + container[m] + container[n];
                            if (sum == 150) {
                                count++;
                            }
                        }
                        sum = container[i] + container[j] + container[k] + container[l] + container[m];
                        if (sum == 150) {
                            count++;
                        }
                    }
                    sum = container[i] + container[j] + container[k] + container[l];
                    if (sum == 150) {
                        count++;
                    }
                }
                sum = container[i] + container[j] + container[k];
                if (sum == 150) {
                    count++;
                }
            }
            sum = container[i] + container[j];
            if (sum == 150) {
                count++;
            }
        }
        sum = container[i];
        if (sum == 150) {
            count++;
        }
    }

    printf("%d", count);
    return 0;
}