from typing import List

def sort_people(people: List[str]) -> List[str]:
    """
    This function takes a list of people with information about them, including name, age, weight, height and home town.
    The people are sorted in ascending order by the order of height, weight, age, home town and lastly name.
    Numbers are sorted by their value, words are sorted in alphabetical order.
    
    Parameters:
    people (List[str]): A list of people with their information
    
    Returns:
    List[str]: The sorted list of people with their information
    """
    try:
        # Check if the input list is empty
        if not people:
            raise ValueError("Input list cannot be empty")
        
        # Sort the people by height, weight, age, home town and name
        sorted_people = sorted(people, key=lambda x: (int(x.split()[3]), int(x.split()[2]), int(x.split()[1]), x.split()[4], x.split()[0]))
        
        # Return the sorted list of people
        return sorted_people
    except ValueError as e:
        # Log the error
        print(f"Error: {e}")
        return []
    
def main():
    # Get the number of people
    n = int(input())
    
    # Get the list of people
    people = []
    for _ in range(n):
        people.append(input())
    
    # Sort the people
    sorted_people = sort_people(people)
    
    # Print the sorted list of people
    for person in sorted_people:
        print(person)

if __name__ == "__main__":
    main()