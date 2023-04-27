#We have a list of people with information about them, including name, age, weight, height and home town. This people must be sorted in ascending order by the order of height, weight, age, home town and lastly name. Numbers are sorted by their value, words are sorted in alphabetical order. 

#The input data is given through standard input on the following format: The first row contains the number of people in the list. The following rows contain the data for each person, one row per person, with their name, age, weight, height and home town, all separated by spaces. 

#The output data should be printed to standard output given in the following format: The list of persons sorted according to the instructions, one row per person, with their name, age, weight, height and home town, all separated by spaces.


def main():
    n = int(input())
    people = []
    for i in range(n):
        person = input().split()
        person[1] = int(person[1])
        person[2] = int(person[2])
        person[3] = int(person[3])
        people.append(person)
    people.sort(key = lambda x: (x[3], x[2], x[1], x[4], x[0]))
    for person in people:
        print(person[0], person[1], person[2], person[3], person[4])



if __name__ == "__main__":
    main()