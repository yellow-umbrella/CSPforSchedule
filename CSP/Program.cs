using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace CSP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CSP.Professor> professors;
            List<CSP.Subject> subjects;
            List<CSP.Group> groups;
            int rooms;
            
            SetReqSmall1();

            CSP csp = new CSP();
            DateTime start = DateTime.Now;
            WriteResult(csp.Perform(groups, professors, rooms));
            DateTime end = DateTime.Now;
            Console.WriteLine(end - start);

            void SetReq()
            {
                rooms = 8;

                professors = new List<CSP.Professor>()
                {
                    new CSP.Professor("p1", 7),
                    new CSP.Professor("p2", 6),
                    new CSP.Professor("p3", 12),
                    new CSP.Professor("p4", 10),
                    new CSP.Professor("p5", 7),
                    new CSP.Professor("p6", 5),
                    new CSP.Professor("p7", 11),
                    new CSP.Professor("p8", 12),
                    new CSP.Professor("p9", 9),
                    new CSP.Professor("p10", 10),
                    new CSP.Professor("p11", 11),
                    new CSP.Professor("p12", 13),
                };

                subjects = new List<CSP.Subject>()
                {
                    new CSP.Subject("s1", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1],
                        professors[2],
                        professors[3],
                        professors[4],
                        professors[5],
                        professors[6],
                        professors[7],
                        professors[8],
                        professors[9],
                        professors[10],
                        professors[11],
                    }),
                    new CSP.Subject("s2", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1],
                        professors[2],
                        professors[3],
                        professors[4],
                        professors[5],
                        professors[6],
                        professors[7],
                        professors[8],
                        professors[9],
                        professors[10],
                        professors[11],
                    }),
                    new CSP.Subject("s3", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1],
                        professors[2],
                        professors[3],
                        professors[4],
                        professors[5],
                        professors[6],
                        professors[7],
                        professors[8],
                        professors[9],
                        professors[10],
                        professors[11],
                    }),
                    new CSP.Subject("s4", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1],
                        professors[2],
                        professors[3],
                        professors[4],
                        professors[5],
                        professors[6],
                        professors[7],
                        professors[8],
                        professors[9],
                        professors[10],
                        professors[11],
                    }),
                    new CSP.Subject("s5", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1],
                        professors[2],
                        professors[3],
                        professors[4],
                        professors[5],
                        professors[6],
                        professors[7],
                        professors[8],
                        professors[9],
                        professors[10],
                        professors[11],
                    }),
                    new CSP.Subject("s6", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1],
                        professors[2],
                        professors[3],
                        professors[4],
                        professors[5],
                        professors[6],
                        professors[7],
                        professors[8],
                        professors[9],
                        professors[10],
                        professors[11],
                    }),
                    new CSP.Subject("s7", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1],
                        professors[2],
                        professors[3],
                        professors[4],
                        professors[5],
                        professors[6],
                        professors[7],
                        professors[8],
                        professors[9],
                        professors[10],
                        professors[11],
                    }),
                    new CSP.Subject("s8", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1],
                        professors[2],
                        professors[3],
                        professors[4],
                        professors[5],
                        professors[6],
                        professors[7],
                        professors[8],
                        professors[9],
                        professors[10],
                        professors[11],
                    }),
                    new CSP.Subject("s9", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1],
                        professors[2],
                        professors[3],
                        professors[4],
                        professors[5],
                        professors[6],
                        professors[7],
                        professors[8],
                        professors[9],
                        professors[10],
                        professors[11],
                    }),
                    new CSP.Subject("s10", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1],
                        professors[2],
                        professors[3],
                        professors[4],
                        professors[5],
                        professors[6],
                        professors[7],
                        professors[8],
                        professors[9],
                        professors[10],
                        professors[11],
                    }),
                    new CSP.Subject("s11", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1],
                        professors[2],
                        professors[3],
                        professors[4],
                        professors[5],
                        professors[6],
                        professors[7],
                        professors[8],
                        professors[9],
                        professors[10],
                        professors[11],
                    }),
                    new CSP.Subject("s12", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1],
                        professors[2],
                        professors[3],
                        professors[4],
                        professors[5],
                        professors[6],
                        professors[7],
                        professors[8],
                        professors[9],
                        professors[10],
                        professors[11],
                    }),
                    new CSP.Subject("s13", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1],
                        professors[2],
                        professors[3],
                        professors[4],
                        professors[5],
                        professors[6],
                        professors[7],
                        professors[8],
                        professors[9],
                        professors[10],
                        professors[11],
                    }),
                    new CSP.Subject("s14", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1],
                        professors[2],
                        professors[3],
                        professors[4],
                        professors[5],
                        professors[6],
                        professors[7],
                        professors[8],
                        professors[9],
                        professors[10],
                        professors[11],
                    }),
                };

                groups = new List<CSP.Group>()
                {
                    new CSP.Group("g1", new List<CSP.SubjectTime>()
                    {
                        new CSP.SubjectTime(subjects[0], 3),
                        new CSP.SubjectTime(subjects[1], 4),
                        new CSP.SubjectTime(subjects[2], 2),
                        new CSP.SubjectTime(subjects[3], 5),
                    }),
                    new CSP.Group("g2", new List<CSP.SubjectTime>()
                    {
                        new CSP.SubjectTime(subjects[4], 1),
                        new CSP.SubjectTime(subjects[5], 3),
                        new CSP.SubjectTime(subjects[6], 4),
                        new CSP.SubjectTime(subjects[7], 2),
                        new CSP.SubjectTime(subjects[8], 4),
                    }),
                    new CSP.Group("g3", new List<CSP.SubjectTime>()
                    {
                        new CSP.SubjectTime(subjects[1], 2),
                        new CSP.SubjectTime(subjects[5], 3),
                        new CSP.SubjectTime(subjects[6], 4),
                        new CSP.SubjectTime(subjects[9], 1),
                        new CSP.SubjectTime(subjects[10], 3),
                    }),
                    new CSP.Group("g4", new List<CSP.SubjectTime>()
                    {
                        new CSP.SubjectTime(subjects[10], 2),
                        new CSP.SubjectTime(subjects[11], 3),
                        new CSP.SubjectTime(subjects[9], 3),
                        new CSP.SubjectTime(subjects[3], 2),
                    }),
                    new CSP.Group("g5", new List<CSP.SubjectTime>()
                    {
                        new CSP.SubjectTime(subjects[2], 1),
                        new CSP.SubjectTime(subjects[5], 3),
                        new CSP.SubjectTime(subjects[7], 4),
                        new CSP.SubjectTime(subjects[8], 2),
                    }),
                    new CSP.Group("g6", new List<CSP.SubjectTime>()
                    {
                        new CSP.SubjectTime(subjects[0], 3),
                        new CSP.SubjectTime(subjects[1], 3),
                        new CSP.SubjectTime(subjects[6], 1),
                        new CSP.SubjectTime(subjects[7], 4),
                    }),
                    new CSP.Group("g7", new List<CSP.SubjectTime>()
                    {
                        new CSP.SubjectTime(subjects[1], 1),
                        new CSP.SubjectTime(subjects[2], 3),
                        new CSP.SubjectTime(subjects[4], 2),
                        new CSP.SubjectTime(subjects[10], 4),
                        new CSP.SubjectTime(subjects[11], 1),
                    }),
                    new CSP.Group("g8", new List<CSP.SubjectTime>()
                    {
                        new CSP.SubjectTime(subjects[0], 1),
                        new CSP.SubjectTime(subjects[3], 3),
                        new CSP.SubjectTime(subjects[5], 1),
                        new CSP.SubjectTime(subjects[7], 2),
                        new CSP.SubjectTime(subjects[9], 1),
                    }),
                    new CSP.Group("g9", new List<CSP.SubjectTime>()
                    {
                        new CSP.SubjectTime(subjects[2], 2),
                        new CSP.SubjectTime(subjects[4], 2),
                        new CSP.SubjectTime(subjects[6], 1),
                        new CSP.SubjectTime(subjects[8], 2),
                        new CSP.SubjectTime(subjects[10], 2),
                        new CSP.SubjectTime(subjects[11], 2),
                    }),
                    new CSP.Group("g10", new List<CSP.SubjectTime>()
                    {
                        new CSP.SubjectTime(subjects[1], 1),
                        new CSP.SubjectTime(subjects[3], 2),
                        new CSP.SubjectTime(subjects[5], 1),
                        new CSP.SubjectTime(subjects[6], 2),
                        new CSP.SubjectTime(subjects[7], 1),
                        new CSP.SubjectTime(subjects[8], 2),
                        new CSP.SubjectTime(subjects[1], 2),
                    }),
                };
            }

            void SetReqSmall()
            {
                rooms = 2;
                professors = new List<CSP.Professor>()
                {
                    new CSP.Professor("p1", 14),
                    new CSP.Professor("p2", 6),
                };
                subjects = new List<CSP.Subject>()
                {
                    new CSP.Subject("s1", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1],
                    }),
                    new CSP.Subject("s2", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1],
                    }),
                    new CSP.Subject("s3", new List<CSP.Professor>()
                    {
                        professors[1],
                    }),
                };

                groups = new List<CSP.Group>()
                {
                    new CSP.Group("g1", new List<CSP.SubjectTime>()
                    {
                        new CSP.SubjectTime(subjects[0], 3),
                        new CSP.SubjectTime(subjects[1], 4),
                    }),
                    new CSP.Group("g2", new List<CSP.SubjectTime>()
                    {
                        new CSP.SubjectTime(subjects[0], 3),
                        new CSP.SubjectTime(subjects[1], 4),
                    }),
                    new CSP.Group("g3", new List<CSP.SubjectTime>()
                    {
                        new CSP.SubjectTime(subjects[0], 2),
                        new CSP.SubjectTime(subjects[2], 4),
                    }),
                };
            }

            void SetReqSmall1()
            {
                rooms = 2;
                professors = new List<CSP.Professor>()
                {
                    new CSP.Professor("p1", 7),
                    new CSP.Professor("p2", 7),
                };
                subjects = new List<CSP.Subject>()
                {
                    new CSP.Subject("s1", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1],
                    }),
                    new CSP.Subject("s2", new List<CSP.Professor>()
                    {
                        professors[0],
                    }),
                };

                groups = new List<CSP.Group>()
                {
                    new CSP.Group("g1", new List<CSP.SubjectTime>()
                    {
                        new CSP.SubjectTime(subjects[0], 3),
                        new CSP.SubjectTime(subjects[1], 4),
                    }),
                    new CSP.Group("g2", new List<CSP.SubjectTime>()
                    {
                        new CSP.SubjectTime(subjects[0], 4),
                        new CSP.SubjectTime(subjects[1], 3),
                    }),
                };
            }

            void WriteResult(List<CSP.Lesson>[] schedule)
            {
                string dir = "results";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string path = Path.Combine(dir, "schedule.txt");

                if (schedule == null)
                {
                    File.WriteAllText(path, "NO SCHEDULE\n");
                    return;
                }
                File.WriteAllText(path, "SCHEDULE\n");

                using (StreamWriter outputFile = new StreamWriter(path, true))
                {
                    for (int t = 0; t < CSP.HOURS_PER_WEEK; t++)
                    {
                        if (t % CSP.HOURS_PER_DAY == 0) outputFile.WriteLine("----------------");
                        outputFile.WriteLine("{0}.{1} : ", t / CSP.HOURS_PER_DAY + 1, t % CSP.HOURS_PER_DAY + 1);
                        schedule[t].ForEach(x => outputFile.WriteLine("{0} - {1} - {2}",
                                                x.group.name, x.subject.name, x.professor.name));
                    }
                }
            }
        }


    }
}
