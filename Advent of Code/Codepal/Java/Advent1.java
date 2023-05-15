import java.util.*;

public class Advent1 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int numContainers = scanner.nextInt();
        int[] capacities = new int[numContainers];
        for (int i = 0; i < numContainers; i++) {
            capacities[i] = scanner.nextInt();
        }
        int totalCapacity = 150;
        int[] dp = new int[totalCapacity + 1];
        dp[0] = 1;
        for (int i = 0; i < numContainers; i++) {
            for (int j = capacities[i]; j <= totalCapacity; j++) {
                dp[j] += dp[j - capacities[i]];
            }
        }
        System.out.println(dp[totalCapacity]);
        scanner.close();
    }
}