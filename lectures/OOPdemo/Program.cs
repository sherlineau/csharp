using OOPDemo;

Person alex = new Person("Alex", "Miller");
Student studiousAlex = new Student("Alex", "Miller", 13);
Student studiousCody = new Student("Cody", "Adams", 1);
Student studiousYukio = new Student("Yukio", "Rideb", 29);

List<string> taughtCourses = new List<string>();
taughtCourses.Add("Python");
taughtCourses.Add("C#");
taughtCourses.Add("Mern");
Instructor max = new Instructor("Max", "Rauchman", taughtCourses);

List<Student> studentList = new List<Student>() {
  studiousAlex, studiousCody, studiousYukio
};

Lecture cSharp = new Lecture(max, studentList, "C#");

// Console.WriteLine(studiousAlex.FullName());
// Console.WriteLine(studiousAlex.StudentId);
// Console.WriteLine(max.FullName());
// max.PrintCourses();
cSharp.PrintAttendance();

// int? nullableInt;
// int notNull;

