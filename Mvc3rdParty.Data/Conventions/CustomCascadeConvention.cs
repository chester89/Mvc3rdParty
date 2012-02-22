using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Mvc3rdParty.Data.Conventions {
    public class CustomCascadeConvention: IHasManyConvention {
        public void Apply(IOneToManyCollectionInstance instance) {
            instance.Cascade.None();
        }
    }
}
