#In a classroom, there is a teacher and a set of students. The teacher has a list of all students, as well as the distance between each pair of students. The teacher wants to hand out tests to all students, passing every student, but no more than once, while taking the shortest path. The students are numbered with a unique student ID such that student number one has the unique student ID 1 and so on. The teacher must start at the student with unique ID 1 and must also return to this student after visiting all other students. Come up with the shortest path that traverses every student only once and returns to the starting student. 

#The input will be given to standard input in this order: The first row contains the total number of students. The following rows, one for each pair of students, contain three numbers separated by spaces where the first number is the student ID for a student, the second number is the ID for another student and the third number is the distance between the two students.

#The output should be printed to standard output in this order: The first row should contain the total distance traveled. The second row should be the path that the teacher should take, consisting of the student IDs in the order the teacher should walk, where each student ID is separated by a space.

def main():
    #Get input
    numStudents = int(input())
    distances = []
    for i in range(numStudents):
        for j in range(i+1, numStudents):
            distances.append(input().split())
    #Find the shortest path
    path = []
    path.append(1)
    while len(path) < numStudents:
        minDist = 100
        for i in range(len(distances)):
            if int(distances[i][0]) == path[-1] and int(distances[i][2]) < minDist:
                minDist = int(distances[i][2])
                nextStudent = int(distances[i][1])
                index = i
            elif int(distances[i][1]) == path[-1] and int(distances[i][2]) < minDist:
                minDist = int(distances[i][2])
                nextStudent = int(distances[i][0])
                index = i
        path.append(nextStudent)
        del distances[index]
    path.append(1)
    #Print the output
    print(sum([int(distances[i][2]) for i in range(len(distances))]))
    print(' '.join([str(path[i]) for i in range(len(path))]))


if __name__ == '__main__':
    main()

