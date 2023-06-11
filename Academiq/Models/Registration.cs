namespace Academiq.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Registration
    {
        public Registration()
        {
            this.Course = new HashSet<Course>();
        }

        public int Id { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> Status { get; set; }

        public virtual ICollection<Course> Course { get; set; }

        public void Cancel()
        {
            ClearAllCourses();
            Status = (int?)RegistrationStatus.Cancelled;
        }

        public void ClearAllCourses()
        {
            Course.Clear();
        }

        public void CompleteRegistration()
        {
            Status = (int?)RegistrationStatus.Completed;
        }

        public void Payment()
        {
            Status = (int?)RegistrationStatus.Paid;
        }

        internal void Pay()
        {
            Status = (int?)RegistrationStatus.Paid;
        }
    }
}
