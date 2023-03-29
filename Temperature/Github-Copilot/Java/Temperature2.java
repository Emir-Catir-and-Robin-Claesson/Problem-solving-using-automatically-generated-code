import java.util.Scanner;

public class Temperature2 {
    //Temperature measurements are taken in one and the same place over a number of weeks. The measurements are taken a fixed number of times, the same number of measurements in each week.  At the end of the measurement period, the collected data must be processed: for each week, the smallest, the largest and the average temperature is determined. The minimum, maximum and average temperature must also be determined for the entire measurement period. All measurements are decimal numbers with 1 point precision.
    //The input data is given through standard input on the following format: The first row contains the number of weeks and the number of measurements per week separated by spaces. The following rows contain the measurements for each week, one row per week, measurements separated by spaces.
    //The output data should be to standard output given in the following format: One row for each week containing the smallest, largest and average to 1 point precision temperature separated by spaces. One row containing the minimum, maximum and average to 1 point precision temperature for the entire measurement period separated by spaces.


    public static void main(String[] args) {
        
                  //Read input data from stdin
        //The first row contains the number of weeks and the number of measurements per week separated by spaces.
        //The following rows contain the measurements for each week, one row per week, meassurements separated by spaces.

        //Create a scanner object to read from stdin
        Scanner scanner = new Scanner(System.in);
        //Read the number of weeks and the number of measurements per week separated by spaces
        int numberOfWeeks = scanner.nextInt();
        int numberOfMeasurementsPerWeek = scanner.nextInt();
        //Create a two dimensional array to store the temperature values
        double[][] temperatureValues = new double[numberOfWeeks][numberOfMeasurementsPerWeek];
        //Read the measurements for each week, one row per week, meassurements separated by spaces.
        //Store temperature values in the two dimensional array
        for (int i = 0; i < numberOfWeeks; i++) {
            for (int j = 0; j < numberOfMeasurementsPerWeek; j++) {
                temperatureValues[i][j] = scanner.nextDouble();
            }
        }
        //Close the scanner
        scanner.close();

        //Initialize the minimum and maximum temperature values
        double minimumTemperature = temperatureValues[0][0];
        double maximumTemperature = temperatureValues[0][0];

        //Iterate over the two dimensional array to find the minimum and maximum temperature values
        //Iterate over the rows
        for (int i = 0; i < numberOfWeeks; i++) {
            //Iterate over the columns
            for (int j = 0; j < numberOfMeasurementsPerWeek; j++) {
                //Update the minimum temperature value
                if (temperatureValues[i][j] < minimumTemperature) {
                    minimumTemperature = temperatureValues[i][j];
                }
                //Update the maximum temperature value
                if (temperatureValues[i][j] > maximumTemperature) {
                    maximumTemperature = temperatureValues[i][j];
                }
            }
        }

        //Iterate over the two dimensional array to find the smallest, largest and average temperature values for each week
        //Iterate over the rows
        for (int i = 0; i < numberOfWeeks; i++) {
            //Initialize the smallest, largest and average temperature values
            double smallestTemperature = temperatureValues[i][0];
            double largestTemperature = temperatureValues[i][  0];
            double averageTemperature = 0;
            //Iterate over the columns
            for (int j = 0; j < numberOfMeasurementsPerWeek; j++) {
                //Update the smallest temperature value
                if (temperatureValues[i][j] < smallestTemperature) {
                    smallestTemperature = temperatureValues[i][j];
                }
                //Update the largest temperature value
                if (temperatureValues[i][j] > largestTemperature) {
                    largestTemperature = temperatureValues[i][j];
                }
                //Update the average temperature value
                averageTemperature += temperatureValues[i][j];
            }
            //Calculate the average temperature value for the week
            averageTemperature /= numberOfMeasurementsPerWeek;
            //Print the smallest, largest and average temperature values for the week
            System.out.printf("%.1f %.1f %.1f%n", smallestTemperature, largestTemperature, averageTemperature);
        }
        
        
    }
}
