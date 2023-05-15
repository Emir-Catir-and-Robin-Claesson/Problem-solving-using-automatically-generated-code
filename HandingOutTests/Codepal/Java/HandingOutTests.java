import java.util.*;

public class HandingOutTests {
    public static void main(String[] args) 
    {
        Scanner scanner = new Scanner(System.in);

        // Read the number of students
        int n = scanner.nextInt();

        // Create a 2D array to store the distances between students
        int[][] distances = new int[n][n];

        // Read the distances between each pair of students
        for (int i = 0; i < n * (n - 1) / 2; i++) {
            int student1 = scanner.nextInt() - 1;
            int student2 = scanner.nextInt() - 1;
            int distance = scanner.nextInt();
            distances[student1][student2] = distance;
            distances[student2][student1] = distance;
        }

        // Initialize the visited array and the starting node
        boolean[] visited = new boolean[n];
        visited[0] = true;
        int currentNode = 0;

        // Initialize the path and the total distance
        List<Integer> path = new ArrayList<>();
        path.add(currentNode + 1);
        int totalDistance = 0;

        // Repeat until all nodes have been visited
        while (path.size() < n) {
            // Find the nearest unvisited node
            int nearestNode = -1;
            int nearestDistance = Integer.MAX_VALUE;
            for (int i = 0; i < n; i++) {
                if (!visited[i] && distances[currentNode][i] < nearestDistance) {
                    nearestNode = i;
                    nearestDistance = distances[currentNode][i];
                }
            }

            // Mark the nearest node as visited and update the current node and the total distance
            visited[nearestNode] = true;
            currentNode = nearestNode;
            path.add(currentNode + 1);
            totalDistance += nearestDistance;
        }

        // Add the starting node to the end of the path and update the total distance
        path.add(1);
        totalDistance += distances[currentNode][0];

        // Print the total distance and the path
        System.out.println(totalDistance);
        for (int i = 0; i < path.size(); i++) {
            System.out.print(path.get(i));
            if (i < path.size() - 1) {
                System.out.print(" ");
            }
        }
        scanner.close();
    }
}