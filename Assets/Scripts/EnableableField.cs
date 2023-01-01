using System;

namespace EnterKratos
{
    [Serializable]
    public class EnableableField<T>
    {
        public bool enabled;
        public T value;
    }
}