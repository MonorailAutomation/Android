using static monorail_android.Database.Track;
using static monorail_android.RestRequests.Endpoints.Monarch.Q2Goals;
using static monorail_android.RestRequests.Endpoints.Monarch.Token;

namespace monorail_android.RestRequests.Helpers
{
    public static class TrackHelperFunctions
    {
        public static void RemoveTrack(string username, string trackName)
        {
            var token = GenerateToken(username);
            var trackId = GetTrackId(username, trackName);
            DeleteTrack(token, trackId);
        }
    }
}