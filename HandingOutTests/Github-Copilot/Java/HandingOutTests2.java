//In a classroom, there is a teacher and a set of students. The teacher has a list of all students, as well as the distance between each pair of students. The teacher wants to hand out tests to all students, passing every student, but no more than once, while taking the shortest path. The students are numbered with a unique student ID such that student number one has the unique student ID 1 and so on. The teacher must start at the student with unique ID 1 and must also return to this student after visiting all other students. Come up with the shortest path that traverses every student only once and returns to the starting student.
//The input will be given to standard input in this order: The first row contains the total number of students. The following rows, one for each pair of students, contain three numbers separated by spaces where the first number is the student ID for a student, the second number is the ID for another student and the third number is the distance between the two students.
//The output should be printed to standard output in this order: The first row should contain the total distance traveled. The second row should be the path that the teacher should take, consisting of the student IDs in the order the teacher should walk, where each student ID is separated by a space.

import java.util.Scanner;

public class HandingOutTests2
{
    public static void main(String[] args)
    {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        int[][] dist = new int[n][n];
        for (int i = 0; i < n*(n-1)/2; i++)
        {
            int a = sc.nextInt();
            int b = sc.nextInt();
            int d = sc.nextInt();
            dist[a][b] = d;
            dist[b][a] = d;
        }
        int[] path = new int[n];
        path[0] = 0;
        int[] best = new int[n];
        int[] bestPath = new int[n];
        int bestDist = Integer.MAX_VALUE;
        for (int i = 1; i < n; i++)
            path[i] = i;
        while (true)
        {
            int d = 0;
            for (int i = 1; i < n; i++)
                d += dist[path[i-1]][path[i]];
            d += dist[path[n-1]][path[0]];
            if (d < bestDist)
            {
                bestDist = d;
                for (int i = 0; i < n; i++)
                {
                    best[i] = path[i];
                    bestPath[i] = path[i];
                }
            }
            int i = n-2;
            while (i >= 0 && path[i] > path[i+1])
                i--;
            if (i < 0)
                break;
            int j = n-1;
            while (path[i] > path[j])
                j--;
            int temp = path[i];
            path[i] = path[j];
            path[j] = temp;
            i++;
            j = n-1;
            while (i < j)
            {
                temp = path[i];
                path[i] = path[j];
                path[j] = temp;
                i++;
                j--;
            }
        }
        System.out.println(bestDist);
        for (int i = 0; i < n; i++)
            System.out.print(bestPath[i]+" ");
        System.out.println();
        sc.close();
    }
}