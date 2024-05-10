using System;

namespace DailySchedule
{
    public class Schedule
    {
        public int nextId = 1;

        public int Id { get; private set; }

        public string Assignment { get; set; }
        public string DueDate { get; set; }
        public bool Completed { get; set; }



        public Schedule()
        {
            this.Id = nextId++;

        }





    }
}