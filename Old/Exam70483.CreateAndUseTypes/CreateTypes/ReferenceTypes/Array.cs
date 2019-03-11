namespace Exam70483.CreateAndUseTypes.CreateTypes.ReferenceTypes
{
    // arrays are reference types
    internal class Array
    {
        public void Average()
        {
            const int numberOfStudents = 4;
            int[] scores = new int[numberOfStudents];

            int totalScore = 0;

            // can use foreach as Array implements IEnumerable
            foreach (int score in scores)
            {
                totalScore += score;
            }

            var averageScore = (double) totalScore / scores.Length;
        }
    }
}