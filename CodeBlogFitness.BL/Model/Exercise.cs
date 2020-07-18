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
        private DateTime begin;
        private DateTime end;

        public DateTime Start { get;}

        public DateTime Finish { get; }
        public Activity Activity { get; }
        public User User { get; }

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
