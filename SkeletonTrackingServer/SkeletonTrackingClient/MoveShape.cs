using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Add reference
using SignalR.Hubs;


namespace SkeletonTrackingClient
{
    // Derive from Hub, which is a server-side class
    // and a client side proxy.
    [HubName("moveShape")]  // moveShape is the name used in the Javascript
    public class MoveShapeHub : Hub
    {
        public void MoveShape(dynamic rightHand, dynamic leftHand)
        {
            // Broadcast to clients to move shape
            Clients.shapeMoved(Context.ConnectionId, rightHand, leftHand);
        }
    }
}