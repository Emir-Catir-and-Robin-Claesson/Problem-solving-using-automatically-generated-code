#include <stdio.h>
//A person is moving out of their house and need to pack all their belongings into boxes. They have an infinite number of boxes available but want to use as few as possible. The person has a list of all their items that need to be packed in boxes. All boxes have the same weight capacity.

//The input will be given to standard input in this order: The first row contains the weight capacity of the boxes. The second row contains the number of items. The following rows contain the weight of each item.

//The output should be printed to standard output in this order: The number of boxes needed to carry all the items.

int main()
{
    int weightCapacity;
    int numberOfItems;
    scanf("%d", &weightCapacity);
    scanf("%d", &numberOfItems);
    int sum = 0;
    int boxes = 1;
    int item;
    for (int i = 0; i < numberOfItems; i++)
    {
        scanf("%d", &item);
        sum += item;
        if (sum > weightCapacity)
        {
            sum = item;
            boxes++;
        }
    }
    printf("%d", boxes);
    return 0;
}