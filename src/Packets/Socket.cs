using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NuclearOption.Networking.Lobbies;

namespace HorusMod.Packets;

public static class Socket
{
    public static async Task SendAsync(string json)
    {
        try
        {
            HorusPlugin.Logger.LogInfo($"SOCKET SENDASYNC() - IN SERVER '{GetServerName()}'\nTrying to send packet...");
            var port = GetServerPort();
            HorusPlugin.Logger.LogInfo($"Got port {port}");
            
            if (port == -1)
            {
                HorusPlugin.Logger.LogError("Server not valid");
                return;
            }
            using var client = new TcpClient();
            await client.ConnectAsync("10.0.0.9", port);
            NetworkStream stream = client.GetStream();

            var data = Encoding.UTF8.GetBytes(json + "\n");
            try
            {
                await stream.WriteAsync(data, 0, data.Length);
                await stream.FlushAsync();
                HorusPlugin.Logger.LogInfo("packet sent");
            }
            catch (Exception ex)
            {
                HorusPlugin.Logger.LogWarning(
                    $"[IPC] send json failed: {json} ({ex.Message})");
            }
        }
        catch (Exception e)
        {
            HorusPlugin.Logger.LogError(e);
        }
    }

    private static string GetServerName()
    {
        return SteamLobby.instance.CurrentLobbyName;
    }
    private static int GetServerPort()
    {
        var lobbyName = SteamLobby.instance.CurrentLobbyName;
        if (lobbyName.StartsWith("[US PVE1] CritzOS"))
        {
            return 7780;
        }
        if (lobbyName.StartsWith("[US PVE2] CritzOS"))
        {
            return 7680;
        }
        if (lobbyName.StartsWith("[US PVE3] CritzOS"))
        {
            return 7980;
        }
        if (lobbyName.StartsWith("[US PVE4] CritzOS"))
        {
            return 7080;
        }
        if (lobbyName.StartsWith("[US PVE5] CritzOS"))
        {
            return 7880;
        }
        if (lobbyName.StartsWith("[US MODDED] CritzOS"))
        {
            return 7280;
        }

        return -1;
    }
}