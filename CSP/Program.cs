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
            
            SetReq();
            CSP csp = new CSP();
            WriteResult(csp.Perform(groups, professors, rooms));

            void SetReq()
            {
                rooms = 3;

                professors = new List<CSP.Professor>()
                {
                    new CSP.Professor("p1", 7),
                    new CSP.Professor("p2", 7)
                };

                subjects = new List<CSP.Subject>()
                {
                    new CSP.Subject("s1", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1]
                    }),
                    new CSP.Subject("s2", new List<CSP.Professor>()
                    {
                        professors[0],
                        professors[1]
                    })
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
