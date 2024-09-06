using Microsoft.AspNetCore.SignalR;

namespace SignalRDeathly.Hubs
{
    public class DeathlyHallowsHub : Hub
    {
        public Dictionary<string,int> GetRaceStatus()
        {
            return SD.DealthyHallowRace;
        }
    }
}
