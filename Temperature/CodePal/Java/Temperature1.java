import java.util.Scanner;

public class Temperature1 {
    /**
     * This function takes temperature measurements in one place over a number of
     * weeks and processes the data to determine
     * the smallest, largest, and average temperature for each week and for the
     * entire measurement period.
     * 
     * @param numWeeks               The number of weeks of temperature measurements
     * @param numMeasurementsPerWeek The number of measurements taken each week
     * @param temperatureData        A 2D array containing the temperature
     *                               measurements for each week
     * @return A string containing the smallest, largest, and average temperature
     *         for each week and for the entire measurement period
     */
    public static String processTemperatureData(int numWeeks, int numMeasurementsPerWeek, double[][] temperatureData) {
        // Initialize variables to hold the minimum, maximum, and average temperature
        // for each week and for the entire measurement period
        double[] minTemps = new double[numWeeks];
        double[] maxTemps = new double[numWeeks];
        double[] avgTemps = new double[numWeeks];
        double overallMin = Double.MAX_VALUE;
        double overallMax = Double.MIN_VALUE;
        double overallSum = 0.0;

        // Loop through each week of temperature measurements
        for (int i = 0; i < numWeeks; i++) {
            double minTemp = Double.MAX_VALUE;
            double maxTemp = Double.MIN_VALUE;
            double sum = 0.0;

            // Loop through each measurement in the week and determine the minimum, maximum,
            // and sum of temperatures
            for (int j = 0; j < numMeasurementsPerWeek; j++) {
                double temp = temperatureData[i][j];
                if (temp < minTemp) {
                    minTemp = temp;
                }
                if (temp > maxTemp) {
                    maxTemp = temp;
                }
                sum += temp;
            }

            // Calculate the average temperature for the week
            double avgTemp = sum / numMeasurementsPerWeek;

            // Store the minimum, maximum, and average temperature for the week
            minTemps[i] = minTemp;
            maxTemps[i] = maxTemp;
            avgTemps[i] = avgTemp;

            // Update the overall minimum, maximum, and sum of temperatures
            if (minTemp < overallMin) {
                overallMin = minTemp;
            }
            if (maxTemp > overallMax) {
                overallMax = maxTemp;
            }
            overallSum += sum;
        }

        // Calculate the overall average temperature
        double overallAvg = overallSum / (numWeeks * numMeasurementsPerWeek);

        // Construct the output string
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < numWeeks; i++) {
            sb.append(String.format("%.1f %.1f %.1f\n", minTemps[i], maxTemps[i], avgTemps[i]));
        }
        sb.append(String.format("%.1f %.1f %.1f", overallMin, overallMax, overallAvg));

        return sb.toString();
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int numWeeks = scanner.nextInt();
        int numMeasurements = scanner.nextInt();
        double[][] measurements = new double[numWeeks][numMeasurements];
        for (int i = 0; i < numWeeks; i++) {
            for (int j = 0; j < numMeasurements; j++) {
                measurements[i][j] = scanner.nextDouble();
            }
        }
        scanner.close();

        System.out.println(processTemperatureData(numWeeks, numMeasurements, measurements));
    }
}
