// In a concert hall, the musicians sit in designated places, and each music stand has its own lamp with a lamp cord that just barely reaches the floor. In order for all music stand lamps to be powered, an electrician needs to build a network of branch sockets and cords, where the number of sockets and the length of the cords are adjusted by the electrician according to need. There needs to be an electrical outlet under each music stand, and branch sockets are only allowed to be placed under the music stands. There is only one wall outlet in the concert hall, and it sits 150 centimeters from the nearest music stand. The problem is to design a network of cords with power outlets that use as little cord (power cable) as possible and no unused power outlets.
// The input data is given through standard input on the following format. The first row contains N, the number of music stands. The following rows are each a row of the NxN matrix, with the numbers separated by spaces, and place (i, j) indicates how long a cord would be required to be to reach from stand i to stand j. The Nth music stand is the one closest to the wall outlet. The length of the cords are positive integers, representing the length in centimeters.
// The output data should be printed to standard output in the following format. A row for each of the branch sockets used to build the network that powers the lamps. Each row should print the length of the cord, the number of sockets it has, the number of the music stand where the cord is plugged in, and the number of the music stand it lies beneath, all separated by spaces. The wall outlet is considered as music stand 0.

#include <stdio.h>


int main()

{

    int N;

    scanf("%d", &N);

    int i, j;

    int matrix[N][N];

    for (i = 0; i < N; i++)

    {

        for (j = 0; j < N; j++)

        {

            scanf("%d", &matrix[i][j]);
        }
    }

    int min = 1000000;

    int min_i = 0;

    int min_j = 0;

    for (i = 0; i < N; i++)

    {

        for (j = 0; j < N; j++)

        {

            if (matrix[i][j] < min)

            {

                min = matrix[i][j];

                min_i = i;

                min_j = j;
            }
        }
    }

    printf("%d %d %d %d\n", min, 1, min_i, min_j);

    int k;

    int min2 = 1000000;

    int min_i2 = 0;

    int min_j2 = 0;

    for (k = 0; k < N; k++)

    {

        if (matrix[min_i][k] < min2)

        {

            min2 = matrix[min_i][k];

            min_i2 = min_i;

            min_j2 = k;
        }
    }

    printf("%d %d %d %d\n", min2, 2, min_i2, min_j2);

    int min3 = 1000000;

    int min_i3 = 0;

    int min_j3 = 0;

    for (k = 0; k < N; k++)

    {

        if (matrix[min_i2][k] < min3)

        {

            min3 = matrix[min_i2][k];

            min_i3 = min_i2;

            min_j3 = k;
        }
    }

    printf("%d %d %d %d\n", min3, 3, min_i3, min_j3);

    return 0;
}