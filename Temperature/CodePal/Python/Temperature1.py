def process_temperatures():
    """
    This function processes temperature measurements taken over a number of weeks.
    It takes input data through standard input and outputs the minimum, maximum and average temperature
    for each week and for the entire measurement period.
    """
    try:
        # Get input data from standard input
        weeks, measurements = map(int, input().split())
        temperatures = []
        for i in range(weeks):
            week_temperatures = list(map(float, input().split()))
            if len(week_temperatures) != measurements:
                raise ValueError("Number of measurements per week must be the same")
            temperatures.append(week_temperatures)
        
        # Process the data
        week_results = []
        for week in temperatures:
            min_temp = min(week)
            max_temp = max(week)
            avg_temp = sum(week) / measurements
            week_results.append((min_temp, max_temp, avg_temp))
        
        all_temperatures = [temp for week in temperatures for temp in week]
        min_temp_all = min(all_temperatures)
        max_temp_all = max(all_temperatures)
        avg_temp_all = sum(all_temperatures) / (weeks * measurements)
        
        # Output the results to standard output
        for result in week_results:
            print(f"{result[0]:.1f} {result[1]:.1f} {result[2]:.1f}")
        print(f"{min_temp_all:.1f} {max_temp_all:.1f} {avg_temp_all:.1f}")
    except ValueError as e:
        print(f"Error: {e}")

def main():
    process_temperatures()

if __name__ == "__main__":
    main()