using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TestWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Student> GetAllStudent()
        {
            List<Student> list = new List<Student>();
            using (db5ba730478f594a8c890aa55700666a55Entities context = new db5ba730478f594a8c890aa55700666a55Entities())
            {
                list = context.Students.ToList();
            }
            return list;
        }


        public Student GetOneStudent(int id)
        {
            Student s = null;
            using (db5ba730478f594a8c890aa55700666a55Entities context = new db5ba730478f594a8c890aa55700666a55Entities())
            {
                s = context.Students.Where(c => c.StudentID == id).FirstOrDefault();
            }
            return s;
        }

        public void UpdateStudent(Student student)
        {
            int result = 0;
            using (db5ba730478f594a8c890aa55700666a55Entities context = new db5ba730478f594a8c890aa55700666a55Entities())
            {
                Student s = GetOneStudent(student.StudentID);
                if (s != null)
                {
                    context.Entry(s).CurrentValues.SetValues(student);
                    result = context.SaveChanges();
                }
            }
            //return result > 0;
        }

        public void CreateStudent(Student student)
        {
            int result = 0;

            using (db5ba730478f594a8c890aa55700666a55Entities context = new db5ba730478f594a8c890aa55700666a55Entities())
            {
                context.Students.Add(student);
                result = context.SaveChanges();
            }
            //return result > 0;
        }

        public void DeleteStudent(int id)
        {
            int result = 0;
            using (db5ba730478f594a8c890aa55700666a55Entities context = new db5ba730478f594a8c890aa55700666a55Entities())
            {
                Student s = GetOneStudent(id);
                if (s != null)
                {
                    context.Students.Remove(s);
                    result = context.SaveChanges();
                }
            }
            //return result > 0;
        }
    }


}
