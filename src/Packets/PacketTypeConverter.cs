using System;
using HorusMod.Enums;
using HorusMod.Packets;
using Nuclei.CritzOS.Features.IPC.Packets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nuclei.CritzOS.Features.IPC;

/// <summary>
/// Json converter for handling packets.
/// </summary>
public class PacketTypeConverter : JsonConverter
{
    /// <inheritdoc />
    public override bool CanConvert(Type objectType)
    {
        return typeof(CommunicationPacket).IsAssignableFrom(objectType);
    }

    /// <inheritdoc />
    public override object ReadJson(JsonReader reader,
        Type objectType,
        object? existingValue,
        JsonSerializer serializer)
    {
        var jo = JObject.Load(reader);
        var type = jo["type"]!.ToObject<PacketType>();
        CommunicationPacket? packet;

        switch (type)
        {
            case PacketType.Spawn:
                packet = new SpawnPacket();
                break;
            case PacketType.Delete:
                packet = new DeletePacket();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        serializer.Populate(jo.CreateReader(), packet);
        return packet;
    }

    /// <inheritdoc />
    public override void WriteJson(JsonWriter writer,
        object? value,
        JsonSerializer serializer)
    {
        var packet = (CommunicationPacket)value!;
        writer.WriteStartObject();
        
        writer.WritePropertyName("type");
        serializer.Serialize(writer, packet.type.ToString().ToLower());
        
        switch (packet)
        {
            case DeletePacket log:
                writer.WritePropertyName("originX");
                serializer.Serialize(writer, log.originX);
                writer.WritePropertyName("originY");
                serializer.Serialize(writer, log.originY);
                writer.WritePropertyName("originZ");
                serializer.Serialize(writer, log.originZ);
                writer.WritePropertyName("destinationX");
                serializer.Serialize(writer, log.destinationX);
                writer.WritePropertyName("destinationY");
                serializer.Serialize(writer, log.destinationY);
                writer.WritePropertyName("destinationZ");
                serializer.Serialize(writer, log.destinationZ);
                break;
            case SpawnPacket log:
                writer.WritePropertyName("unitName");
                serializer.Serialize(writer, log.unitName);
                writer.WritePropertyName("globalPosX");
                serializer.Serialize(writer, log.globalPosX);
                writer.WritePropertyName("globalPosY");
                serializer.Serialize(writer, log.globalPosY);
                writer.WritePropertyName("globalPosZ");
                serializer.Serialize(writer, log.globalPosZ);
                writer.WritePropertyName("rotationX");
                serializer.Serialize(writer, log.rotationX);
                writer.WritePropertyName("rotationY");
                serializer.Serialize(writer, log.rotationX);
                writer.WritePropertyName("rotationZ");
                serializer.Serialize(writer, log.rotationX);
                writer.WritePropertyName("rotationW");
                serializer.Serialize(writer, log.rotationX);
                writer.WritePropertyName("factionName");
                serializer.Serialize(writer, log.factionName);
                writer.WritePropertyName("uniqueName");
                serializer.Serialize(writer, log.uniqueName);
                break;
        }

        writer.WriteEndObject();
    }    
}