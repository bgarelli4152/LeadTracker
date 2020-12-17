using LeadTracker.Data.Entities;
using LeadTracker.Models;
using LeadTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Services
{
    public class RepService
    {
        public bool CreateRep(RepCreate model)
        {
            var entity =
                new Rep()
                {
                    Name = model.Name,
                    Email = model.Email,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reps.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
     
        public IEnumerable<RepDetail> GetReps()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reps
                        //.Where(e => e.ID == _userId)
                        .Select(
                            e =>
                                new RepDetail
                                {
                                    ID = e.ID,
                                    Name = e.Name,
                                    Email = e.Email,
                                }
                        );

                return query.ToArray();
            }
        }
        
        public RepDetail GetRepByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reps//Will need changed on GitHub
                        .Single(e => e.ID == id); //&& e.OwnerId == _userId);
                return
                    new RepDetail
                    {
                        ID = entity.ID,
                        Name = entity.Name,
                        Email = entity.Email,
                    };
            }
        }
        
        public bool UpdateRep(RepDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reps//will need changed on GitHub
                        .Single(e => e.ID == model.ID);// && e.OwnerId == _userId);
                entity.Name = model.Name;
                entity.Email = model.Email;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteRep(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reps
                        .Single(e => e.ID == id);// && e.OwnerId == _userId);

                ctx.Reps.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
