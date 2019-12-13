using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using UnityEngine;

namespace Fumbbl
{
    public class Settings
    {
        public GraphicsSettings Graphics;
        public SoundSettings Sound;

        public Settings()
        {
            Graphics = new GraphicsSettings();
            Sound = new SoundSettings();
        }
        public void Save()
        {
            string jsonSettings = JsonConvert.SerializeObject(this);
            string path = Path.Combine(Application.persistentDataPath, "Settings.json");
            File.WriteAllText(path, jsonSettings);
        }

        public void Load()
        {
            string path = Path.Combine(Application.persistentDataPath, "Settings.json");

            if (File.Exists(path))
            {
                string jsonSettings = File.ReadAllText(path);

                Settings settings = JsonConvert.DeserializeObject<Settings>(jsonSettings);
                this.Graphics = settings.Graphics;
                this.Sound = settings.Sound;
            }
            else
            {
                Save();
            }
        }
    }

    public class GraphicsSettings
    {
        public bool AbstractIcons = false;
    }

    public class SoundSettings
    {
        public bool Mute = false;
        public float GlobalVolume = 1f;
    }
}
