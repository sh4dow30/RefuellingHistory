using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sh4dow.RefuellingHistory.Models
{
    public class EntityBase
    {
    }

    public static class EntityExtensions
    {
        public static ObjectContext GetContext(this IEntityWithRelationships entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var relationshipManager = entity.RelationshipManager;

            var relatedEnd = relationshipManager.GetAllRelatedEnds()
                                                .FirstOrDefault();

            if (relatedEnd == null)
                throw new Exception("No relationships found");

            var query = relatedEnd.CreateSourceQuery() as ObjectQuery;

            if (query == null)
                throw new Exception("The Entity is Detached");

            return query.Context;
        }

        public static DbContext GetDbContextFromEntity(this EntityBase entity)
        {
            var object_context = GetObjectContextFromEntity(entity);

            if (object_context == null)
                return null;

            return new DbContext(object_context, dbContextOwnsObjectContext: false);
        }

        private static ObjectContext GetObjectContextFromEntity(object entity)
        {
            var field = entity.GetType().GetField("_entityWrapper");

            if (field == null)
                return null;

            var wrapper = field.GetValue(entity);
            var property = wrapper.GetType().GetProperty("Context");
            var context = (ObjectContext)property.GetValue(wrapper, null);

            return context;
        }
    }
}
