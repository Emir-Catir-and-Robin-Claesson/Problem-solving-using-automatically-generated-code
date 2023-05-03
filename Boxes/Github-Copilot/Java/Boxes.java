//A person is moving out of their house and need to pack all their belongings into boxes. They have an infinite number of boxes available but want to use as few as possible. The person has a list of all their items that need to be packed in boxes. All boxes have the same weight capacity.

//The input will be given to standard input in this order: The first row contains the weight capacity of the boxes. The second row contains the number of items. The following rows contain the weight of each item.

//The output should be printed to standard output in this order: The number of boxes needed to carry all the items.

import java.util.Arrays;
import java.util.Scanner;

public class boxes_java{

    public static void main(String[] args)
    {
        Scanner scanner = new Scanner(System.in);
        int weightCapacity = scanner.nextInt();
        int numberOfItems = scanner.nextInt();
        int[] items = new int[numberOfItems];
        for (int i = 0; i < numberOfItems; i++)
            items[i] = scanner.nextInt();
        Arrays.sort(items);
        int boxes = 0;
        int currentWeight = 0;
        for (int i = 0; i < numberOfItems; i++)
        {
            if (currentWeight + items[i] > weightCapacity)
            {
                boxes++;
                currentWeight = 0;
            }
            currentWeight += items[i];
        }
        if (currentWeight > 0)
            boxes++;
        System.out.println(boxes);
    }
}