namespace HospitalNew.Models
{
    public class HospitalxJobPosition
    {
        public int HospitalID { get; set; }
        public Hospital Hospital { get; set; }

        public int JobID { get; set; }
        public JobPosition JobPosition { get; set; }
    }
}