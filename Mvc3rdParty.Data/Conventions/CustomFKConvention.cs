using System;
using FluentNHibernate.Conventions;
using FluentNHibernate;

namespace Mvc3rdParty.Data.Conventions {
    public class CustomForeignKeyConvention: ForeignKeyConvention {
        protected override String GetKeyName(Member property, Type type) {
            return property == null ? type.Name + "Id": property.Name + "Id";
        }
    }
}
