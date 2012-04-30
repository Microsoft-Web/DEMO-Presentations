using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Add reference
using SignalR.Hubs;


namespace CloudSignalRSample_WebRole
{
    // Derive from Hub, which is a server-side class
    // and a client side proxy.
    [HubName("moveShape")]  // moveShape is the name used in the Javascript
    public class MoveShapeHub : Hub
    {
        public void MoveShape(int x, int y)
        {
            // Broadcast to clients to move shape
            Clients.shapeMoved(Context.ConnectionId, x, y);

            // Simple diagnostics for debugging
            System.Diagnostics.Debug.WriteLine("x = " + x + ", y = " + y);
        }
    }
}