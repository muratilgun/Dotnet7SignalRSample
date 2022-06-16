using Microsoft.AspNetCore.SignalR;

namespace Dotnet7SignalRSample.Hubs;

public class HouseGroupHub : Hub
{
    public static List<string> GroupsJoined { get; set; } = new List<string>();

    public async Task JoinHouse(string houseName)
    {
        if (!GroupsJoined.Contains(Context.ConnectionId+":"+houseName))
        {
            GroupsJoined.Add(Context.ConnectionId + ":" + houseName);

            await Groups.AddToGroupAsync(Context.ConnectionId, houseName);
        }
    }
    public async Task LeaveHouse(string houseName)
    {
        if (!GroupsJoined.Contains(Context.ConnectionId + ":" + houseName))
        {
            GroupsJoined.Remove(Context.ConnectionId + ":" + houseName);

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, houseName);
        }
    }
}