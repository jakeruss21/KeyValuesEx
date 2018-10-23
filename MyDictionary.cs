using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseKeyValues
{
    public struct KeyValue
    {
        public readonly string Key;
        public readonly object Value;

        public KeyValue(string Key, object Value)
        {
            this.Key = Key;
            this.Value = Value;
        }
    }

    class MyDictionary
    {
        KeyValue[] array = new KeyValue[60];
        private int Counter = 1;

        public object this[string Key1]
        {
            get
            {
                if (Counter < 1)
                {
                    throw new KeyNotFoundException();
                }
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Key == Key1)
                    {
                        return array[i].Value;
                    }
                }
                throw new KeyNotFoundException();
            }

            set
            {
                bool isRelevant = false;
                for (int i = 0; i < Counter; i++)
                {
                    if (array[i].Key == Key1)
                    {
                        array[i] = new KeyValue(Key1, array[i].Value);
                        isRelevant = true;
                    }
                }
                if (!isRelevant)
                {
                    array[Counter + 1] = new KeyValue(Key1, value);
                }
                Counter++;
            }
        }
    }
}
