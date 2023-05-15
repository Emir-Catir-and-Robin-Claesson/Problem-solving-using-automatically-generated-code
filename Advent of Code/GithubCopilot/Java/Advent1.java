//The elves bought too much eggnog again - 150 liters this time. To fit it all into your refrigerator, you'll need to move it into smaller containers. You take an inventory of the capacities of the available containers. For example, suppose you have containers of size 20, 15, 10, 5, and 5 liters. If you need to store 25 liters, there are four ways to do it:
//15 and 10
//20 and 5 (the first 5)
//20 and 5 (the second 5)
//15, 5, and 5
//Filling all containers entirely, how many different combinations of containers can exactly fit all 150 liters of eggnog?

//The input data is given through standard input on the following format: The first row contains the number of available containers Each following line contains the capacity of a container. All capacities are integers and indicate liters. 

//The output data should be printed to standard output given in the following format: One line with the answer. 

import java.util.Scanner;

public class Advent1 
{
    public static void main(String[] args)
    {
        int[] containers = new int[20];
        int[] combinations = new int[20];
        int numberOfContainers = 0;
        int numberOfCombinations = 0;
        int litersOfEggnog = 0;
        
        // Read input
        Scanner input = new Scanner(System.in);
        numberOfContainers = input.nextInt();
        for (int i = 0; i < numberOfContainers; i++)
        {
            containers[i] = input.nextInt();
        }
        litersOfEggnog = 150;
        
        // Calculate the number of combinations
        for (int i = 0; i < numberOfContainers; i++)
        {
            for (int j = 0; j < numberOfContainers; j++)
            {
                if (containers[i] + containers[j] == litersOfEggnog)
                {
                    numberOfCombinations++;
                }
            }
        }
        
        // Print the output
        System.out.println(numberOfCombinations);
    }
}