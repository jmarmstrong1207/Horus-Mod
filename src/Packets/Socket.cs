using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HorusMod.Packets;

public static class Socket
{
    public static async Task SendAsync(string json)
    {
        try
        {
            HorusPlugin.Logger.LogInfo("Trying to send spawn packet...");
            using var client = new TcpClient();
            await client.ConnectAsync("10.0.0.9", 8777);
            NetworkStream stream = client.GetStream();

            var data = Encoding.UTF8.GetBytes(json + "\n");
            try
            {
                await stream.WriteAsync(data, 0, data.Length);
                await stream.FlushAsync();
                HorusPlugin.Logger.LogInfo("Spawn packet sent");
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
}