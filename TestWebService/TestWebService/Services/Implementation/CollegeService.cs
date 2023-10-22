using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TestWebService.Data;
using TestWebService.Models;
using TestWebService.Services.Interface;

namespace TestWebService.Services.Implementation
{
    //This service will be use to make transactions to the College table in the database
    public class CollegeService : ICollegeService
    {
        private TestWebServiceContext _dbContext;
        
        public CollegeService(TestWebServiceContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public int AddCollege(College college)
        {
            //INSERT INTO
            _dbContext.Colleges.Add(college);
            return _dbContext.SaveChanges();
        }

        public int ActivateCollege(int ID)
        {
            //UPDATE College SET IsActive = true WHERE CollegeID = ID
            College toDeactivate = GetCollege(ID);
            toDeactivate.IsActive = true;
            //mark entry for modification
            _dbContext.Entry(toDeactivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeactivateCollege(int ID)
        {
            //UPDATE College SET IsActive = false WHERE CollegeID = ID
            College toDeactivate = GetCollege(ID);
            toDeactivate.IsActive = false;
            //mark entry for modification
            _dbContext.Entry(toDeactivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteCollege(int ID)
        {
            //DELETE FROM College WHERE CollegeID = ID
            College toDelete = GetCollege(ID);
            _dbContext.Entry(toDelete).State = EntityState.Deleted;      //mark the record as deleted
            return _dbContext.SaveChanges();
        }

        public College GetCollege(int ID)
        {
            //SELECT * FROM College WHERE CollegeID = ID                                          //SQL query
            //tracking of IDs are not required when retrieving records
            return _dbContext.Colleges.AsNoTracking().Where(c => c.CollegeID == ID).SingleOrDefault();         //LINQ (Language INtegrated Query)
        }

        public College GetCollege(string collegeName)
        {
            //SELECT * FROM College WHERE CollegeName = college.CollegeName
            //tracking of IDs are not required when retrieving records
            return _dbContext.Colleges.AsNoTracking().Where(c => c.CollegeName == collegeName).SingleOrDefault();
        }

        public IQueryable<College> GetColleges()
        {
            //SELECT * FROM College WHERE IsActive = true                       //SQL query
            return _dbContext.Colleges.Where(c => c.IsActive == true);          //LINQ (Language INtegrated Query)
        }

        public IQueryable<College> GetInactiveColleges()
        {
            //SELECT * FROM College WHERE IsActive = false                       //SQL query
            return _dbContext.Colleges.Where(c => c.IsActive == false);          //LINQ (Language INtegrated Query)
        }

        public bool IsCollegeExist(College college)
        {
            //SELECT * FROM College WHERE CollegeName = college.CollegeName
            //tracking of IDs are not required when retrieving records
            College toCheck = _dbContext.Colleges.AsNoTracking().Where(c => c.CollegeName == college.CollegeName).SingleOrDefault();
            return (toCheck != null);
        }

        public int UpdateCollege(College college)
        {
            //UPDATE College SET CollegeName = college.CollegeName, CollegeCode = college.CollegeCode WHERE IsActive = true
            _dbContext.Entry(college).State = EntityState.Modified;         //mark the record as modified
            return _dbContext.SaveChanges();
        }
    }
}