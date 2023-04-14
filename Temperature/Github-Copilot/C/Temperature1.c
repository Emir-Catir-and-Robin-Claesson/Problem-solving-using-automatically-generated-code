#include <stdio.h>
// Temperature measurements are taken in one and the same place over a number of weeks. The measurements are taken a fixed number of times, the same number of measurements in each week.  At the end of the measurement period, the collected data must be processed: for each week, the smallest, the largest and the average temperature is determined. The minimum, maximum and average temperature must also be determined for the entire measurement period. All measurements are decimal numbers with 1 point precision.
// The input data is given through standard input on the following format: The first row contains the number of weeks and the number of measurements per week separated by spaces. The following rows contain the measurements for each week, one row per week, measurements separated by spaces.
// The output data should be to standard output given in the following format: One row for each week containing the smallest, largest and average to 1 point precision temperature separated by spaces. One row containing the minimum, maximum and average to 1 point precision temperature for the entire measurement period separated by spaces.
int main(int argc, char const *argv[])
{
    int weeks = 0, days = 0, i = 0, j = 0, k = 0;
    float temp = 0.0, min = 0.0, max = 0.0, avg = 0.0;
    float minWeek = 0.0, maxWeek = 0.0, avgWeek = 0.0;
    float minTotal = 0.0, maxTotal = 0.0, avgTotal = 0.0;
    scanf("%d %d", &weeks, &days);
    float tempWeek[weeks][days];
    for (i = 0; i < weeks; i++)
    {
        minWeek = 0.0;
        maxWeek = 0.0;
        avgWeek = 0.0;
        for (j = 0; j < days; j++)
        {
            scanf("%f", &temp);
            tempWeek[i][j] = temp;
            avgWeek += temp;
            if (j == 0)
            {
                minWeek = temp;
                maxWeek = temp;
            }
            if (temp < minWeek)
            {
                minWeek = temp;
            }
            if (temp > maxWeek)
            {
                maxWeek = temp;
            }
        }
        avgWeek /= days;
        printf("%.1f %.1f %.1f\n", minWeek, maxWeek, avgWeek);
        if (i == 0)
        {
            minTotal = minWeek;
            maxTotal = maxWeek;
            avgTotal = avgWeek;
        }
        if (minWeek < minTotal)
        {
            minTotal = minWeek;
        }
        if (maxWeek > maxTotal)
        {
            maxTotal = maxWeek;
        }
        avgTotal += avgWeek;
    }
    avgTotal /= weeks;
    printf("%.1f %.1f %.1f\n", minTotal, maxTotal, avgTotal);
    return 0;
}
