#The elves bought too much eggnog again - 150 liters this time. To fit it all into your refrigerator, you'll need to move it into smaller containers. You take an inventory of the capacities of the available containers. For example, suppose you have containers of size 20, 15, 10, 5, and 5 liters. If you need to store 25 liters, there are four ways to do it:
#15 and 10
#20 and 5 (the first 5)
#20 and 5 (the second 5)
#15, 5, and 5
#Filling all containers entirely, how many different combinations of containers can exactly fit all 150 liters of eggnog?
#The input data is given through standard input on the following format: The first row contains the number of available containers Each following line contains the capacity of a container. All capacities are integers and indicate liters. 
#The output data should be printed to standard output given in the following format: One line with the answer. 

def main():
    #Read the number of containers
    numContainers = int(input())
    #Read the capacity of each container
    capacities = []
    for i in range(numContainers):
        capacities.append(int(input()))
    #Calculate the number of combinations
    combinations = 0
    for i in range(2**numContainers):
        tempSum = 0
        for j in range(numContainers):
            if (i>>j)%2 == 1:
                tempSum += capacities[j]
        if tempSum == 150:
            combinations += 1

    print(combinations)


if __name__ == "__main__":
    main() 