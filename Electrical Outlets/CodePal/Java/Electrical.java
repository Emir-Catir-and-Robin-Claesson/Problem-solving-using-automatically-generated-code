import java.util.*;

public class Electrical {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        int[][] cords = new int[n][n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                cords[i][j] = sc.nextInt();
            }
        }
        sc.close();
        int[] distances = new int[n];
        boolean[] used = new boolean[n];
        Arrays.fill(distances, Integer.MAX_VALUE);
        distances[0] = 0;
        int[] parent = new int[n];
        Arrays.fill(parent, -1);
        for (int i = 0; i < n - 1; i++) {
            int u = -1;
            for (int j = 0; j < n; j++) {
                if (!used[j] && (u == -1 || distances[j] < distances[u])) {
                    u = j;
                }
            }
            used[u] = true;
            for (int v = 0; v < n; v++) {
                if (!used[v] && cords[u][v] < distances[v]) {
                    distances[v] = cords[u][v];
                    parent[v] = u;
                }
            }
        }
        for (int i = 1; i < n; i++) {
            System.out.println(distances[i] + " 2 " + parent[i] + " " + i);
        }
    }
}