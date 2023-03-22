# Temperature measurements are taken in one and the same place over a number of weeks. The measurements are taken a fixed number of times, the same number of measurements in each week.  At the end of the measurement period, the collected data must be processed: for each week, the smallest, the largest and the average temperature is determined. The minimum, maximum and average temperature must also be determined for the entire measurement period
# The input data is given in the following format: The first row contains the number of weeks and the number of measurements per week separated by spaces. The following rows contain the measurements for each week, one row per week, meassurements separated by spaces.
# The output data should be given in the following format: One row for each week containing the smallest, largest and average temperature separated by spaces. One row containing the minimum, maximum and average temperature for the entire measurement period separated by spaces.
def main():
    # Read the input data
    num_weeks, num_measurements = map(int, input().split())
    measurements = []
    for _ in range(num_weeks):
        measurements.append(list(map(int, input().split())))

    # Process the data
    min_temp = max_temp = sum_temp = measurements[0][0]
    min_temps = []
    max_temps = []
    sum_temps = []
    for week in measurements:
        min_temp = min(week)
        max_temp = max(week)
        sum_temp = sum(week)
        min_temps.append(min_temp)
        max_temps.append(max_temp)
        sum_temps.append(sum_temp)
        print(min_temp, max_temp, sum_temp / num_measurements)

    print(min(min_temps), max(max_temps), sum(sum_temps) / (num_weeks * num_measurements))

if __name__ == "__main__":
    main()