namespace Exceptions_Homework
{
    public class SimpleMathExam : Exam
    {
        private int problemSolved;

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get
            {
                return this.problemSolved;
            }

            private set
            {
                if (value < 0)
                {
                    this.problemSolved = 0;
                }

                if (value > 10)
                {
                    this.problemSolved = 10;
                }

                this.problemSolved = value;
            }
        }

        public override ExamResult Check()
        {
            switch (this.ProblemsSolved)
            {
                case 0:
                    return new ExamResult(2, 2, 6, "Bad result: nothing done.");
                case 1:
                    return new ExamResult(4, 2, 6, "Average result: nothing done.");
                case 2:
                    return new ExamResult(6, 2, 6, "Average result: nothing done.");
            }

            return new ExamResult(0, 0, 0, "Invalid number of problems solved!");
        }
    }
}
