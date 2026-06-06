using HorusMod.Enums;
using Nuclei.CritzOS.Features.IPC.Packets;
using UnityEngine;

namespace HorusMod.Packets;

/// <summary>
/// Return packet for the response to a command.
/// </summary>
public class SpawnPacket: CommunicationPacket
{
    public override PacketType type { get; set; } = PacketType.Spawn;
    public override CommunicationPacket Process()
    {
        return null;
    }

    public string unitName { get; set; } 
    
    public float globalPosX { get; set; } 
    public float globalPosY { get; set; } 
    public float globalPosZ { get; set; } 
    
    public float rotationX { get; set; } 
    public float rotationY { get; set; } 
    public float rotationZ { get; set; } 
    public float rotationW { get; set; } 

    public string factionName { get; set; }

    public string uniqueName { get; set; } = "";
}