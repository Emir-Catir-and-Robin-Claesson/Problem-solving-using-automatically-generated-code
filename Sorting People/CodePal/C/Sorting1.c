#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Define a struct to hold the information about a person
typedef struct {
    char name[50];
    int age;
    float weight;
    float height;
    char hometown[50];
} Person;

// Define a function to compare two persons by their height, weight, age, hometown and name
int compare_persons(const void* a, const void* b) {
    Person* pa = (Person*)a;
    Person* pb = (Person*)b;
    int cmp;

    // Compare height
    cmp = (pa->height > pb->height) - (pa->height < pb->height);
    if (cmp != 0) {
        return cmp;
    }

    // Compare weight
    cmp = (pa->weight > pb->weight) - (pa->weight < pb->weight);
    if (cmp != 0) {
        return cmp;
    }

    // Compare age
    cmp = (pa->age > pb->age) - (pa->age < pb->age);
    if (cmp != 0) {
        return cmp;
    }

    // Compare hometown
    cmp = strcmp(pa->hometown, pb->hometown);
    if (cmp != 0) {
        return cmp;
    }

    // Compare name
    return strcmp(pa->name, pb->name);
}

// Define the main function
int main() {
    int n, i;
    Person* people;

    // Read the number of people from standard input
    scanf("%d", &n);

    // Allocate memory for the array of people
    people = (Person*)malloc(n * sizeof(Person));

    // Read the data for each person from standard input
    for (i = 0; i < n; i++) {
        scanf("%s %d %f %f %s", people[i].name, &people[i].age, &people[i].weight, &people[i].height, people[i].hometown);
    }

    // Sort the array of people using the compare_persons function
    qsort(people, n, sizeof(Person), compare_persons);

    // Print the sorted list of people to standard output
    for (i = 0; i < n; i++) {
        printf("%s %d %.1f %.1f %s\n", people[i].name, people[i].age, people[i].weight, people[i].height, people[i].hometown);
    }

    // Free the memory allocated for the array of people
    free(people);

    return 0;
}