using System.Linq;
using HorusMod;
using HorusMod.Enums;
using UnityEngine;

namespace Nuclei.CritzOS.Features.IPC.Packets;

/// <summary>
/// Return packet for the response to a command.
/// </summary>
public class DeletePacket: CommunicationPacket
{
    /// <inheritdoc />
    public override PacketType type { get; set; } = PacketType.Delete;

    public float originX { get; set; }
    public float originY { get; set; }
    public float originZ { get; set; }
    public float destinationX { get; set; }
    public float destinationY { get; set; }
    public float destinationZ { get; set; }
    

    /// <inheritdoc />
    public override CommunicationPacket? Process()
    {
        return null;
    }
}