//The elves bought too much eggnog again - 150 liters this time. To fit it all into your refrigerator, you'll need to move it into smaller containers. You take an inventory of the capacities of the available containers. For example, suppose you have containers of size 20, 15, 10, 5, and 5 liters. If you need to store 25 liters, there are four ways to do it:
//15 and 10
//20 and 5 (the first 5)
//20 and 5 (the second 5)
//15, 5, and 5
//Filling all containers entirely, how many different combinations of containers can exactly fit all 150 liters of eggnog?

//The input data is given through standard input on the following format: The first row contains the number of available containers Each following line contains the capacity of a container. All capacities are integers and indicate liters. 

//The output data should be printed to standard output given in the following format: One line with the answer.

import java.util.Scanner;

public class Advent2
{
    
    public static void main(String[] args)
    {
        Scanner sc = new Scanner(System.in);
        int numContainers = sc.nextInt();
        int[] containers = new int[numContainers];
        for (int i = 0; i < numContainers; i++)
        {
            containers[i] = sc.nextInt();
        }
        int[] used = new int[numContainers];
        int total = 0;
        int numCombinations = 0;
        numCombinations = findCombinations(containers, used, total, numCombinations, 0);
        System.out.println(numCombinations);
    }

    public static int findCombinations(int[] containers, int[] used, int total, int numCombinations, int index)
    {
        if (total == 150)
        {
            numCombinations++;
        }
        else if (total < 150)
        {
            for (int i = index; i < containers.length; i++)
            {
                if (used[i] == 0)
                {
                    used[i] = 1;
                    numCombinations = findCombinations(containers, used, total + containers[i], numCombinations, i);
                    used[i] = 0;
                }
            }
        }
        return numCombinations;
    }
}