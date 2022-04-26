using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace ScormToolkitCore.Contracts
{
    public interface IPersistantDataStore
    {
        IObservable<T> Get<T>(string key);
        IObservable<IDictionary<string, T>> Get<T>(List<string> keys);
        IObservable<IEnumerable<T>> GetAll<T>();
        IObservable<T> GetCachedAndFetchTask<T>(string key, Func<Task<T>> fetchFunc, Func<DateTimeOffset, bool> condition = null, DateTimeOffset? expDate = null);
        IObservable<T> GetCachedAndFetch<T>(string key, Func<IObservable<T>> fetchFunc, Func<DateTimeOffset, bool> condition = null, DateTimeOffset? expDate = null, bool invalidateOnError = false);
        IObservable<Unit> Set<T>(string key, T data);
        IObservable<Unit> Set<T>(IDictionary<string, T> dict);
    }

}
