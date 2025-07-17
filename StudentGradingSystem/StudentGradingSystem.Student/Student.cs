namespace StudentGradingSystem.Information
{
    public class Student
    {
       public string name;
        public int ID;
        public int[] scores = new int[5];
        
        public Student(string name, int id, int[] scores )
        {
            this.name = name;
            this.ID = id;
            this.scores = (int[]) scores.Clone(); // copy the elements and convert the resulting array
        }
    }
}
