using System.Collections.Concurrent;

namespace MyWineCellar.Helpers
{
	public sealed class Session
	{
		private readonly ConcurrentDictionary<string, object> _session;
		private static Session _instance = new Session();
		public static Session Instance => _instance ?? (_instance = new Session());

		public Session() => this._session = new ConcurrentDictionary<string, object>();

		public T Get<T>(string key) where T : class
		{
			if (this._session.TryGetValue(key, out object resultValue) && resultValue is T resultValueAsT)
			{
				return resultValueAsT;
			}
			return default;
		}

		public bool Add<T>(string key, T value) => this._session.TryAdd(key, value);

		public bool Update<T>(string key, T newValue)
		{
			if (this._session.TryGetValue(key, out object currentValue) && currentValue is T currentValueAsT)
			{
				return this._session.TryUpdate(key, newValue, currentValueAsT);
			}
			return false;
		}

		public bool Delete<T>(string key) => this._session.TryRemove(key, out object value);

		public bool IsExist(string key) => this._session.ContainsKey(key);
	}
}