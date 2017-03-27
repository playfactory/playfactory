using PlayFactory.Exceptions;

namespace PlayFactory.Common
{
    public static class Check
    {
        public static void NotNull(object obj, string name)
        {
            if (obj == null)
                throw new NotNullException($"Value of {name} is Null.");
        }
    }
}
