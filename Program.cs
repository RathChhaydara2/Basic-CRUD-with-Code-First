using Microsoft.EntityFrameworkCore; 
using (var db = new StudentDbContext())
{
    // --- INSERT ---
    var c1 = new Course { Title = "English" };
    var c2 = new Course { Title = "Mathematics" };
    var c3 = new Course { Title = "Physics" };
    db.Courses.AddRange(c1, c2, c3);
    db.SaveChanges();

    db.Students.AddRange(
        new Student { Name = "Dara", Age = 20, Email = "dara@test.com", CourseId = 1 },
        new Student { Name = "Sovann", Age = 22, Email = "sovann@test.com", CourseId = 1 },
        new Student { Name = "Thida", Age = 21, Email = "thida@test.com", CourseId = 2 },
        new Student { Name = "David", Age = 23, Email = "david@test.com", CourseId = 2 },
        new Student { Name = "Chenda", Age = 20, Email = "chenda@test.com", CourseId = 3 }
    );
    db.SaveChanges();
    Console.WriteLine("Data seeded successfully!");

    // --- READ (Display with Course Titles) ---
    Console.WriteLine("\n--- Student List ---");
    var students = db.Students.Include(s => s.Course).ToList();
    foreach (var s in students)
        Console.WriteLine($"{s.Name} | Course: {s.Course.Title}");

    // // --- UPDATE ---
    var studentToUpdate = db.Students.First(s => s.Name == "Dara");
    studentToUpdate.Age = 25;
    db.SaveChanges();
    Console.WriteLine("\nDara's age updated successfully.");

    // --- DELETE ---
    var studentToDelete = db.Students.OrderBy(s => s.StudentId).Last();
    db.Remove(studentToDelete);
    db.SaveChanges();
    Console.WriteLine($"Student {studentToDelete.Name} deleted.");

    // --- LINQ QUERIES ---
    Console.WriteLine("\n--- Grouped by Course ---");
    var grouped = db.Students.GroupBy(s => s.Course.Title);
    foreach (var group in grouped)
    {
        Console.WriteLine($"{group.Key}: {group.Count()} students");
    }

    Console.WriteLine("\n--- Search: Names starting with 'D' ---");
    var search = db.Students.Where(s => s.Name.StartsWith("D")).ToList();
    search.ForEach(s => Console.WriteLine(s.Name));
}