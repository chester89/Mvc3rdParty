using System;
using System.Collections;
using System.Linq;

namespace Mvc3rdParty.Data.IntegrationTests
{
    public class DbTestEqualityComparer : IEqualityComparer
    {
        public bool Equals(object x, object y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            
            if (new [] { x.GetType(), y.GetType() }.All(IsReferenceToOtherEntityOrCollection) && y.GetType().IsInstanceOfType(x))
            {
                dynamic X = x;
                dynamic Y = y;
                return X.Id == Y.Id;
            }
            return x.Equals(y);
        }

        //get all property types that are references to other entities or collections
        private bool IsReferenceToOtherEntityOrCollection(Type propertyType)
        {
            return !propertyType.IsValueType && propertyType != typeof (string);
        }

        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }
    }
}