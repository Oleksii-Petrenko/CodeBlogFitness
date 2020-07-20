using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }
        private DateTime begin;
        private DateTime end;
        
        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }

        public Exercise(DateTime begin, DateTime end, User user)
        {
            this.begin = begin;
            this.end = end;
            User = user;
        }
    }
}
