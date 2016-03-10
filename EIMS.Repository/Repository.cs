using System;
using System.Collections.Generic;
using EIMS.Common;
using EIMS.Datalayer;
using EIMS.AuthorizationIdentity;

using System.Linq;

namespace EIMS.Repository
{

    public class Repository : IRepository
    {
        private EIMSEntitiesContext context;

        public Repository()
        {
            this.context = new EIMSEntitiesContext();
        }

        public IEnumerable<Common.Course> GetCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Common.Faculty> GetFaculties()
        {
            var dbLst = context.Faculty.ToList();
            var result = new List<Common.Faculty>();
            foreach (var item in dbLst)
            {
                var tmpFclt = new Common.Faculty() { FacultyID = item.facultyID, Name = item.Name };
                var idList = item.UniversityGroup.Select(grp => grp.groupID);

                //tmpFclt.UniversityGroup = grpList as IEnumerable<Common.UniversityGroup>;
                result.Add(tmpFclt);
            }
            return result;
        }

        public IEnumerable<Common.Room> GetRooms()
        {
            var dblst = context.Room.ToList();
            var result = new List<Common.Room>();

            return result;
        }



        public IEnumerable<Common.Subject> GetSubjects()
        {
            var dbLst = context.Subject.ToList();
            var result = new List<Common.Subject>();
            foreach (var item in dbLst)
            {
                var tmpSubj = new Common.Subject() { SubjectID = item.subjectID, SubjectName = item.subjectName };
                int arrLength = item.requirements.Length;
                var reqList = new bool[arrLength];
                for (int i = 0; i < arrLength; i++)
                {
                    reqList[i] = item.requirements[i] == 1 ? true : false;
                }
                tmpSubj.Requirements = reqList;
                result.Add(tmpSubj);
            }
            return result;
        }


        public IEnumerable<Common.UniversityGroup> GetGroups()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Common.Lesson> GetLessons()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Common.Lesson> GetLessonsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserByID(long ID)
        {
            throw new NotImplementedException();
        }
    }
}

