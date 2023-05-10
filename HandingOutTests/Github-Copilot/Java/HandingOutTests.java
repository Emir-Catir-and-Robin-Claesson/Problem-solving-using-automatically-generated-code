//In a classroom, there is a teacher and a set of students. The teacher has a list of all students, as well as the distance between each pair of students. The teacher wants to hand out tests to all students, passing every student, but no more than once, while taking the shortest path. The students are numbered with a unique student ID such that student number one has the unique student ID 1 and so on. The teacher must start at the student with unique ID 1 and must also return to this student after visiting all other students. Come up with the shortest path that traverses every student only once and returns to the starting student. 

//The input will be given to standard input in this order: The first row contains the total number of students. The following rows, one for each pair of students, contain three numbers separated by spaces where the first number is the student ID for a student, the second number is the ID for another student and the third number is the distance between the two students.

//The output should be printed to standard output in this order: The first row should contain the total distance traveled. The second row should be the path that the teacher should take, consisting of the student IDs in the order the teacher should walk, where each student ID is separated by a space.
import java.util.Scanner;

public class HandingOutTests
{
    public static void main(String[] args)
    {
        Scanner s = new Scanner(System.in);


        int totalStudents = s.nextInt();

        int[][] students = new int[totalStudents][totalStudents];

        for(int i = 1; i < totalStudents; i++)
        {
            for(int j = i; j < totalStudents; j++)
            {
                int student = s.nextInt();
                int student2 = s.nextInt();
                int dist = s.nextInt();
                students[student-1][student2-1] = dist;
                students[student2-1][student-1] = dist;
            }
        }



        int[] path = new int[totalStudents];
        int[] bestPath = new int[totalStudents];
        int[] visited = new int[totalStudents];
        int[] bestVisited = new int[totalStudents];
        int[] bestDistance = new int[1];
        bestDistance[0] = Integer.MAX_VALUE;
        int[] distance = new int[1];
        distance[0] = 0;
        path[0] = 1;
        visited[0] = 1;

        findPath(students, path, visited, totalStudents, 1, distance, bestPath, bestVisited, bestDistance);

        System.out.println(bestDistance[0]);
        for(int i = 0; i < totalStudents; i++)
        {
            System.out.print(bestPath[i] + " ");
        }



    }

    public static void findPath(int[][] students, int[] path, int[] visited, int totalStudents, int count, int[] distance, int[] bestPath, int[] bestVisited, int[] bestDistance)
    {
        if(count == totalStudents)
        {
            if(distance[0] < bestDistance[0])
            {
                bestDistance[0] = distance[0];
                for(int i = 0; i < totalStudents; i++)
                {
                    bestPath[i] = path[i];
                    bestVisited[i] = visited[i];
                }
            }
            return;
        }

        for(int i = 0; i < totalStudents; i++)
        {
            if(visited[i] == 0 && students[path[count-1]-1][i] != 0)
            {
                path[count] = i+1;
                visited[i] = 1;
                distance[0] += students[path[count-1]-1][i];
                findPath(students, path, visited, totalStudents, count+1, distance, bestPath, bestVisited, bestDistance);
                distance[0] -= students[path[count-1]-1][i];
                visited[i] = 0;
            }
        }
    }



}