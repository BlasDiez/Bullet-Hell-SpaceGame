using Patterns.Adapter;
using UnityEngine;

namespace Patterns.Strategy
{
    public class Consumer
    {
        private readonly IDataStore _dataStore;

        public Consumer(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void Save()
        {
            var data = new Data("hola", 4545);
            _dataStore.SetData(data, "data2");
        }
        
        public void Load()
        {
            var data = _dataStore.GetData<Data>("data2");
            Debug.Log(data.dato1);
            Debug.Log(data.dato2);
        }
    }
}