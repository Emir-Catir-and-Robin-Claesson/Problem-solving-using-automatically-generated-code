#include <stdio.h>

// Temperature measurements are taken in one and the same place over a number of weeks. The measurements are taken a fixed number of times, the same number of measurements in each week.  At the end of the measurement period, the collected data must be processed: for each week, the smallest, the largest and the average temperature is determined. The minimum, maximum and average temperature must also be determined for the entire measurement period. All measurements are decimal numbers with 1 point precision.
// The input data is given through standard input on the following format: The first row contains the number of weeks and the number of measurements per week separated by spaces. The following rows contain the measurements for each week, one row per week, measurements separated by spaces.
// The output data should be to standard output given in the following format: One row for each week containing the smallest, largest and average to 1 point precision temperature separated by spaces. One row containing the minimum, maximum and average to 1 point precision temperature for the entire measurement period separated by spaces.

int main(int argc, char const *argv[])
{
    int n, m;
    scanf("%d%d", &n, &m);
    int i, j;
    float min, max, avg, minWeek, maxWeek, avgWeek, minTotal, maxTotal, avgTotal;
    float temp;
    // week
    for (i = 0; i < n; i++)
    {
        min = 1000;
        max = -1000;
        avg = 0;
        // day
        for (j = 0; j < m; j++)
        {
            scanf("%f", &temp);
            if (temp < min)
            {
                min = temp;
            }
            if (temp > max)
            {
                max = temp;
            }
            avg += temp;
        }
        avg /= m;
        if (i == 0)
        {
            minWeek = min;
            maxWeek = max;
            avgWeek = avg;
            minTotal = min;
            maxTotal = max;
            avgTotal = avg;
        }
        else
        {
            if (min < minWeek)
            {
                minWeek = min;
            }
            if (max > maxWeek)
            {
                maxWeek = max;
            }
            avgWeek += avg;
            if (min < minTotal)
            {
                minTotal = min;
            }
            if (max > maxTotal)
            {
                maxTotal = max;
            }
            avgTotal += avg;
        }
        printf("%.1f %.1f %.1f\n", min, max, avg);
    }
    avgWeek /= n;
    avgTotal /= n * n;
    printf("%.1f %.1f %.1f\n", minTotal, maxTotal, avgTotal);
    return 0;
}
