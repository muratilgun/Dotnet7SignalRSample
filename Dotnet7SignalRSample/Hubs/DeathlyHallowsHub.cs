using Microsoft.AspNetCore.SignalR;

namespace Dotnet7SignalRSample.Hubs;

public class DeathlyHallowsHub : Hub
{
    public Dictionary<string, int> GetRaceStatus()
    {
        return SD.DealthyHallowRace;
    }
}