#In a concert hall, the musicians sit in designated places, and each music stand has its own lamp with a lamp cord that just barely reaches the floor. In order for all music stand lamps to be powered, an electrician needs to build a network of branch sockets and cords, where the number of sockets and the length of the cords are adjusted by the electrician according to need. There needs to be an electrical outlet under each music stand, and branch sockets are only allowed to be placed under the music stands. There is only one wall outlet in the concert hall, and it sits 150 centimeters from the nearest music stand. The problem is to design a network of cords with power outlets that use as little cord (power cable) as possible and no unused power outlets. 
#
#The input data is given through standard input on the following format. The first row contains N, the number of music stands. The following rows are each a row of the NxN matrix, with the numbers separated by spaces, and place (i, j) indicates how long a cord would be required to be to reach from stand i to stand j. The Nth music stand is the one closest to the wall outlet. The length of the cords are positive integers, representing the length in centimeters. 
#
#The output data should be printed to standard output in the following format. A row for each of the branch sockets used to build the network that powers the lamps. Each row should print the length of the cord, the number of sockets it has, the number of the music stand where the cord is plugged in, and the number of the music stand it lies beneath, all separated by spaces. The wall outlet is considered as music stand 0.

def main():
    from sys import stdin
    from heapq import heappush, heappop
    from math import inf
    from collections import deque

    def bfs(start):
        visited = [False for _ in range(n)]
        queue = deque()
        queue.append(start)
        visited[start] = True
        while queue:
            node = queue.popleft()
            for neighbour in range(n):
                if not visited[neighbour] and graph[node][neighbour] != inf:
                    visited[neighbour] = True
                    queue.append(neighbour)
        return visited

    def prim(start):
        visited = [False for _ in range(n)]
        heap = []
        heappush(heap, (0, start))
        total = 0
        while heap:
            dist, node = heappop(heap)
            if not visited[node]:
                visited[node] = True
                total += dist
                for neighbour in range(n):
                    if not visited[neighbour] and graph[node][neighbour] != inf:
                        heappush(heap, (graph[node][neighbour], neighbour))
        return total

    n = int(stdin.readline())
    graph = [list(map(int, stdin.readline().split())) for _ in range(n)]
    visited = bfs(0)
    for i in range(n):
        if not visited[i]:
            print('impossible')
            return
    total = prim(0)
    print(total)

main()
