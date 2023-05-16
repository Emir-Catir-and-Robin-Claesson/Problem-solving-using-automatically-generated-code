#include <stdio.h>
#include <stdlib.h>

#define MAX_CONTAINERS 20

// Recursive function to count the number of ways to fit the eggnog
int count_ways(int eggnog, int containers[], int n) {
    // Base case: if eggnog is 0, we found a valid combination
    if (eggnog == 0) {
        return 1;
    }
    // Base case: if eggnog is negative or we ran out of containers, this is not a valid combination
    if (eggnog < 0 || n == 0) {
        return 0;
    }
    // Recursive case: we can either use the last container or not
    return count_ways(eggnog - containers[n-1], containers, n-1) +
           count_ways(eggnog, containers, n-1);
}

int main() {
    int n, eggnog, containers[MAX_CONTAINERS];
    // Read input
    scanf("%d", &n);
    for (int i = 0; i < n; i++) {
        scanf("%d", &containers[i]);
    }
    // Call the recursive function to count th e number of ways
    int ways = count_ways(150, containers, n);
    // Print the result
    printf("%d\n", ways);
    return 0;
}