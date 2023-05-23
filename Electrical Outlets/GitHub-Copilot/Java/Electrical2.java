import java.util.Arrays;
import java.util.Scanner;

public class Electrical2 {
    //In a concert hall, the musicians sit in designated places, and each music stand has its own lamp with a lamp cord that just barely reaches the floor. In order for all music stand lamps to be powered, an electrician needs to build a network of branch sockets and cords, where the number of sockets and the length of the cords are adjusted by the electrician according to need. There needs to be an electrical outlet under each music stand, and branch sockets are only allowed to be placed under the music stands. There is only one wall outlet in the concert hall, and it sits 150 centimeters from the nearest music stand. The problem is to design a network of cords with power outlets that use as little cord (power cable) as possible and no unused power outlets. 
    //The input data is given through standard input on the following format. The first row contains N, the number of music stands. The following rows are each a row of the NxN matrix, with the numbers separated by spaces, and place (i, j) indicates how long a cord would be required to be to reach from stand i to stand j. The Nth music stand is the one closest to the wall outlet. The length of the cords are positive integers, representing the length in centimeters. 
    //The output data should be printed to standard output in the following format. A row for each of the branch sockets used to build the network that powers the lamps. Each row should print the length of the cord, the number of sockets it has, the number of the music stand where the cord is plugged in, and the number of the music stand it lies beneath, all separated by spaces. The wall outlet is considered as music stand 0.
    public static void main(String[] args){

        
        Scanner sc = new Scanner(System.in);
        int N = sc.nextInt();
        int[][] arr = new int[N][N];
        int[] cords = new int[N];
        int[] sockets = new int[N];
        int[] from = new int[N];
        int[] to = new int[N];
        int[] length = new int[N];
        for(int i = 0; i < N; i++){
            sockets[i] = 1;
            for(int j = 0; j < N; j++){
                arr[i][j] = sc.nextInt();
            }
        }
        int min = 0;
        int minIndex = 0;
        int minIndex2 = 0;
        int minIndex3 = 0;
        int temp = 0;
        int temp2 = 0;
        int temp3 = 0;
        for(int i = 0; i < N; i++){
            min = 9999999;
            minIndex = 0;
            minIndex2 = 0;
            minIndex3 = 0;
            for(int j = 0; j < N; j++){
                if(arr[i][j] < min){
                    min = arr[i][j];
                    minIndex = j;
                }
            }
            for(int j = 0; j < N; j++){
                if(arr[i][j] < min && arr[i][j] > 0){
                    min = arr[i][j];
                    minIndex2 = j;
                }
            }
            for(int j = 0; j < N; j++){
                if(arr[i][j] < min && arr[i][j] > 0 && arr[i][j] != arr[i][minIndex]){
                    min = arr[i][j];
                    minIndex3 = j;
                }
            }
            if(minIndex3 != 0){
                if(arr[i][minIndex3] + arr[minIndex3][minIndex2] < arr[i][minIndex2] + arr[minIndex2][minIndex]){
                    temp = minIndex;
                    minIndex = minIndex3;
                    minIndex3 = temp;
                }
            }
            if(minIndex3 != 0){
                if(arr[i][minIndex3] + arr[minIndex3][minIndex2] < arr[i][minIndex2] + arr[minIndex2][minIndex]){
                    temp = minIndex;
                    minIndex = minIndex3;
                    minIndex3 = temp;
                }

    }
}