using UnityEngine;

namespace Patterns.Adapter
{
    public class Consumer : MonoBehaviour
    {
        
        private IDataStore _fileDataStoreAdapter;
        private void Awake()
        {
            _fileDataStoreAdapter = new PlayerPrefsDataStoreAdapter();
            var data = new Data("Dato1", 123);
            _fileDataStoreAdapter.SetData(data, "data1");
        }
        
        private void Start()
        {
            var data = _fileDataStoreAdapter.GetData<Data>("data1");
            //Debug.Log(data.dato1);
            //Debug.Log(data.dato2);
        }
    }
}