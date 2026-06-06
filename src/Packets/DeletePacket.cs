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

    public float globalPosX { get; set; }
    public float globalPosY { get; set; }
    public float globalPosZ { get; set; }
    

    /// <inheritdoc />
    public override CommunicationPacket? Process()
    {
        return null;
    }
}