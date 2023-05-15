#include <stdio.h>
#include <stdlib.h>
#include <limits.h>

#define MAX_STUDENTS 1000

int distance[MAX_STUDENTS][MAX_STUDENTS];
int visited[MAX_STUDENTS];
int path[MAX_STUDENTS];
int n_students;

int nearest_neighbor(int current_student) {
    int nearest_student = -1;
    int nearest_distance = INT_MAX;
    for (int i = 0; i < n_students; i++) {
        if (!visited[i] && distance[current_student][i] < nearest_distance) {
            nearest_student = i;
            nearest_distance = distance[current_student][i];
        }
    }
    return nearest_student;
}

void tsp() {
    int current_student = 0;
    visited[current_student] = 1;
    path[0] = current_student;
    int total_distance = 0;
    for (int i = 1; i < n_students; i++) {
        int next_student = nearest_neighbor(current_student);
        visited[next_student] = 1;
        path[i] = next_student;
        total_distance += distance[current_student][next_student];
        current_student = next_student;
    }
    total_distance += distance[current_student][0];
    printf("%d\n", total_distance);
    for (int i = 0; i < n_students; i++) {
        printf("%d ", path[i] + 1);
    }
    printf("1\n");
}

int main() {
    scanf("%d", &n_students);
    for (int i = 0; i < n_students; i++) {
        for (int j = 0; j < n_students; j++) {
            distance[i][j] = INT_MAX;
        }
    }
    int student1, student2, dist;
    for(int i = 1; i < n_students; i++) {
        for(int j = i; j < n_students; j++) {
            scanf("%d %d %d", &student1, &student2, &dist);
            distance[student1 - 1][student2 - 1] = dist;
            distance[student2 - 1][student1 - 1] = dist;
        }
    }
    tsp();
    return 0;
}

