using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises_18_2018
{
    class ExerciseResult
    {
        private int id;
        private string studentName;
        private string studentIndex;
        private int points;

        public int Id { get => id; set => id = value; }
        public string StudentName { get => studentName; set => studentName = value; }
        public string StudentIndex { get => studentIndex; set => studentIndex = value; }
        public int Points { get => points; set => points = value; }
    }
}
