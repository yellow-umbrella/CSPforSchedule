using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP
{
    internal class CSP
    {
        public const int DAYS = 5;
        public const int HOURS_PER_DAY = 3;
        public const int HOURS_PER_WEEK = DAYS * HOURS_PER_DAY;

        public class Professor
        {
            public string name { get; private set; }
            private int targetedTime;
            private bool[] used;

            public Professor(string name, int time) { 
                targetedTime = time;
                used = new bool[HOURS_PER_WEEK];
                this.name = name;
            }

            public void Reset(int t)
            {
                used[t] = false;
            }

            public bool Set(int t)
            {
                if (used[t]) { return false; }
                if (GetCurrentTime() == targetedTime) { return false; }
                used[t] = true;
                return true;
            }

            private int GetCurrentTime()
            {
                int time = 0;
                foreach (bool t in used)
                {
                    if (t) time++;
                }
                return time;
            }

            public bool CheckEndConstraints()
            {
                return (targetedTime == GetCurrentTime());
            }
        }

        public class Subject
        {
            public List<Professor> Professors { get; private set; }
            public string name { get; private set; }

            public Subject(string name, List<Professor> professors)
            {
                Professors = professors;
                this.name = name;
            }
        }

        public class SubjectTime
        {
            public Subject Subject { get; private set; }
            public int TargetedTime { get; private set; }
            public int CurrentTime { get; set; }
            public SubjectTime(Subject subject, int time)
            {
                Subject = subject;
                TargetedTime = time;
            }
        }

        public class Group
        {
            public string name { get; private set; }
            public List<SubjectTime> Subjects { get; private set; }
            private int[] used;

            public Group(string name, List<SubjectTime> subjects) {
                this.Subjects = subjects;
                used = new int[HOURS_PER_WEEK];
                for (int i = 0; i < HOURS_PER_WEEK; i++)
                {
                    used[i] = -1;
                }
                this.name = name;
            }

            public void Reset(int t)
            {
                if (used[t] != -1)
                {
                    Subjects[used[t]].CurrentTime--;
                    used[t] = -1;
                }
            }

            public bool Set(int t, int subInd)
            {
                if (used[t] != -1) { return false; }
                if (Subjects[subInd].TargetedTime == 
                    Subjects[subInd].CurrentTime) { return false; }

                used[t] = subInd;
                Subjects[subInd].CurrentTime++;

                return true;
            }

            public bool IsUsed(int t)
            {
                return used[t] != -1;
            }

            public bool CheckEndConstraints()
            {
                foreach (var sub in Subjects)
                {
                    if (sub.TargetedTime != sub.CurrentTime)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public struct Lesson
        {
            public Subject subject;
            public Professor professor;
            public Group group;

            public override string ToString()
            {
                return group.name + "-" + subject.name + "-" + professor.name;
            }
        }


        private int rooms;

        private List<Group> groups;
        private List<Professor> professors;

        private List<Lesson>[] schedule;

        public List<Lesson>[] Perform(List<Group> groups, List<Professor> professors, int rooms)
        {
            this.groups = groups;
            this.professors = professors;
            this.rooms = rooms;

            schedule = new List<Lesson>[HOURS_PER_WEEK];
            for (int t = 0; t < HOURS_PER_WEEK; t++)
            {
                schedule[t] = new List<Lesson>();
            }

            if (Iterate(-1, -1, -1, 0, 0))
            {
                return schedule;
            }

            return null;
        }

        private bool Iterate(int t, int rInd, int rMax, int minG, int nextTimeStartG)
        {
            if (t == HOURS_PER_WEEK) 
            { 
                return CheckEndConstraints(); 
            }

            if (CheckEndConstraints())
            {
                return true;
            }

            if (rInd == rMax)
            {
                for (int i = rooms; i > 0; i--)
                {
                    if (Iterate(t + 1, 0, i, nextTimeStartG, nextTimeStartG))
                    {
                        return true;
                    }
                }
                return false;
            }


            for (int gInd = minG; gInd < groups.Count; gInd++)
            {
                if (groups[gInd].IsUsed(t)) { continue; }
                Lesson lesson;
                lesson.group = groups[gInd];
                for (int subInd = 0; subInd < lesson.group.Subjects.Count; subInd++)
                {
                    lesson.subject = lesson.group.Subjects[subInd].Subject;
                    if (lesson.group.Set(t, subInd))
                    {
                        foreach (Professor professor in lesson.subject.Professors)
                        {
                            lesson.professor = professor;
                            if (lesson.professor.Set(t))
                            {
                                schedule[t].Add(lesson);
                                Log("Add: t=" + t.ToString() + " rInd=" + rInd.ToString() + " rMax=" + rMax.ToString() + " : " + lesson.ToString());
                                int next = nextTimeStartG;
                                if (rInd == 0)
                                {
                                    next = gInd;
                                }
                                if (Iterate(t, rInd + 1, rMax, gInd + 1, next)) { return true; }
                                lesson.professor.Reset(t);
                                Log("Remove: t=" + t.ToString() + " rInd=" + rInd.ToString() + " rMax=" + rMax.ToString() + " : " + schedule[t][rInd].ToString());
                                schedule[t].RemoveAt(rInd);
                            }
                        }
                        lesson.group.Reset(t);
                    }
                }
            }

            return false;
        }

        private bool CheckEndConstraints()
        {
            foreach (Group group in groups)
            {
                if (!group.CheckEndConstraints()) return false;
            }
            foreach (Professor professor in professors)
            {
                if (!professor.CheckEndConstraints()) return false;
            }
            return true;
        }

        private void Log(string message)
        {
            string dir = "results";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string path = Path.Combine(dir, "log.txt");

            using (StreamWriter outputFile = new StreamWriter(path, true))
            {
                outputFile.WriteLine(message);
            }
        }
    }
}
