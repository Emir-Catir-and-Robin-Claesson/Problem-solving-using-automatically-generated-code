//In a concert hall, the musicians sit in designated places, and each music stand has its own lamp with a lamp cord that just barely reaches the floor. In order for all music stand lamps to be powered, an electrician needs to build a network of branch sockets and cords, where the number of sockets and the length of the cords are adjusted by the electrician according to need. There needs to be an electrical outlet under each music stand, and branch sockets are only allowed to be placed under the music stands. There is only one wall outlet in the concert hall, and it sits 150 centimeters from the nearest music stand. The problem is to design a network of cords with power outlets that use as little cord (power cable) as possible and no unused power outlets. 
//
//The input data is given through standard input on the following format. The first row contains N, the number of music stands. The following rows are each a row of the NxN matrix, with the numbers separated by spaces, and place (i, j) indicates how long a cord would be required to be to reach from stand i to stand j. The Nth music stand is the one closest to the wall outlet. The length of the cords are positive integers, representing the length in centimeters. 
//
//The output data should be printed to standard output in the following format. A row for each of the branch sockets used to build the network that powers the lamps. Each row should print the length of the cord, the number of sockets it has, the number of the music stand where the cord is plugged in, and the number of the music stand it lies beneath, all separated by spaces. The wall outlet is considered as music stand 0.

import java.util.Scanner;

public class Electrical1
{
    public static void main(String[] args)
    {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        int[][] matrix = new int[n][n];
        int[] cords = new int[n];
        for (int i=0; i<n; i++)
        {
            for (int j=0; j<n; j++)
                matrix[i][j] = sc.nextInt();
        }
        int total = 0;
        for (int i=0; i<n; i++)
        {
            int min = 1000;
            int minIndex = 0;
            for (int j=0; j<n; j++)
            {
                if (matrix[i][j] < min)
                {
                    min = matrix[i][j];
                    minIndex = j;
                }
            }
            total += min;
            cords[i] = minIndex;
        }
        System.out.println(total);
        for (int i=0; i<n; i++)
        {
            int count = 0;
            for (int j=0; j<n; j++)
            {
                if (cords[j] == i)
                    count++;
            }
            if (count != 0)
                System.out.println(matrix[i][cords[i]] + " " + count + " " + cords[i] + " " + i);
        }
    }
}