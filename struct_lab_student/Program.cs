using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace struct_lab_student
{
    partial class Program
    {
        static Student[] ReadData(string fileName)
        {
            int count = 0;
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (reader.ReadLine() != null)
                {
                    count++;
                }
            }
            Student[] students = new Student[count];
            StreamReader str = new StreamReader(fileName, Encoding.Default);
            string line;
            int i = 0;
            while ((line = str.ReadLine()) != null)
            {
                students[i] = new Student(line);
                i++;
            }
            str.Close();
            return students;
        }        
        static double ToValue(char symbol)
        {
            if (symbol == '-')
            {
                return 2;
            }
            else
            {
                return char.GetNumericValue(symbol);
            }
        }
        static void Average(Student[] studs) //виведення прізвищ студентів у яких 5 з інформатики + їх середній бал
        {
            double average;
            foreach (Student info in studs)
            {
                average = 0;
                if (ToValue(info.informaticsMark) == 5)
                {
                    average += (ToValue(info.mathematicsMark) + ToValue(info.physicsMark) + ToValue(info.informaticsMark)) / 3;
                    Console.WriteLine("{0}       {1}", info.surName , average.ToString("0.00"));
                }
            }
        }
        static void Main(string[] args)
        {
            Student[] studs = ReadData("data.txt");
            Console.WriteLine("Прiзвища та середнi бали студентiв, якi мають 5 з iнформатики");
            Average(studs);
            Console.ReadKey();
        }
    }
}
