//We have a list of people with information about them, including name, age, weight, height and home town. These people must be sorted in ascending order by the order of height, weight, age, home town and lastly name. Numbers are sorted by their value, words are sorted in alphabetical order. 
//
//The input data is given through standard input on the following format: The first row contains the number of people in the list. The following rows contain the data for each person, one row per person, with their name, age, weight, height and home town, all separated by spaces. 
//
//The output data should be printed to standard output given in the following format: The list of persons sorted according to the instructions, one row per person, with their name, age, weight, height and home town, all separated by spaces.

#include <stdio.h>
#include <string.h>

int main() {
    int i, j, k, n, temp, count = 0, min;
    char names[300][300], tempname[300];
    int ages[300], weights[300], heights[300];
    char towns[300][300], temptown[300];
    scanf("%d", &n);
    for(i = 0; i < n; i++) {
        scanf("%s %d %d %d %s", names[i], &ages[i], &weights[i], &heights[i], towns[i]);
    }
    for(i = 0; i < n; i++) {
        min = i;
        for(j = i + 1; j < n; j++) {
            if(heights[j] < heights[min]) {
                min = j;
            }
            else if(heights[j] == heights[min]) {
                if(weights[j] < weights[min]) {
                    min = j;
                }
                else if(weights[j] == weights[min]) {
                    if(ages[j] < ages[min]) {
                        min = j;
                    }
                    else if(ages[j] == ages[min]) {
                        if(strcmp(towns[j], towns[min]) < 0) {
                            min = j;
                        }
                        else if(strcmp(towns[j], towns[min]) == 0) {
                            if(strcmp(names[j], names[min]) < 0) {
                                min = j;
                            }
                        }
                    }
                }
            }
        }
        if(min != i) {
            temp = ages[i];
            ages[i] = ages[min];
            ages[min] = temp;
            temp = weights[i];
            weights[i] = weights[min];
            weights[min] = temp;
            temp = heights[i];
            heights[i] = heights[min];
            heights[min] = temp;
            strcpy(tempname, names[i]);
            strcpy(names[i], names[min]);
            strcpy(names[min], tempname);
            strcpy(temptown, towns[i]);
            strcpy(towns[i], towns[min]);
            strcpy(towns[min], temptown);
        }
    }
    for(i = 0; i < n; i++) {
        printf("%s %d %d %d %s\n", names[i], ages[i], weights[i], heights[i], towns[i]);
    }
    return 0;
}