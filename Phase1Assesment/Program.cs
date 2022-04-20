using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace FinalProj
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string teachersTxt = @"D:\Training FSD\Teachersdata.txt";
            List<Teachers> listTeachers = new List<Teachers>();
            string[] arrTeachers = System.IO.File.ReadAllLines(teachersTxt);
            foreach (string row in arrTeachers)
            {
                string[] r = row.Split(' ');
                Teachers teachers = new Teachers();
                teachers.Empid = Convert.ToInt32(r[0]);
                teachers.Empname = r[1];
                teachers.Empgrade = Convert.ToInt32(r[2]);
                teachers.Empsection = r[3];

                listTeachers.Add(teachers);
            }
            int op;
            do
            {
                Console.WriteLine("Select an Option to perform: ");
                Console.WriteLine("1.Display \n2.Update \n3.Search \n4.Sort \n5.Delete");
                Console.WriteLine("-------------");
                op = Convert.ToInt32(Console.ReadLine());

                if (op == 0)
                {

                    Console.WriteLine("Invalid Option");
                }
                switch (op)
                {

                    case 1:
                        foreach (Teachers teachers in listTeachers)
                        {
                            Console.WriteLine($"{teachers.Empid} {teachers.Empname} {teachers.Empgrade} {teachers.Empsection}");


                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter EmpId: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Grade: ");
                        int grd = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Section: ");
                        string sec = Console.ReadLine();
                        Teachers t = new Teachers();
                        t.Empid = id;
                        t.Empname = name;
                        t.Empgrade = grd;
                        t.Empsection = sec;
                        listTeachers.Add(t);
                        int count = 0;
                        string[] arr = new string[listTeachers.Count];
                        foreach (Teachers t1 in listTeachers)
                        {

                            string s = ($"{t1.Empid} {t1.Empname} {t1.Empgrade} {t1.Empsection}");
                            arr[count] = s;
                            count++;
                        }
                        File.WriteAllLines(teachersTxt, arr);

                        break;

                    case 3:
                        Console.Write("Enter EmpId To search: ");
                        int eid = Convert.ToInt32(Console.ReadLine());
                        bool found = false;
                        foreach (Teachers te in listTeachers)
                        {

                            if (te.Empid == eid)
                            {

                                Console.WriteLine($"{te.Empid} {te.Empname} {te.Empgrade} {te.Empsection}");
                                found = true;
                            }
                        }

                        if (!found)
                        {

                            Console.WriteLine("EmpId not Found ");
                        }
                        break;
                    case 4:
                        var namesort = from el in listTeachers
                                       orderby el.Empname, el.Empgrade, el.Empsection, el.Empid
                                       select el;
                        foreach (var dt in namesort)
                        {
                            Console.WriteLine($"{dt.Empid} {dt.Empname} {dt.Empgrade} {dt.Empsection}");
                        }
                        break;
                    case 5:
                        Console.Write("Enter EmpId To Delete: ");
                        int emid = Convert.ToInt32(Console.ReadLine());
                        found = false;
                        foreach (Teachers te in listTeachers.ToList())
                        {


                            if (te.Empid == emid)
                            {

                                listTeachers.Remove(te);
                            }
                        }
                        int count2 = 0;
                        string[] arr2 = new string[listTeachers.Count];
                        foreach (Teachers t1 in listTeachers)
                        {

                            string s = ($"{t1.Empid} {t1.Empname} {t1.Empgrade} {t1.Empsection}");
                            arr2[count2] = s;
                            count2++;
                        }
                        File.WriteAllLines(teachersTxt, arr2);
                        break;
                    default:
                        Console.WriteLine("Invalid Operation");
                        break;
                }
                Console.WriteLine("---------------------");
            }
            while (op != 0);


        }
    }
}

