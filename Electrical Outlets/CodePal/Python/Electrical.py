def read_input():
    """
    Reads the input data from standard input and returns it as a matrix of cord lengths.
    """
    n = int(input())
    cords = []
    for i in range(n):
        row = list(map(int, input().split()))
        cords.append(row)
    return cords

def create_music_stands():
    """
    Creates a list of all the music stands, with the wall outlet as stand 0.
    """
    return list(range(n))

def create_branch_sockets(music_stands):
    """
    Creates a list of all the possible branch sockets, which are the music stands that are not the wall outlet.
    """
    return music_stands[1:]

def create_cords(music_stands, cords):
    """
    Creates a list of all the possible cords, which are the connections between each pair of music stands.
    """
    all_cords = []
    for i in range(len(music_stands)):
        for j in range(i+1, len(music_stands)):
            cord = (cords[i][j], music_stands[i], music_stands[j])
            all_cords.append(cord)
    return sorted(all_cords)

def build_network(cords, branch_sockets):
    """
    Builds a network of cords with power outlets that use as little cord (power cable) as possible and no unused power outlets.
    """
    network = []
    while len(branch_sockets) > 0:
        cord = cords.pop(0)
        if cord[1] in branch_sockets and cord[2] not in branch_sockets:
            network.append(cord)
            branch_sockets.remove(cord[1])
    return network

def print_output(network):
    """
    Prints the network of cords to standard output in the specified format.
    """
    for cord in network:
        length = cord[0]
        sockets = 2
        start = cord[1]
        end = cord[2]
        print(f"{length} {sockets} {start} {end}")

# Main program
cords = read_input()
music_stands = create_music_stands()
branch_sockets = create_branch_sockets(music_stands)
all_cords = create_cords(music_stands, cords)
network = build_network(all_cords, branch_sockets)
print_output(network)