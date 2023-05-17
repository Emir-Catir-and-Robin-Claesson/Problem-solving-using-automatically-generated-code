#include <stdio.h>
//A person is moving out of their house and need to pack all their belongings into boxes. They have an infinite number of boxes available but want to use as few as possible. The person has a list of all their items that need to be packed in boxes. All boxes have the same weight capacity.

//The input will be given to standard input in this order: The first row contains the weight capacity of the boxes. The second row contains the number of items. The following rows contain the weight of each item.

//The output should be printed to standard output in this order: The number of boxes needed to carry all the items.

int main() {
    int capacity, num_items, weight;
    int box_count = 0, current_weight = 0;
    scanf("%d", &capacity);
    scanf("%d", &num_items);
    for(int i = 0; i < num_items; i++) {
        scanf("%d", &weight);
        if (current_weight + weight <= capacity) {
            current_weight += weight;
        } else {
            box_count++;
            current_weight = weight;
        }
    }
    if (current_weight > 0) {
        box_count++;
    }
    printf("%d\n", box_count);
    return 0;
}