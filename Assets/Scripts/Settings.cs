using Newtonsoft.Json;
using System.IO;
using UnityEngine;

namespace Fumbbl
{
    public class Settings
    {
        public ColorSettings Color;
        public GraphicsSettings Graphics;
        public SoundSettings Sound;
        public DebugSettings Debug;

        public Settings()
        {
            Color = new ColorSettings();
            Graphics = new GraphicsSettings();
            Sound = new SoundSettings();
            Debug = new DebugSettings();
        }

        public void Load()
        {
            string path = Path.Combine(Application.persistentDataPath, "Settings.json");

            if (File.Exists(path))
            {
                string jsonSettings = File.ReadAllText(path);

                Settings settings = JsonConvert.DeserializeObject<Settings>(jsonSettings);
                // Load default colors until panel is made.
                // this.Color = settings.Color;
                this.Graphics = settings.Graphics;
                this.Sound = settings.Sound;
                this.Debug = settings.Debug;
            }
            else
            {
                Save();
            }
        }

        public void Save()
        {
            string jsonSettings = JsonConvert.SerializeObject(this);
            string path = Path.Combine(Application.persistentDataPath, "Settings.json");
            File.WriteAllText(path, jsonSettings);
        }
    }

    public class ColorSettings
    {
        public string HomeColor = "#B10000";
        public string AwayColor = "#000AB3";
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

    public class DebugSettings
    {
        public Fumbbl.LogLevel LogLevel = LogLevel.INFO;
    }
}
