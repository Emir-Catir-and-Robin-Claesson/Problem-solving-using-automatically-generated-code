#The elves bought too much eggnog again - 150 liters this time. To fit it all into your refrigerator, you'll need to move it into smaller containers. You take an inventory of the capacities of the available containers. For example, suppose you have containers of size 20, 15, 10, 5, and 5 liters. If you need to store 25 liters, there are four ways to do it:
#15 and 10
#20 and 5 (the first 5)
#20 and 5 (the second 5)
#15, 5, and 5
#Filling all containers entirely, how many different combinations of containers can exactly fit all 150 liters of eggnog?
#The input data is given through standard input on the following format: The first row contains the number of available containers Each following line contains the capacity of a container. All capacities are integers and indicate liters. 
#The output data should be printed to standard output given in the following format: One line with the answer. 

def main():
    # Read input
    n = int(input())
    containers = []
    for i in range(n):
        containers.append(int(input()))
    # Sort containers in descending order
    containers.sort(reverse=True)
    # Find possible combinations
    combinations = findCombinations(containers, 150)
    # Print result
    print(len(combinations))

def findCombinations(containers, target):
    # Base case
    if target == 0:
        return [[]]
    elif target < 0:
        return []
    # Recursive case
    combinations = []
    for i in range(len(containers)):
        # Find combinations using current container
        subCombinations = findCombinations(containers[i+1:], target-containers[i])
        # Add current container to all combinations
        combinations.extend(list(map(lambda x: [containers[i]] + x, subCombinations)))
    return combinations