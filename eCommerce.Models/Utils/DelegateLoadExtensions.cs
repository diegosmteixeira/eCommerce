using System.Runtime.CompilerServices;

namespace eCommerce.Models.Utils
{
    public static class DelegateLoadExtensions
    {
        public static TRelated Load<TRelated>(
            this Action<object, string> loader,
            object entity,
            ref TRelated navigationField,
            [CallerMemberName] string navigationName = null)
            where TRelated : class
            {
                loader?.Invoke(entity, navigationName);

                return navigationField;
            }
    }
}