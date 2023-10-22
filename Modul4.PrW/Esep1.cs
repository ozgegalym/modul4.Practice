using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


struct Student
{
    public string FullName;
    public string GroupNumber;
    public int[] Grades;

    public double CalculateAverageGrade() => Grades.Average();
}

class Program
{
    static void Main()
    {
        Student[] students = {
            new Student { FullName = "Бауыржан", GroupNumber = "Группа 1", Grades = new int[] { 4, 5, 4, 4, 3 } },
            new Student { FullName = "Сека", GroupNumber = "Группа 2", Grades = new int[] { 5, 5, 5, 5, 5 } },
            new Student { FullName = "Ернур", GroupNumber = "Группа 1", Grades = new int[] { 3, 4, 3, 4, 4 } },
            new Student { FullName = "Руся", GroupNumber = "Группа 3", Grades = new int[] { 4, 5, 3, 4, 5 } },
            new Student { FullName = "Сергей", GroupNumber = "Группа 2", Grades = new int[] { 5, 4, 5, 4, 5 } },
            new Student { FullName = "Колтыкшаш", GroupNumber = "Группа 3", Grades = new int[] { 4, 4, 4, 3, 5 } },
            new Student { FullName = "Котыргул", GroupNumber = "Группа 1", Grades = new int[] { 3, 3, 3, 3, 3 } },
            new Student { FullName = "Кыпшакбек", GroupNumber = "Группа 2", Grades = new int[] { 4, 5, 4, 3, 4 } },
            new Student { FullName = "Никита", GroupNumber = "Группа 3", Grades = new int[] { 5, 4, 5, 4, 5 } },
            new Student { FullName = "Егор", GroupNumber = "Группа 1", Grades = new int[] { 4, 3, 3, 4, 4 } }
        };

        Array.Sort(students, (s1, s2) => s1.CalculateAverageGrade().CompareTo(s2.CalculateAverageGrade()));

        Console.WriteLine("Студенты с оценками 4 или 5:");
        foreach (Student student in students)
        {
            if (student.Grades.All(grade => grade == 4 || grade == 5))
            {
                Console.WriteLine($"Имя: {student.FullName}, Группа: {student.GroupNumber}");
            }
        }

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
