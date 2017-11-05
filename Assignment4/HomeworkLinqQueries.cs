using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1;

namespace Assignment4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray.GroupBy(i => i).OrderBy(i => i.Key)
                .Select(i => $"Broj {i.Key} ponavlja se {i.Count()} puta")
                .ToArray();
        }
        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(uni => uni.Students.All(s => s.Gender == Gender.Male)).ToArray();
        }
        public static University[] Linq2_2(University[] universityArray)
        {
            return universityArray.Where(uni => uni.Students.Length < universityArray.Average(u => u.Students.Length)).ToArray();
        }
        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(uni => uni.Students).Distinct().ToArray();
        }
        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(uni => uni.Students.All(s => s.Gender == Gender.Male) || uni.Students.All(s => s.Gender == Gender.Female))
                    .SelectMany(uni => uni.Students).Distinct().ToArray();
        }
        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(uni => uni.Students).GroupBy(s => s)
                .Where(i => i.Count() >= 2).Select(i => i.Key).ToArray();
        }
    }
}
