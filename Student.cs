public class Student
{
    public int StudentId {get;set;}
    public string Name {get;set;}
    public int Age {get;set;}
    public string Email {get;set;}
    public int CourseId {get;set;}
    public Course Course { get; set; }
    
}