﻿using System;
using Forgery.BspEditor.Primitives.MapObjects;
using Forgery.Common.Transport;

namespace Forgery.BspEditor.Primitives
{
    public abstract class StandardMapElementFormatter<T> : IMapElementFormatter
    {
        protected virtual string Name => typeof(T).Name;

        public bool IsSupported(IMapElement obj)
        {
            return obj?.GetType() == typeof(T);
        }

        public SerialisedObject Serialise(IMapElement elem)
        {
            return elem.ToSerialisedObject();
        }

        public bool IsSupported(SerialisedObject elem)
        {
            return elem.Name == Name;
        }

        public IMapElement Deserialise(SerialisedObject obj)
        {
            return (IMapElement) Activator.CreateInstance(typeof(T), obj);
        }
    }
}