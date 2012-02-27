using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Mvc3rdParty.Data.Conventions {
    public class CustomCascadeConvention: IHasManyConvention 
    {
        public void Apply(IOneToManyCollectionInstance instance) 
        {
            instance.Cascade.SaveUpdate();
        }
    }

    public class CustomMany2ManyCascadeConvention: IHasManyToManyConvention
    {
        public void Apply(IManyToManyCollectionInstance instance)
        {
            instance.Cascade.All();
        }
    }
}
