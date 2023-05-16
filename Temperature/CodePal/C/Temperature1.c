#include <stdio.h>

/*
This function takes temperature measurements in one and the same place over a number of weeks. The measurements are taken a fixed number of times, the same number of measurements in each week. At the end of the measurement period, the collected data must be processed: for each week, the smallest, the largest and the average temperature is determined. The minimum, maximum and average temperature must also be determined for the entire measurement period. All measurements are decimal numbers with 1 point precision.

Parameters:
num_weeks (int): The number of weeks of temperature measurements
num_measurements (int): The number of measurements per week
measurements (float[][]): A 2D array of temperature measurements, with each row representing a week and each column representing a measurement for that week

Returns:
void: The function prints the smallest, largest, and average temperature for each week, as well as the minimum, maximum, and average temperature for the entire measurement period to standard output
*/
void process_temperatures(int num_weeks, int num_measurements, float measurements[num_weeks][num_measurements])
{
    float min_temp = measurements[0][0];
    float max_temp = measurements[0][0];
    float total_temp = 0.0;
    int total_measurements = 0;

    // Loop through each week
    for (int i = 0; i < num_weeks; i++)
    {
        float week_min_temp = measurements[i][0];
        float week_max_temp = measurements[i][0];
        float week_total_temp = 0.0;

        // Loop through each measurement in the week
        for (int j = 0; j < num_measurements; j++)
        {
            float temp = measurements[i][j];

            // Update the minimum temperature for the week
            if (temp < week_min_temp)
            {
                week_min_temp = temp;
            }

            // Update the maximum temperature for the week
            if (temp > week_max_temp)
            {
                week_max_temp = temp;
            }

            // Add the temperature to the total for the week and the entire measurement period
            week_total_temp += temp;
            total_temp += temp;
            total_measurements++;
        }

        // Calculate the average temperature for the week
        float week_avg_temp = week_total_temp / num_measurements;

        // Print the smallest, largest, and average temperature for the week
        printf("%.1f %.1f %.1f\n", week_min_temp, week_max_temp, week_avg_temp);

        // Update the minimum and maximum temperature for the entire measurement period
        if (week_min_temp < min_temp)
        {
            min_temp = week_min_temp;
        }
        if (week_max_temp > max_temp)
        {
            max_temp = week_max_temp;
        }
    }

    // Calculate the average temperature for the entire measurement period
    float avg_temp = total_temp / total_measurements;

    // Print the minimum, maximum, and average temperature for the entire measurement period
    printf("%.1f %.1f %.1f\n", min_temp, max_temp, avg_temp);
}

int main(int argc, char const *argv[])
{
    // Initialize the number of weeks and measurements
    int num_weeks, num_measurements;
    scanf("%d %d", &num_weeks, &num_measurements);

    // Allocate memory for the measurements
    int **measurements = (int **)malloc(num_weeks * sizeof(int *));
    for (int i = 0; i < num_weeks; i++) {
        measurements[i] = (int *)malloc(num_measurements * sizeof(int));
    }

    // Read the measurements
    for (int i = 0; i < num_weeks; i++) {
        for (int j = 0; j < num_measurements; j++) {
            scanf("%d", &measurements[i][j]);
        }
    }

    process_temperatures(num_weeks, num_measurements, measurements);
    return 0;
}