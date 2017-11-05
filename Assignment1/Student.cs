namespace Assignment1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }

        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Student s = (Student)obj;
            return (Jmbag == s.Jmbag);
        }

        public override int GetHashCode() => Jmbag.GetHashCode();

        public static bool operator ==(Student s1, Student s2)
        {
            return s1 != null && s1.Jmbag.Equals(s2?.Jmbag);
        }

        public static bool operator !=(Student s1, Student s2)
        {
            return !(s1 == s2);
        }
    }
    public enum Gender
    {
        Male, Female
    }
}