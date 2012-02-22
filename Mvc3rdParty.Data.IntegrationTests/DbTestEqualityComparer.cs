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
            Func<Type, bool> filter = type => !type.IsValueType && type != typeof (string);

            if (new [] { x.GetType(), y.GetType() }.All(filter) && y.GetType().IsInstanceOfType(x))
            {
                dynamic X = x;
                dynamic Y = y;
                return X.Id == Y.Id;
            }
            return x.Equals(y);
        }

        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }
    }
}