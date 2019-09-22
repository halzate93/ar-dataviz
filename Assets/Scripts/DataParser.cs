using System.Collections.Generic;
using LitJson;
using UnityEngine;

namespace PublicArt
{
    public class DataParser : MonoBehaviour
    {
        public TextAsset sourceFile;
        public List<PublicArtRecord> records;
        private JsonData recordsRaw;

        private static PublicArtRecord FromJsonData(JsonData json)
        {
            return new PublicArtRecord
            {
                type = json.ContainsKey("sitename") ? (string)json["type"] : null,
                siteName = json.ContainsKey("sitename") ? (string)json["sitename"] : null,
                latLong = json.ContainsKey("geom")? new Vector2((float)(double)json["geom"]["coordinates"][0], (float)(double)json["geom"]["coordinates"][1]) : new Vector2()
            };
        }

        private void Awake()
        {
            Debug.Log("Awake");
            recordsRaw = JsonMapper.ToObject(sourceFile.text)["records"];
            records = new List<PublicArtRecord> (recordsRaw.Count);
            for (int i = 0; i < recordsRaw.Count; i++)
            {
                records.Add (FromJsonData (recordsRaw[i]["fields"]));
                Debug.Log(records[i]);
            }
        }
    }
}