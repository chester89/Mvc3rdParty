using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Mvc3rdParty.Data.Conventions {
    public class CustomIdConvention: IIdConvention {
        public void Apply(IIdentityInstance instance) {
            instance.Column("Id");
        }
    }
}
