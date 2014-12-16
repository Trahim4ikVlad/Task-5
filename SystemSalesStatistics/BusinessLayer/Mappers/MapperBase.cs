﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
        public abstract class MapperBase<TFirst, TSecond>
        {
            public abstract TFirst Map(TSecond element);
            public abstract TSecond Map(TFirst element);
            
            public List<TFirst> Map(IEnumerable<TSecond> elements, Action<TFirst> callback = null)
            {
                var objectCollection = new List<TFirst>();
                if (elements != null)
                {
                    foreach (TSecond element in elements)
                    {
                        TFirst newObject = Map(element);
                        if (newObject != null)
                        {
                            if (callback != null)
                                callback(newObject);
                            objectCollection.Add(newObject);
                        }
                    }
                }
                return objectCollection;
            }
            public List<TSecond> Map(IEnumerable<TFirst> elements, Action<TSecond> callback = null)
            {
                var objectCollection = new List<TSecond>();

                if (elements != null)
                {
                    foreach (TFirst element in elements)
                    {
                        TSecond newObject = Map(element);
                        if (newObject != null)
                        {
                            if (callback != null)
                                callback(newObject);
                            objectCollection.Add(newObject);
                        }
                    }
                }
                return objectCollection;
            }
        }
}
