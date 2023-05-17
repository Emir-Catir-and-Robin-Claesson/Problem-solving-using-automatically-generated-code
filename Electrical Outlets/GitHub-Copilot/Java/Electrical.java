import java.util.Arrays;
import java.util.Scanner;

public class Electrical {
    //In a concert hall, the musicians sit in designated places, and each music stand has its own lamp with a lamp cord that just barely reaches the floor. In order for all music stand lamps to be powered, an electrician needs to build a network of branch sockets and cords, where the number of sockets and the length of the cords are adjusted by the electrician according to need. There needs to be an electrical outlet under each music stand, and branch sockets are only allowed to be placed under the music stands. There is only one wall outlet in the concert hall, and it sits 150 centimeters from the nearest music stand. The problem is to design a network of cords with power outlets that use as little cord (power cable) as possible and no unused power outlets. 
    //The input data is given through standard input on the following format. The first row contains N, the number of music stands. The following rows are each a row of the NxN matrix, with the numbers separated by spaces, and place (i, j) indicates how long a cord would be required to be to reach from stand i to stand j. The Nth music stand is the one closest to the wall outlet. The length of the cords are positive integers, representing the length in centimeters. 
    //The output data should be printed to standard output in the following format. A row for each of the branch sockets used to build the network that powers the lamps. Each row should print the length of the cord, the number of sockets it has, the number of the music stand where the cord is plugged in, and the number of the music stand it lies beneath, all separated by spaces. The wall outlet is considered as music stand 0.
    public static void main(String[] args){

        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        int[][] cords = new int[n][n];
        for(int i = 0; i < n; i++){
            for(int j = 0; j < n; j++){
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
        for(int i = 0; i < n - 1; i++){
            int u = -1;
            for(int j = 0; j < n; j++){
                if(!used[j] && (u == -1 || distances[j] < distances[u])){
                    u = j;
                }
            }
            used[u] = true;
            for(int v = 0; v < n; v++){
                if(!used[v] && cords[u][v] < distances[v]){
                    distances[v] = cords[u][v];
                    parent[v] = u;
                }
            }
        }
        for(int i = 1; i < n; i++){
            System.out.println(distances[i] + " 2 " + parent[i] + " " + i);
        }

    }
}