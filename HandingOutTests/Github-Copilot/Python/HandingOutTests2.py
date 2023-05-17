#In a classroom, there is a teacher and a set of students. The teacher has a list of all students, as well as the distance between each pair of students. The teacher wants to hand out tests to all students, passing every student, but no more than once, while taking the shortest path. The students are numbered with a unique student ID such that student number one has the unique student ID 1 and so on. The teacher must start at the student with unique ID 1 and must also return to this student after visiting all other students. Come up with the shortest path that traverses every student only once and returns to the starting student.
#The input will be given to standard input in this order: The first row contains the total number of students. The following rows, one for each pair of students, contain three numbers separated by spaces where the first number is the student ID for a student, the second number is the ID for another student and the third number is the distance between the two students.
#The output should be printed to standard output in this order: The first row should contain the total distance traveled. The second row should be the path that the teacher should take, consisting of the student IDs in the order the teacher should walk, where each student ID is separated by a space.

def main():
    # Get the number of students
    numStudents = int(input())

    # Make a dictionary of students and their distances
    studentDict = {}
    for i in range(numStudents):
        student1, student2, distance = input().split()
        student1 = int(student1)
        student2 = int(student2)
        distance = int(distance)
        if student1 not in studentDict:
            studentDict[student1] = [(student2, distance)]
        else:
            studentDict[student1].append((student2, distance))

    # Find the shortest path
    currentStudent = 1
    path = [currentStudent]
    totalDistance = 0
    while len(path) < numStudents + 1:
        # Get the shortest distance
        shortestDistance = float("inf")
        for student in studentDict[currentStudent]:
            if student[1] < shortestDistance and student[0] not in path:
                shortestDistance = student[1]
                nextStudent = student[0]

        # Add the distance to the total distance
        totalDistance += shortestDistance

        # Add the next student to the path
        path.append(nextStudent)

        # Set the current student to the next student
        currentStudent = nextStudent

    # Add the distance back to the first student to the total distance
    totalDistance += studentDict[currentStudent][0][1]

    # Add the first student to the path
    path.append(1)

    # Print the total distance
    print(totalDistance)

    # Print the path
    for student in path:
        print(student, end=" ")

if __name__ == '__main__':
    main()