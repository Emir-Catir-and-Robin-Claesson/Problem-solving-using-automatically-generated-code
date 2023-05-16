from itertools import combinations

def count_combinations(num_containers, capacities):
    """
    This function takes the number of available containers and their capacities as arguments and returns the number of
    different combinations of containers that can exactly fit all the eggnog.
    
    Parameters:
    num_containers (int): The number of available containers
    capacities (list): A list of integers indicating the capacities of the containers
    
    Returns:
    int: The number of different combinations of containers that can exactly fit all the eggnog
    """
    try:
        # Check if the number of containers is an integer
        if not isinstance(num_containers, int):
            raise TypeError("The number of containers must be an integer")
        
        # Check if all capacities are integers
        if not all(isinstance(capacity, int) for capacity in capacities):
            raise TypeError("All capacities must be integers")
        
        # Calculate all possible combinations of containers
        container_combinations = []
        for i in range(1, num_containers+1):
            container_combinations += combinations(capacities, i)
        
        # Count the number of combinations that can fit all the eggnog
        count = 0
        for combination in container_combinations:
            if sum(combination) == 150:
                count += 1
        
        return count
    except TypeError as e:
        # Log the error
        print(f"Error: {e}")
        return 0