using Akavache;
using ScormToolkitCore.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;

namespace ScormToolkitCore.Service
{

    public class DataStore : IPersistantDataStore
    {
        public IObservable<T> Get<T>(string key)
        {
            return BlobCache.LocalMachine.GetObject<T>(key);
        }

        public IObservable<IDictionary<string, T>> Get<T>(List<string> keys)
        {
            return BlobCache.LocalMachine.GetObjects<T>(keys);
        }

        public IObservable<IEnumerable<T>> GetAll<T>()
        {
            return BlobCache.LocalMachine.GetAllObjects<T>();
        }

        public IObservable<T> GetCachedAndFetchTask<T>(string key, Func<Task<T>> fetchFunc, Func<DateTimeOffset, bool> condition = null, DateTimeOffset? expDate = null)
        {
            return BlobCache.LocalMachine.GetAndFetchLatest(key, fetchFunc, condition, expDate);
        }

        public IObservable<T> GetCachedAndFetch<T>(string key, Func<IObservable<T>> fetchFunc, Func<DateTimeOffset, bool> condition = null, DateTimeOffset? expDate = null, bool invalidateOnError = false)
        {
            return BlobCache.LocalMachine.GetAndFetchLatest(key, fetchFunc, condition, expDate, invalidateOnError);
        }

        public IObservable<Unit> Set<T>(string key, T data)
        {
            return BlobCache.LocalMachine.InsertObject(key, data);
        }

        public IObservable<Unit> Set<T>(IDictionary<string, T> dict)
        {
            return BlobCache.LocalMachine.InsertObjects(dict);
        }

        IObservable<Unit> IPersistantDataStore.Set<T>(string key, T data)
        {
            throw new NotImplementedException();
        }

        IObservable<Unit> IPersistantDataStore.Set<T>(IDictionary<string, T> dict)
        {
            throw new NotImplementedException();
        }
    }
}
