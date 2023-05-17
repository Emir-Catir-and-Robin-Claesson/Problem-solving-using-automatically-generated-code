

//A person is moving out of their house and need to pack all their belongings into boxes. They have an infinite number of boxes available but want to use as few as possible. The person has a list of all their items that need to be packed in boxes. All boxes have the same weight capacity.

//The input will be given to standard input in this order: The first row contains the weight capacity of the boxes. The second row contains the number of items. The following rows contain the weight of each item.

//The output should be printed to standard output in this order: The number of boxes needed to carry all the items.

import java.util.Arrays;
import java.util.Scanner;

public class Boxes2
{
    public static void main(String[] args)
    {
        Scanner scanner = new Scanner(System.in);
        int cap = scanner.nextInt();
        int n = scanner.nextInt();
        int[] items = new int[n];
        int[] boxes = new int[n];
        int count = 0;
        int total = 0;
        int max = 0;
        int maxIndex = 0;
        for (int i = 0; i < n; i++)
        {
            items[i] = scanner.nextInt();
        }
        while (count < n)
        {
            for (int i = 0; i < n; i++)
            {
                if (items[i] != 0 && total + items[i] <= cap)
                {
                    total += items[i];
                    items[i] = 0;
                    boxes[count]++;
                }
            }
            count++;
            total = 0;
        }
        for (int i = 0; i < n; i++)
        {
            if (boxes[i] > max)
            {
                max = boxes[i];
                maxIndex = i;
            }
        }
        System.out.println(maxIndex + 1);
        scanner.close();
    }
}