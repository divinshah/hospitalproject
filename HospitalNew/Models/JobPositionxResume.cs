namespace HospitalNew.Models
{
    public class JobPositionxResume
    {
        public int JobID { get; set; }
        public JobPosition JobPosition { get; set; }

        public int ResumeID { get; set; }
        public Resume Resume { get; set; }
    }
}