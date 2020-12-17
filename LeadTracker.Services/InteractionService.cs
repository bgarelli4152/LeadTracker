using LeadTracker.Data.Entities;
using LeadTracker.Models;
using LeadTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeadTracker.Services
{
    public class InteractionService
    {
        public bool CreateInteraction(InteractionCreate model)
            {
            var entity =
                new Interaction()
                {
                    LeadID = model.LeadID,
                    RepID = model.RepID,
                    TypeOfContact = model.TypeOfContact,
                    Description = model.Description,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Interactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public List<InteractionListItem> GetInteractions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Interactions
                        //.Where(e => e.ID == _userId)
                        .Select(
                            e =>
                                new InteractionListItem
                                {
                                    InteractionID = e.InteractionID,
                                    Lead = e.Lead,
                                    Rep = e.Rep,
                                    LeadID = e.LeadID,
                                    RepID = e.RepID,
                                    TypeOfContact = e.TypeOfContact,
                                    Description = e.Description,
                                    CreatedUtc = e.CreatedUtc,
                                    ModifiedUtc = e.ModifiedUtc
                                }
                        );

                return query.ToList();
            }
        }

        public InteractionDetail GetInteractionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Interactions
                        .Single(e => e.InteractionID == id);
                        //.Single(e => e.ID == id && e.OwnerId == _userId);
                return
                    new InteractionDetail
                    {
                        InteractionID = entity.InteractionID,
                        Lead = entity.Lead,
                        Rep = entity.Rep,
                        TypeOfContact = entity.TypeOfContact,
                        Description = entity.Description,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateInteraction(InteractionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Interactions
                        .Single(e => e.InteractionID == model.InteractionID);

                entity.TypeOfContact = model.TypeOfContact;
                entity.Description = model.Description;
                entity.ModifiedUtc = model.ModifiedUtc;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteInteraction(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Interactions
                        .Single(e => e.InteractionID == id);

                ctx.Interactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
