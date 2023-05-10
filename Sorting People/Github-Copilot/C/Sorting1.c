#include <stdio.h>
#include <string.h>
#include <stdlib.h>
// We have a list of people with information about them, including name, age, weight, height and home town. This people must be sorted in ascending order by the order of height, weight, age, home town and lastly name. Numbers are sorted by their value, words are sorted in alphabetical order.
// The input data is given through standard input on the following format: The first row contains the number of people in the list. The following rows contain the data for each person, one row per person, with their name, age, weight, height and home town, all separated by spaces.
// The output data should be printed to standard output given in the following format: The list of persons sorted according to the instructions, one row per person, with their name, age, weight, height and home town, all separated by spaces.

int main(int argc, char const *argv[])
{
    int n;
    scanf("%d", &n);
    char name[n][50], town[n][50];
    int age[n], weight[n], height[n];
    for (int i = 0; i < n; ++i)
    {
        scanf("%s %d %d %d %s", &name[i], &age[i], &weight[i], &height[i], &town[i]);
    }
    // sorting
    for (int i = 0; i < n; ++i)
    {
        for (int j = 1; j < n - i; ++j)
        {
            if (height[j - 1] > height[j])
            {
                int temp = height[j - 1];
                height[j - 1] = height[j];
                height[j] = temp;
                temp = weight[j - 1];
                weight[j - 1] = weight[j];
                weight[j] = temp;
                temp = age[j - 1];
                age[j - 1] = age[j];
                age[j] = temp;
                char temp1[50];
                strcpy(temp1, name[j - 1]);
                strcpy(name[j - 1], name[j]);
                strcpy(name[j], temp1);
                strcpy(temp1, town[j - 1]);
                strcpy(town[j - 1], town[j]);
                strcpy(town[j], temp1);
            }
            else if (height[j - 1] == height[j])
            {
                if (weight[j - 1] > weight[j])
                {
                    int temp = weight[j - 1];
                    weight[j - 1] = weight[j];
                    weight[j] = temp;
                    temp = age[j - 1];
                    age[j - 1] = age[j];
                    age[j] = temp;
                    char temp1[50];
                    strcpy(temp1, name[j - 1]);
                    strcpy(name[j - 1], name[j]);
                    strcpy(name[j], temp1);
                    strcpy(temp1, town[j - 1]);
                    strcpy(town[j - 1], town[j]);
                    strcpy(town[j], temp1);
                }
                else if (weight[j - 1] == weight[j])
                {
                    if (age[j - 1] > age[j])
                    {
                        int temp = age[j - 1];
                        age[j - 1] = age[j];
                        age[j] = temp;
                        char temp1[50];
                        strcpy(temp1, name[j - 1]);
                        strcpy(name[j - 1], name[j]);
                        strcpy(name[j], temp1);
                        strcpy(temp1, town[j - 1]);
                        strcpy(town[j - 1], town[j]);
                        strcpy(town[j], temp1);
                    }
                    else if (age[j - 1] == age[j])
                    {
                        if (strcmp(town[j - 1], town[j]) > 0)
                        {
                            char temp1[50];
                            strcpy(temp1, name[j - 1]);
                            strcpy(name[j - 1], name[j]);
                            strcpy(name[j], temp1);
                            strcpy(temp1, town[j - 1]);
                            strcpy(town[j - 1], town[j]);
                            strcpy(town[j], temp1);
                        }
                        else if (strcmp(town[j - 1], town[j]) == 0)
                        {
                            if (strcmp(name[j - 1], name[j]) > 0)
                            {
                                char temp1[50];
                                strcpy(temp1, name[j - 1]);
                                strcpy(name[j - 1], name[j]);
                                strcpy(name[j], temp1);
                            }
                        }
                    }
                }
            }
        }
    }

    for (int i = 0; i < n; ++i)
    {
        printf("%s %d %d %d %s\n", name[i], age[i], weight[i], height[i], town[i]);
    }
    return 0;
}
