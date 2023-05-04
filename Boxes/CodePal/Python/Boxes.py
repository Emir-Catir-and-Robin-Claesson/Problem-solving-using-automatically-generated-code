def main():
    try:
    
        weight_capacity = int(input())
        num_items = int(input())
        items = []
        for i in range(num_items):
            items.append(int(input()))

        
        # Check if weight capacity is an integer
        if not isinstance(weight_capacity, int):
            raise TypeError("Weight capacity must be an integer")
        
        # Check if items is a list of integers
        if not all(isinstance(item, int) for item in items):
            raise TypeError("Items must be a list of integers")
        
        # Sort the items in descending order
        items.sort(reverse=True)
        
        # Initialize variables
        num_boxes = 0
        current_box_weight = 0
        
        # Pack the items into boxes
        for item in items:
            if current_box_weight + item <= weight_capacity:
                current_box_weight += item
            else:
                num_boxes += 1
                current_box_weight = item
        
        # Add the last box if it's not empty
        if current_box_weight > 0:
            num_boxes += 1
        
        print(num_boxes)
    
    except TypeError as e:
        # Log the error
        print(f"Error: {e}")
        return 0
    

if __name__ == "__main__":
    main()
    