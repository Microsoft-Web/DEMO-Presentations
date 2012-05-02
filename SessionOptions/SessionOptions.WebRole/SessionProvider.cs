using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionOptions.WebRole
{
	public class SessionProvider : System.Web.SessionState.SessionStateStoreProviderBase
	{
		public override System.Web.SessionState.SessionStateStoreData CreateNewStoreData(HttpContext context, int timeout)
		{
			throw new NotImplementedException();
		}

		public override void CreateUninitializedItem(HttpContext context, string id, int timeout)
		{
			throw new NotImplementedException();
		}

		public override void Dispose()
		{
			throw new NotImplementedException();
		}

		public override void EndRequest(HttpContext context)
		{
			throw new NotImplementedException();
		}

		public override System.Web.SessionState.SessionStateStoreData GetItem(HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out System.Web.SessionState.SessionStateActions actions)
		{
			throw new NotImplementedException();
		}

		public override System.Web.SessionState.SessionStateStoreData GetItemExclusive(HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out System.Web.SessionState.SessionStateActions actions)
		{
			throw new NotImplementedException();
		}

		public override void InitializeRequest(HttpContext context)
		{
			throw new NotImplementedException();
		}

		public override void ReleaseItemExclusive(HttpContext context, string id, object lockId)
		{
			throw new NotImplementedException();
		}

		public override void RemoveItem(HttpContext context, string id, object lockId, System.Web.SessionState.SessionStateStoreData item)
		{
			throw new NotImplementedException();
		}

		public override void ResetItemTimeout(HttpContext context, string id)
		{
			throw new NotImplementedException();
		}

		public override void SetAndReleaseItemExclusive(HttpContext context, string id, System.Web.SessionState.SessionStateStoreData item, object lockId, bool newItem)
		{
			throw new NotImplementedException();
		}

		public override bool SetItemExpireCallback(System.Web.SessionState.SessionStateItemExpireCallback expireCallback)
		{
			throw new NotImplementedException();
		}
	}
}