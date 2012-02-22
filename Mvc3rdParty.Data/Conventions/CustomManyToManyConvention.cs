using System;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions;

namespace Mvc3rdParty.Data.Conventions {
    public class CustomManyToManyConvention : ManyToManyTableNameConvention {
        private const string Delimiter = "To";

        protected override String GetBiDirectionalTableName(IManyToManyCollectionInspector collection, IManyToManyCollectionInspector otherSide) {
            return otherSide.EntityType.Name + Delimiter + collection.EntityType.Name;
        }

        protected override String GetUniDirectionalTableName(IManyToManyCollectionInspector collection)
        {
            return collection.EntityType.Name + Delimiter + "Related";
        }
    }
}