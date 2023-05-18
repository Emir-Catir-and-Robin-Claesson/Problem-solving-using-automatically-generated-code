#Temperature measurements are taken in one and the same place over a number of weeks. The measurements are taken a fixed number of times, the same number of measurements in each week.  At the end of the measurement period, the collected data must be processed: for each week, the smallest, the largest and the average temperature is determined. The minimum, maximum and average temperature must also be determined for the entire measurement period. All measurements are decimal numbers with 1 point precision.
    
#The input data is given through standard input on the following format: The first row contains the number of weeks and the number of measurements per week separated by spaces. The following rows contain the measurements for each week, one row per week, measurements separated by spaces.

#The output data should be to standard output given in the following format: One row for each week containing the smallest, largest and average to 1 point precision temperature separated by spaces. One row containing the minimum, maximum and average to 1 point precision temperature for the entire measurement period separated by spaces.

def main():
    weeks, measurements = input().split()
    weeks = int(weeks)
    measurements = int(measurements)
    minTemp = 100
    maxTemp = -100
    sumTemp = 0
    for i in range(weeks):
        temp = input().split()
        temp = [float(i) for i in temp]
        minTempWeek = min(temp)
        maxTempWeek = max(temp)
        sumTempWeek = sum(temp)
        if minTempWeek < minTemp:
            minTemp = minTempWeek
        if maxTempWeek > maxTemp:
            maxTemp = maxTempWeek
        sumTemp += sumTempWeek
        print("{:.1f} {:.1f} {:.1f}".format(minTempWeek, maxTempWeek, sumTempWeek/measurements))
    print("{:.1f} {:.1f} {:.1f}".format(minTemp, maxTemp, sumTemp/(weeks*measurements)))

if __name__ == "__main__":
    main()