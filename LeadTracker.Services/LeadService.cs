using LeadTracker.Data;
using LeadTracker.Data.Entities;
using LeadTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Services
{
    public class LeadService
    {
        public bool CreateLead(LeadCreate model)
        {
            var entity =
                new Lead()
                {
                    Name = model.Name,
                    Company = model.Company,
                    Phone = model.Phone,
                    Email = model.Email,
                    Converted = model.Converted
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Leads.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
     
        public IEnumerable<LeadListItem> GetLeads()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Leads
                        //.Where(e => e.ID == _userId)
                        .Select(
                            e =>
                                new LeadListItem
                                {
                                    ID = e.ID,
                                    Name = e.Name,
                                    Company = e.Company,
                                    Phone = e.Phone,
                                    Email = e.Email,
                                    Converted = e.Converted
                                }
                        );

                return query.ToArray();
            }
        }
        
        public LeadDetail GetLeadByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Leads
                        .Single(e => e.ID == id); //&& e.OwnerId == _userId);
                return
                    new LeadDetail
                    {
                        ID = entity.ID,
                        Name = entity.Name,
                        Company = entity.Company,
                        Phone = entity.Phone,
                        Email = entity.Email,
                        Converted = entity.Converted
                    };
            }
        }
        
        public bool UpdateLead(LeadEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Leads
                        .Single(e => e.ID == model.ID);// && e.OwnerId == _userId);
                entity.Name = model.Name;
                entity.Company = model.Company;
                entity.Phone = model.Phone;
                entity.Email = model.Email;
                entity.Converted = model.Converted;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteLead(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Leads
                        .Single(e => e.ID == id);// && e.OwnerId == _userId);

                ctx.Leads.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
