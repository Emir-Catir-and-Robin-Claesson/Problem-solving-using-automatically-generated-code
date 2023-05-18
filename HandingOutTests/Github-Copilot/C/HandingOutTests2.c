#include <stdio.h>
//In a classroom, there is a teacher and a set of students. The teacher has a list of all students, as well as the distance between each pair of students. The teacher wants to hand out tests to all students, passing every student, but no more than once, while taking the shortest path. The students are numbered with a unique student ID such that student number one has the unique student ID 1 and so on. The teacher must start at the student with unique ID 1 and must also return to this student after visiting all other students. Come up with the shortest path that traverses every student only once and returns to the starting student.

//The input will be given to standard input in this order: The first row contains the total number of students. The following rows, one for each pair of students, contain three numbers separated by spaces where the first number is the student ID for a student, the second number is the ID for another student and the third number is the distance between the two students.

//The output should be printed to standard output in this order: The first row should contain the total distance traveled. The second row should be the path that the teacher should take, consisting of the student IDs in the order the teacher should walk, where each student ID is separated by a space.

int main()
{
    int numStudents;
    scanf("%d", &numStudents);
    int distances[numStudents][numStudents];
    int students[numStudents];
    int visited[numStudents];
    int i, j;
    int start = 0;
    int totalDistance = 0;
    for (i = 0; i < numStudents; i++)
    {
        for (j = 0; j < numStudents; j++)
        {
            distances[i][j] = 0;
        }
        visited[i] = 0;
        students[i] = 0;
    }
    for (i = 0; i < numStudents * (numStudents - 1) / 2; i++)
    {
        int a, b, c;
        scanf("%d %d %d", &a, &b, &c);
        distances[a - 1][b - 1] = c;
        distances[b - 1][a - 1] = c;
    }
    for (i = 0; i < numStudents; i++)
    {
        for (j = 0; j < numStudents; j++)
        {
            if (distances[i][j] != 0)
            {
                totalDistance += distances[i][j];
            }
        }
    }
    int student = 0;
    int count = 0;
    while (count < numStudents)
    {
        students[count] = student + 1;
        visited[student] = 1;
        int min = 1000000;
        for (i = 0; i < numStudents; i++)
        {
            if (i != student && visited[i] == 0 && distances[student][i] < min)
            {
                min = distances[student][i];
                student = i;
            }
        }
        count++;
    }
    printf("%d\n", totalDistance);
    students[count] = 1;
    for (i = 0; i < numStudents + 1; i++)
    {
        printf("%d ", students[i]);
    }
    printf("\n");
    return 0;
}