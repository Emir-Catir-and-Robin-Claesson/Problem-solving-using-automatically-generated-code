import java.util.Scanner;

public class BoxPacker {
    
    /**
     * This function takes in the weight capacity of boxes and a list of item weights, and returns the minimum
     * number of boxes required to pack all the items.
     * 
     * @param capacity The weight capacity of each box
     * @param items An array of integers representing the weight of each item
     * @return The minimum number of boxes required to pack all the items
     */
    public static int packBoxes(int capacity, int[] items) {
        int numBoxes = 0;
        int currentBoxWeight = 0;
        
        for (int i = 0; i < items.length; i++) {
            if (currentBoxWeight + items[i] > capacity) {
                // If the current box is full, start a new box
                numBoxes++;
                currentBoxWeight = 0;
            }
            currentBoxWeight += items[i];
        }
        
        // If there are any remaining items, add another box
        if (currentBoxWeight > 0) {
            numBoxes++;
        }
        
        return numBoxes;
    }
    
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        
        // Read in the weight capacity of the boxes
        int capacity = scanner.nextInt();
        
        // Read in the number of items
        int numItems = scanner.nextInt();
        
        // Read in the weights of each item
        int[] items = new int[numItems];
        for (int i = 0; i < numItems; i++) {
            items[i] = scanner.nextInt();
        }
        
        // Calculate the minimum number of boxes required
        int numBoxes = packBoxes(capacity, items);
        
        // Print the result
        System.out.println(numBoxes);
    }
}