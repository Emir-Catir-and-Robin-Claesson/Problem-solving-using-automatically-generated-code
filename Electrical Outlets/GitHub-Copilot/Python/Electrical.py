#In a concert hall, the musicians sit in designated places, and each music stand has its own lamp with a lamp cord that just barely reaches the floor. In order for all music stand lamps to be powered, an electrician needs to build a network of branch sockets and cords, where the number of sockets and the length of the cords are adjusted by the electrician according to need. There needs to be an electrical outlet under each music stand, and branch sockets are only allowed to be placed under the music stands. There is only one wall outlet in the concert hall, and it sits 150 centimeters from the nearest music stand. The problem is to design a network of cords with power outlets that use as little cord (power cable) as possible and no unused power outlets. 
#The input data is given through standard input on the following format. The first row contains N, the number of music stands. The following rows are each a row of the NxN matrix, with the numbers separated by spaces, and place (i, j) indicates how long a cord would be required to be to reach from stand i to stand j. The Nth music stand is the one closest to the wall outlet. The length of the cords are positive integers, representing the length in centimeters. 
#The output data should be printed to standard output in the following format. A row for each of the branch sockets used to build the network that powers the lamps. Each row should print the length of the cord, the number of sockets it has, the number of the music stand where the cord is plugged in, and the number of the music stand it lies beneath, all separated by spaces. The wall outlet is considered as music stand 0.

def electrical():
    n = int(input())
    cords = []
    for i in range(n):
        cords.append(input().split())
    cords = [[int(i) for i in row] for row in cords]
    cords = [[0] + row for row in cords]
    cords = [[0] * (n+1)] + cords
    visited = [0] * (n+1)
    visited[0] = 1
    path = []
    min_cord = 0
    min_cord_path = []
    def dfs(node, path, cord):
        nonlocal min_cord
        nonlocal min_cord_path
        if sum(visited) == n+1:
            if cord < min_cord or min_cord == 0:
                min_cord = cord
                min_cord_path = path
            return
        for i in range(n+1):
            if visited[i] == 0 and cords[node][i] != 0:
                visited[i] = 1
                path.append((node, i))
                dfs(i, path, cord + cords[node][i])
                path.pop()
                visited[i] = 0
    dfs(0, [], 0)
    print(min_cord)
    for i in range(len(min_cord_path)):
        print(min_cord_path[i][1], min_cord_path[i][0])

def main():
    electrical()

if __name__ == "__main__":
    main()
    