import java.util.*;

public class Sorting1 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        List<Person> people = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            String name = scanner.next();
            int age = scanner.nextInt();
            int weight = scanner.nextInt();
            int height = scanner.nextInt();
            String homeTown = scanner.next();
            people.add(new Person(name, age, weight, height, homeTown));
        }
        Collections.sort(people);
        for (Person person : people) {
            System.out.println(person);
        }
    }
}

class Person implements Comparable<Person> {
    private String name;
    private int age;
    private int weight;
    private int height;
    private String homeTown;

    public Person(String name, int age, int weight, int height, String homeTown) {
        this.name = name;
        this.age = age;
        this.weight = weight;
        this.height = height;
        this.homeTown = homeTown;
    }

    @Override
    public int compareTo(Person other) {
        if (this.height != other.height) {
            return Integer.compare(this.height, other.height);
        } else if (this.weight != other.weight) {
            return Integer.compare(this.weight, other.weight);
        } else if (this.age != other.age) {
            return Integer.compare(this.age, other.age);
        } else if (!this.homeTown.equals(other.homeTown)) {
            return this.homeTown.compareTo(other.homeTown);
        } else {
            return this.name.compareTo(other.name);
        }
    }

    @Override
    public String toString() {
        return String.format("%s %d %d %d %s", name, age, weight, height, homeTown);
    }
}