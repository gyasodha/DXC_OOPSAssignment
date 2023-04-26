using System;

namespace ScoreCard
{
    class Student
    {
        public string Name { get; set; }
        public int RollNo { get; set; }
        public int Math { get; set; }
        public int Science { get; set; }
        public int English { get; set; }
        public int Language { get; set; }
        public int SST { get; set; }
        public int TotalMarks { get; set; }
        public string Grade { get; set; }

        public bool IsPassed()
        {
            return (Math >= 35 && Science >= 35 && English >= 35 && Language >= 35 && SST >= 35);
        }

        public void GetGrade()
        {
            if (TotalMarks >= 450)
            {
                Grade = "A";
            }
            else if (TotalMarks >= 400)
            {
                Grade = "B";
            }
            else if (TotalMarks >= 350)
            {
                Grade = "C";
            }
            else if (TotalMarks >= 300)
            {
                Grade = "D";
            }
            else if (TotalMarks >= 250)
            {
                Grade = "E";
            }
            else
            {
                Grade = "F";
            }
        }
    }

    class ScoreCard
    {
        Student[] students;

        public void getDetails()
        {
            Console.WriteLine("Enter the number of students: ");
            int numofStudents = Convert.ToInt16(Console.ReadLine());

            students = new Student[numofStudents];

            for (int i = 0; i < numofStudents; i++)
            {
                Console.WriteLine($"Enter the Details for Student {i + 1}");

                Console.WriteLine("Enter the Roll No");
                int rollno = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Enter the Student Name");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Marks for Maths");
                int maths = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Enter Marks for Science");
                int science = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Enter Marks for English");
                int english = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Enter Marks for Language");
                int language = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Enter Marks for SST");
                int sst = Convert.ToInt16(Console.ReadLine());

                int total = maths + science + english + language + sst;

                students[i] = new Student() { RollNo = rollno, Name = name, Math = maths, Science = science, English = english, Language = language, SST = sst, TotalMarks = total };

                students[i].GetGrade();
            }
        }

        public void Details()
        {
            int sum = 0;
            int max = 0;

            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"Roll No: {students[i].RollNo} Name: {students[i].Name}");
                Console.WriteLine($"Math: {students[i].Math}, Science: {students[i].Science}, English: {students[i].English}, Language: {students[i].Language}, SST: {students[i].SST}");
                Console.WriteLine($"Total Marks: {students[i].TotalMarks}, Grade: {students[i].Grade}");
            }

            // Top scorer
            int maxTotalMarks = -1;
            string topScorerName = "";
            int topScorerRollNo = 0;


            foreach (Student student in students)

            {

                if (student.TotalMarks > maxTotalMarks)

                {

                    maxTotalMarks = student.TotalMarks;

                    topScorerName = student.Name;

                    topScorerRollNo = student.RollNo;

                }

            }

            Console.WriteLine($"\nTop Scorer: {topScorerName} (Roll No.: {topScorerRollNo}), Total Marks: {maxTotalMarks}");



            // Average marks in each subject

            double avgMath = 0, avgScience = 0, avgEnglish = 0, avgLanguage = 0, avgSST = 0;



            foreach (Student student in students)

            {

                avgMath += student.Math;

                avgScience += student.Science;

                avgEnglish += student.English;

                avgLanguage += student.Language;

                avgSST += student.SST;

            }



            avgMath /= students.Length;

            avgScience /= students.Length;

            avgEnglish /= students.Length;

            avgLanguage /= students.Length;

            avgSST /= students.Length;



            Console.WriteLine($"\nAverage Marks\nMath: {avgMath:F2}\nScience: {avgScience:F2}\nEnglish: {avgEnglish:F2}\nLanguage: {avgLanguage:F2}\nSocial Studies: {avgSST:F2}");



            // Number of students who have cleared the examination           

            Console.WriteLine("\nStudents who have cleared the examination:");

            foreach (Student student in students)

            {

                if (student.Math >= 35 && student.Science >= 35 && student.English >= 35 && student.Language >= 35 && student.SST >= 35)

                {

                    Console.WriteLine($"{student.Name} (Roll No.: {student.RollNo})");

                }

            }



            // Display the number of students who failed

            int failedStudents = 0;

            for (int i = 0; i < students.Length; i++)

            {

                if (!students[i].IsPassed())

                {

                    failedStudents++;

                }

            }



            Console.WriteLine("\nNumber of students who need to mandatorily repeat the examination: {0}", failedStudents);

            Console.WriteLine("\nDetails of students who need to mandatorily repeat the examination:");

            Console.WriteLine("Roll No\tName");

            Console.WriteLine("-------------------------------------------------");

            for (int i = 0; i < students.Length; i++)

            {

                if (!students[i].IsPassed())

                {

                    Console.WriteLine("{0}\t{1}", students[i].RollNo, students[i].Name);

                }

            }

            Console.WriteLine();

        }



        public void Gettinggrade()

        {

            string Grade = "A";

            foreach (Student student in students)

            {

                double studentAverage = 0;

                studentAverage = student.TotalMarks / 5;

                if (studentAverage >= 95)

                {

                    Grade = "A";

                }

                else if (studentAverage >= 80)

                {

                    Grade = "B";

                }

                else if (studentAverage >= 70)

                {

                    Grade = "C";

                }

                else if (studentAverage >= 60)

                {

                    Grade = "D";

                }

                else if (studentAverage >= 50)

                {

                    Grade = "E";

                }

                else

                {

                    Grade = "F";

                }

            }

            Console.WriteLine();

        }



        public void Scorescard(int roll)

        {

            Console.WriteLine("ScoreCard");

            foreach (Student student in students)

            {

                if (roll == student.RollNo)

                {

                    Console.WriteLine($"Name of the student: {student.Name}");

                    Console.WriteLine($"Roll Number: {student.RollNo}");

                    Console.WriteLine($"Math Marks: {student.Math}");

                    Console.WriteLine($"Science Marks: {student.Science}");

                    Console.WriteLine($"English Marks: {student.English}");

                    Console.WriteLine($"Language Marks: {student.Language}");

                    Console.WriteLine($"Social Marks: {student.SST}");

                    Console.WriteLine($"Total Marks Obtained: {student.TotalMarks}");

                    string Grade = "A";

                    double studentavg = 0;

                    studentavg = student.TotalMarks / 5;

                    if (studentavg >= 95)

                    {

                        Grade = "A";

                    }

                    else if (studentavg >= 80)

                    {

                        Grade = "B";

                    }

                    else if (studentavg >= 70)

                    {

                        Grade = "C";

                    }

                    else if (studentavg >= 60)

                    {

                        Grade = "D";

                    }

                    else if (studentavg >= 50)

                    {

                        Grade = "E";

                    }

                    else

                    {

                        Grade = "F";

                    }



                    Console.WriteLine($"Grade Achived {Grade}");

                }



            }

        }

    }











    class Program

    {

        static void Main(string[] args)

        {

            ScoreCard t = new ScoreCard();

            t.getDetails();

            t.Details();

            t.Gettinggrade();

            Console.WriteLine("Enter the Roll Number:");

            int roll = Convert.ToInt16(Console.ReadLine());

            t.Scorescard(roll);

        }

    }

}