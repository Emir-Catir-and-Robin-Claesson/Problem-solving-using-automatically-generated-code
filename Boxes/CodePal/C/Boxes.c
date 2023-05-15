#include <stdio.h>
#include <stdlib.h>

int num_boxes_needed(int box_capacity, int num_items, int* item_weights) {
    int total_weight = 0;
    int num_boxes = 1;
    
    for (int i = 0; i < num_items; i++) {
        if (item_weights[i] > box_capacity) {
            // If an item is too heavy for a box, return -1 to indicate an error
            return -1;
        }
        
        if (total_weight + item_weights[i] > box_capacity) {
            // If the current box is full, start a new box
            num_boxes++;
            total_weight = item_weights[i];
        } else {
            // Add the item to the current box
            total_weight += item_weights[i];
        }
    }
    
    return num_boxes;
}

int main() {
    int box_capacity, num_items;
    scanf("%d %d", &box_capacity, &num_items);
    
    int* item_weights = (int*) malloc(num_items * sizeof(int));
    for (int i = 0; i < num_items; i++) {
        scanf("%d", &item_weights[i]);
    }
    
    int num_boxes = num_boxes_needed(box_capacity, num_items, item_weights);
    if (num_boxes == -1) {
        printf("Error: an item is too heavy for a box\n");
    } else {
        printf("%d\n", num_boxes);
    }
    
    free(item_weights);
    return 0;
}