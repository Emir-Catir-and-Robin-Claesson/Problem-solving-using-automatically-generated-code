import java.util.Arrays;
import java.util.Scanner;

public class Sorting1 {

    // We have a list of people with information about them, including name, age,
    // weight, height and home town. This people must be sorted in ascending order
    // by the order of height, weight, age, home town and lastly name. Numbers are
    // sorted by their value, words are sorted in alphabetical order.
    // The input data is given through standard input on the following format: The
    // first row contains the number of people in the list. The following rows
    // contain the data for each person, one row per person, with their name, age,
    // weight, height and home town, all separated by spaces.
    // The output data should be printed to standard output given in the following
    // format: The list of persons sorted according to the instructions, one row per
    // person, with their name, age, weight, height and home town, all separated by
    // spaces.
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        scanner.nextLine();
        Person[] people = new Person[n];
        for (int i = 0; i < n; i++) {
            String[] input = scanner.nextLine().split(" ");
            Person person = new Person(input[0], Integer.parseInt(input[1]), Integer.parseInt(input[2]),
                    Integer.parseInt(input[3]), input[4]);
            people[i] = person;
        }
        Arrays.sort(people);
        for (Person person : people) {
            System.out.println(person);
        }
    }

    static class Person implements Comparable<Person> {
        String name;
        int age;
        int weight;
        int height;
        String homeTown;
        
        public Person(String name, int age, int weight, int height, String homeTown) {
            this.name = name;
            this.age = age;
            this.weight = weight;
            this.height = height;
            this.homeTown = homeTown;
        }
        
        public int compareTo(Person other) {
            int result = this.height - other.height;
            if (result != 0) {
                return result;
            }
            
            result = this.weight - other.weight;
            if (result != 0) {
                return result;
            }
            
            result = this.age - other.age;
            if (result != 0) {
                return result;
            }
            
            result = this.homeTown.compareTo(other.homeTown);
            if (result != 0) {
                return result;
            }
            
            result = this.name.compareTo(other.name);
            return result;
        }
        
        public String toString() {
            return String.format("%s %d %d %d %s", this.name, this.age, this.weight, this.height, this.homeTown);
        }
    }
}