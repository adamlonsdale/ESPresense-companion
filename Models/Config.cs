﻿using Newtonsoft.Json;
using TextExtensions;
using YamlDotNet.Serialization;

namespace ESPresense.Models
{
    public class Config
    {
        [YamlMember(Alias = "mqtt")]
        public ConfigMqtt? Mqtt { get; set; }

        [YamlMember(Alias = "bounds")]
        public double[][]? Bounds { get; set; }

        [YamlMember(Alias = "timeout")]
        public long Timeout { get; set; } = 30;

        [YamlMember(Alias = "away_timeout")]
        public long AwayTimeout { get; set; } = 120;

        [YamlMember(Alias = "gps")]
        public ConfigGps? Gps { get; set; }


        [YamlMember(Alias = "floors")]
        public ConfigFloor[]? Floors { get; set; }

        [YamlMember(Alias = "nodes")]
        public ConfigNode[]? Nodes { get; set; }

        [YamlMember(Alias = "devices")]
        public ConfigDevice[]? Devices { get; set; }

        [YamlMember(Alias = "weighting")]
        public ConfigWeighting? Weighting { get; set; }
    }

    public class ConfigWeighting
    {
        [YamlMember(Alias = "algorithm")]
        public string Algorithm { get; set; } = "gaussian";

        [YamlMember(Alias = "props")]
        public Dictionary<string, double>? Props { get; set; }
    }

    public class ConfigGps
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Elevation { get; set; }
    }

    public partial class ConfigMqtt
    {
        [JsonProperty("host")]
        public string? Host { get; set; }

        [JsonProperty("port")]
        public int? Port { get; set; }

        [JsonProperty("ssl")]
        public bool? Ssl { get; set; }

        [JsonProperty("username")]
        public string? Username { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("client_id")]
        [YamlMember(Alias = "client_id")]
        public string ClientId { get; set; } = "espresense-companion";
    }

    public class ConfigDevice
    {
        [YamlMember(Alias = "name")]
        public string? Name { get; set; }

        [YamlMember(Alias = "id")]
        public string? Id { get; set; }

        public string GetId() => Id ?? Name?.ToSnakeCase()?.ToLower() ?? "none";
    }

    public class ConfigFloor
    {
        [YamlMember(Alias = "id")]
        public string? Id { get; set; }

        [YamlMember(Alias = "name")]
        public string? Name { get; set; }

        [YamlMember(Alias = "bounds")]
        public double[][]? Bounds { get; set; }

        [YamlMember(Alias = "rooms")]
        public ConfigRoom[]? Rooms { get; set; }

        public string GetId() => Id ?? Name?.ToSnakeCase()?.ToLower() ?? "none";
    }

    public class ConfigRoom
    {
        [YamlMember(Alias = "id")]
        public string? Id { get; set; }

        [YamlMember(Alias = "name")]
        public string? Name { get; set; }

        [YamlMember(Alias = "points")]
        public double[][]? Points { get; set; }

        public string GetId() => Id ?? Name?.ToSnakeCase()?.ToLower() ?? "none";
    }

    public class ConfigNode
    {
        [YamlMember(Alias = "name")]
        public string? Name { get; set; }

        [YamlMember(Alias = "id")]
        public string? Id { get; set; }

        [YamlMember(Alias = "point")]
        public double[]? Point { get; set; }

        [YamlMember(Alias = "floors")]
        public string[]? Floors { get; set; }

        [YamlMember(Alias = "enabled")]
        public bool Enabled { get; set; } = true;

        [YamlMember(Alias = "stationary")]
        public bool Stationary { get; set; } = true;

        public string GetId() => Id ?? Name?.ToSnakeCase()?.ToLower() ?? "none";
    }
}
