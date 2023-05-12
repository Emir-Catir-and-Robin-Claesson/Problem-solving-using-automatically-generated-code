#include <stdio.h>
//In a classroom, there is a teacher and a set of students. The teacher has a list of all students, as well as the distance between each pair of students. The teacher wants to hand out tests to all students, passing every student, but no more than once, while taking the shortest path. The students are numbered with a unique student ID such that student number one has the unique student ID 1 and so on. The teacher must start at the student with unique ID 1 and must also return to this student after visiting all other students. Come up with the shortest path that traverses every student only once and returns to the starting student. 

//The input will be given to standard input in this order: The first row contains the total number of students. The following rows, one for each pair of students, contain three numbers separated by spaces where the first number is the student ID for a student, the second number is the ID for another student and the third number is the distance between the two students.

//The output should be printed to standard output in this order: The first row should contain the total distance traveled. The second row should be the path that the teacher should take, consisting of the student IDs in the order the teacher should walk, where each student ID is separated by a space.

int main()
{
    int totalStudents;
    scanf("%d", &totalStudents);
    int distance[totalStudents][totalStudents];
    int i, j, k;
    for (i = 0; i < totalStudents; i++)
    {
        for (j = 0; j < totalStudents; j++)
        {
            distance[i][j] = -1;
        }
    }
    int student1, student2, dist;
    for (i = 1; i < totalStudents; i++)
    {
        for (j = i; j < totalStudents; j++)
        {
            scanf("%d %d %d", &student1, &student2, &dist);
            distance[student1][student2] = dist;
            distance[student2][student1] = dist;
        }
    }

    int path[totalStudents];
    int visited[totalStudents];
    for (i = 0; i < totalStudents; i++)
    {
        path[i] = -1;
        visited[i] = 0;
    }
    path[0] = 1;
    visited[0] = 1;
    int curr = 0;
    int next = 0;
    int count = 1;
    int minDist = 0;
    while (count < totalStudents)
    {
        int min = -1;
        for (i = 0; i < totalStudents; i++)
        {
            if (distance[curr][i] != -1 && visited[i] == 0)
            {
                if (min == -1 || distance[curr][i] < min)
                {
                    min = distance[curr][i];
                    next = i;
                }
            }
        }
        minDist += min;
        path[count] = next + 1;
        visited[next] = 1;
        curr = next;
        count++;
    }
    minDist += distance[curr][0];
    printf("%d\n", minDist);
    for (i = 0; i < totalStudents; i++)
    {
        printf("%d ", path[i]);
    }
    printf("\n");
    return 0;
}