using StudentGradingSystem.Information;
using System.ComponentModel.DataAnnotations;
namespace StudentGradingSystem.InputGrades
{
    internal class Program
    {
        static void Main ( string[] args )
        {
            Console.WriteLine("Enter the number of students");
            string input = Console.ReadLine();
            int noOfStd = int.Parse(input);

            Student[] students = new Student[noOfStd];
            for ( int i = 0; i < students.Length; i++ )
            {
                Console.WriteLine($"Enter name of student {i+1}");
                string name = Console.ReadLine();

                Console.WriteLine($"Enter ID of student {i+1}");
                String IdInput = Console.ReadLine();
                int ID = int.Parse(IdInput);

                Console.WriteLine($"Enter 5 scores for the student {i+1}");
                int[] scores = inputScore();

                students[i] = new Student(name, ID, scores);
            }


            // print the informations for the students

            double maxStdAvg = computeAvg(students[0].scores);
            double minStdAvg = computeAvg(students[0].scores);

            double totalStudentsAvg = 0;
            int noOfPassed = 0;
            int noOfFailed = 0;

            foreach ( Student student in students )
            {
                double avg = computeAvg(student.scores);
                if ( avg > maxStdAvg )
                    maxStdAvg = avg;

                if ( avg < minStdAvg )
                    minStdAvg = avg;

                totalStudentsAvg += avg;

                string statusRes = status(avg);
                if ( statusRes == "fail" )
                    noOfFailed++;
                else
                    noOfPassed++;


                Console.WriteLine($"""
                                    student name: {student.name}
                                    ID: {student.ID}
                                    scores: {returnScores(student.scores)}
                                    Avg: {avg}
                                    status: {statusRes}
                                    """
                    );

            }
            Console.WriteLine("-----------------------------");

            Console.WriteLine($"""
                the total average of all students: {totalStudentsAvg / noOfStd}
                highest Avg: {maxStdAvg}
                lowest Avg: {minStdAvg}
                number of passed students: {noOfPassed}
                number of failed students: {noOfFailed}
                """);
          
        }


        static int[] inputScore ()
        {
            int[] scores = new int[5];
            for ( int i = 0; i < scores.Length; i++ )
            {
                string input = Console.ReadLine();
                scores[i] = int.Parse(input);
            }
            return scores;
        }


        static double computeAvg ( int[] scores )
        {
            double sum = 0;
            for ( int i = 0; i < scores.Length; i++ )
            {
                sum += scores[i];
            }
            return sum / 5;
        }


        static string returnScores ( int[] scores )
        {
            string output = "";
            for ( int i = 0; i < scores.Length; i++ )
            {
                output += scores[i] + " ";
            }
            return output; }
    

    static string status ( double avg )
        {
            if ( avg >= 85 )

                return "pass & excellent";
            else if ( avg >= 60 )
                return "pass";
            else
                return "fail";

        } }
}
