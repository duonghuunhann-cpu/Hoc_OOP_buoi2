using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Student
{
    private string name;
    private double score;
    private static int totalStudents = 0;

    public Student(string name, double score)
    {
        this.name = name;
        this.score = score;
        totalStudents++;
    }

    // instance methods
    public string GetName()
    {
        return this.name;
    }

    public double GetScore()
    {
        return this.score;
    }

    public bool IsPassed()
    {
        return this.score >= 5.0;
    }

    public string GetClassification()
    {
        if (this.score >= 8.0)
            return "Excellent";
        else if (this.score >= 6.5)
            return "Good";
        else if (this.score >= 5.0)
            return "Average";
        else
            return "Weak";
    }

    // static methods
    public static int GetTotalStudents()
    {
        return totalStudents;
    }

    public static Student FindTopStudent(Student[] students)
    {
        if (students == null || students.Length == 0)
            return null;

        Student topStudent = students[0];
        for (int i = 1; i < students.Length; i++)
        {
            if (students[i].GetScore() > topStudent.GetScore())
            {
                topStudent = students[i];
            }
        }
        return topStudent;
    }

    public static double CalculateAverageScore(Student[] students)
    {
        if (students == null || students.Length == 0)
            return 0.0;

        double totalScore = 0;
        foreach (Student s in students)
        {
            totalScore += s.GetScore();
        }
        return totalScore / students.Length;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 1.tao mang gom 5 sinh vien
        Student[] students = new Student[]
        {
            new Student("An", 8.5),
            new Student("Bình", 6.8),
            new Student("Cường", 4.5),
            new Student("Dung", 9.2),
            new Student("Huy", 5.5)
        };

        // 2.in tong so sinh vien da tao 
        Console.WriteLine($"Total students created: {Student.GetTotalStudents()}");
        

        // 3.in danh sach sinh vien va ket qua 
        Console.WriteLine("Student List:");
        foreach (Student s in students)
        {
            string status = s.IsPassed() ? "Passed" : "Failed";
            Console.WriteLine($"- Name: {s.GetName(),-8} | Score: {s.GetScore(),-4} | Classification: {s.GetClassification(),-10} | Status: {status}");
        }

        // 4.tim va in sinh vien co diem cao nhat
        Student topStudent = Student.FindTopStudent(students);
        if (topStudent != null)
        {
            Console.WriteLine($"Top Student: {topStudent.GetName()} with score {topStudent.GetScore()}");
        }

        // 5.in diem trung binh ca lop 
        double classAvg = Student.CalculateAverageScore(students);
        Console.WriteLine($"Class Average Score: {classAvg:F2}");
    }
}