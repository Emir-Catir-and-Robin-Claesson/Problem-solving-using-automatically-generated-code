#A person is moving out of their house and need to pack all their belongings into boxes. They have an infinite number of boxes available but want to use as few as possible. The person has a list of all their items that need to be packed in boxes. All boxes have the same weight capacity.

#The input will be given to standard input in this order: The first row contains the weight capacity of the boxes. The second row contains the number of items. The following rows contain the weight of each item.

#The output should be printed to standard output in this order: The number of boxes needed to carry all the items.

def main():
    capacity = int(input())
    num_items = int(input())
    items = []
    for i in range(num_items):
        items.append(int(input()))
    boxes = 0
    while len(items) > 0:
        boxes += 1
        current_box = 0
        while current_box < capacity:
            if len(items) == 0:
                break
            item = items.pop()
            if current_box + item <= capacity:
                current_box += item
            else:
                items.append(item)
                break
    print(boxes)

if __name__ == "__main__":
    main()
    