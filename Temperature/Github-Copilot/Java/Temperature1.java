import java.util.Scanner;

public class Temperature1 {
    //Temperature measurements are taken in one and the same place over a number of weeks. The measurements are taken a fixed number of times, the same number of measurements in each week.  At the end of the measurement period, the collected data must be processed: for each week, the smallest, the largest and the average temperature is determined. The minimum, maximum and average temperature must also be determined for the entire measurement period. All meassurements are decimal numbers with 1 point precision.
    //The input data is given through standard input on the following format: The first row contains the number of weeks and the number of measurements per week separated by spaces. The following rows contain the measurements for each week, one row per week, meassurements separated by spaces.
    //The output data should be to standard output given in the following format: One row for each week containing the smallest, largest and average to 1 point precision temperature separated by spaces. One row containing the minimum, maximum and averageto 1 point precision temperature for the entire measurement period separated by spaces.

    public static void main(String[] args) {
                // Input
                Scanner in = new Scanner(System.in);
                int weeks = in.nextInt();
                int measurements = in.nextInt();
                double[][] data = new double[weeks][measurements];
                for (int i = 0; i < weeks; i++) {
                    for (int j = 0; j < measurements; j++) {
                        data[i][j] = in.nextDouble();
                    }
                }
        
                // Process
                double min = data[0][0];
                double max = data[0][0];
                double sum = 0;
                double sumWeek = 0;
                double[] minWeek = new double[weeks];
                double[] maxWeek = new double[weeks];
                double[] avgWeek = new double[weeks];
                double avg = 0;
                for (int i = 0; i < weeks; i++) {
                    minWeek[i] = data[i][0];
                    maxWeek[i] = data[i][0];
                    sumWeek = 0;
                    for (int j = 0; j < measurements; j++) {
                        if (data[i][j] < minWeek[i]) {
                            minWeek[i] = data[i][j];
                        }
                        if (data[i][j] > maxWeek[i]) {
                            maxWeek[i] = data[i][j];
                        }
                        sumWeek += data[i][j];
                    }
                    avgWeek[i] = sumWeek / measurements;
                    if (minWeek[i] < min) {
                        min = minWeek[i];
                    }
                    if (maxWeek[i] > max) {
                        max = maxWeek[i];
                    }
                    sum += sumWeek;
                }
                avg = sum / (weeks * measurements);
        
                // Output
                for (int i = 0; i < weeks; i++) {
                    System.out.printf("%.1f %.1f %.1f%n", minWeek[i], maxWeek[i], avgWeek[i]);
                }
                System.out.printf("%.1f %.1f %.1f%n", min, max, avg);

    }
}
