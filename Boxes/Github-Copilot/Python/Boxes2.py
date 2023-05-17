#A person is moving out of their house and need to pack all their belongings into boxes. They have an infinite number of boxes available but want to use as few as possible. The person has a list of all their items that need to be packed in boxes. All boxes have the same weight capacity.

#The input will be given to standard input in this order: The first row contains the weight capacity of the boxes. The second row contains the number of items. The following rows contain the weight of each item.

#The output should be printed to standard output in this order: The number of boxes needed to carry all the items.

def main():
    weightCapacity = int(input())
    numberOfItems = int(input())
    weights = []
    for i in range(numberOfItems):
        weights.append(int(input()))
    weights.sort(reverse=True)
    numberOfBoxes = 0
    while len(weights) > 0:
        weight = weights.pop(0)
        while weight < weightCapacity and weights:
            weight += weights.pop()
        numberOfBoxes += 1
    print(numberOfBoxes)

if __name__ == "__main__":
    main()
    