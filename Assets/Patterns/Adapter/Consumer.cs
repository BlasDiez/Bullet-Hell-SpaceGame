using System;
using UnityEngine;

namespace Patterns.Adapter
{
    public class Consumer : MonoBehaviour
    {
        
        private FileDataStoreAdapter _fileDataStoreAdapter;
        private void Awake()
        {
            _fileDataStoreAdapter = new FileDataStoreAdapter();
            var data = new Data("Dato1", 123);
            _fileDataStoreAdapter.SetData(data, "data1");
        }


        private void Start()
        {
            var data = _fileDataStoreAdapter.GetData<Data>("Data1");
            Debug.Log(data.Dato1);
            Debug.Log(data.Dato2);
        }
    }
}