using System;
using UnityEngine;

namespace PublicArt
{
    [Serializable]
    public class PublicArtRecord
    {
        public string siteName;
        public string type;
        public Vector2 latLong;

        public override string ToString()
        {
            return $"{siteName} {type} {latLong}";
        }
    }
}