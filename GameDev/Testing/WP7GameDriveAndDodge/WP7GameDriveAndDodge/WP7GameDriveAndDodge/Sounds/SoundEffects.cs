using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace WP7GameDriveAndDodge.Sounds
{
    public class SoundEffects
    {
        private ContentManager content;
        Dictionary<string, SoundEffect> sounds = new Dictionary<string, SoundEffect>();

        public SoundEffects(ContentManager contentManager)
        {
            content = contentManager;
        }

        public void PlaySound(string sound)
        {
            if (!sounds.ContainsKey(sound))
                sounds.Add(sound, content.Load<SoundEffect>(sound));
            sounds[sound].Play();
        }
    }
}