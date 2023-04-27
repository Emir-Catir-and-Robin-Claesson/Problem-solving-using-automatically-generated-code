import java.util.Arrays;
import java.util.Scanner;

public class Sorting2 {
    // We have a list of people with information about them, including name, age,
    // weight, height and home town. This people must be sorted in ascending order
    // by the order of height, weight, age, home town and lastly name. Numbers are
    // sorted by their value, words are sorted in alphabetical order.
    // The input data is given through standard input on the following format: The
    // first row contains the number of people in the list. The following rows
    // contain the data for each person, one row per person, with their name, age,
    // weight, height and home town, all separated by spaces.
    // The output data should be printed to standard output given in the following
    // format: The list of persons sorted according to the instructions, one row per
    // person, with their name, age, weight, height and home town, all separated by
    // spaces.

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int num = sc.nextInt();
        String[][] arr = new String[num][5];
        for (int i = 0; i < num; i++) {
            for (int j = 0; j < 5; j++) {
                arr[i][j] = sc.next();
            }
        }
        Arrays.sort(arr, (a, b) -> {
            if (Integer.parseInt(a[3]) == Integer.parseInt(b[3])) {
                if (Integer.parseInt(a[4]) == Integer.parseInt(b[4])) {
                    if (Integer.parseInt(a[1]) == Integer.parseInt(b[1])) {
                        if (Integer.parseInt(a[2]) == Integer.parseInt(b[2])) {
                            return a[0].compareTo(b[0]);
                        }
                        return Integer.compare(Integer.parseInt(a[2]), Integer.parseInt(b[2]));
                    }
                    return Integer.compare(Integer.parseInt(a[1]), Integer.parseInt(b[1]));
                }
                return Integer.compare(Integer.parseInt(a[4]), Integer.parseInt(b[4]));
            }
            return Integer.compare(Integer.parseInt(a[3]), Integer.parseInt(b[3]));
        });
        for (int i = 0; i < num; i++) {
            System.out.println(String.join(" ", arr[i]));
        }
    }
}
