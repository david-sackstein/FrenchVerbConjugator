﻿using System.Collections.Concurrent;
using System.Text.Json.Serialization;

namespace Conjugator
{
    public class Conjugation
    {
        [JsonPropertyName("P")]
        public string[] Present { get; set; }

        [JsonPropertyName("S")]
        public string[] SubjonctifPresent { get; set; }
        
        [JsonPropertyName("Y")]
        public string[] Imperative { get; set; }
        
        [JsonPropertyName("I")]
        public string[] Imperfect { get; set; }
        
        [JsonPropertyName("G")]
        public string[] ParticipePresent { get; set; }
        
        [JsonPropertyName("K")]
        public string[] ParticiplePasse{ get; set; }
        
        [JsonPropertyName("J")]
        public string[] PasseSimple { get; set; }
        
        [JsonPropertyName("T")]
        public string[] SubjonctifImparfait { get; set; }
        
        [JsonPropertyName("F")]
        public string[] Future { get; set; }
        
        [JsonPropertyName("C")]
        public string[] Conditional { get; set; }
        
        [JsonPropertyName("W")]
        public string[] Infinitif { get; set; }
    }
}