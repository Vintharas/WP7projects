﻿using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace WP7GameDriveAndDodge.Sounds
{
    public class Music
    {
        private ContentManager content;
        Dictionary<string, Song> backgroundMusic = new Dictionary<string,Song>();

        public Music(ContentManager contentManager)
        {
            content = contentManager;
        }

        public void PlayBackgroundMusic(string song)
        {
            MediaPlayer.Stop();
            if (!backgroundMusic.ContainsKey(song))
                backgroundMusic.Add(song, content.Load<Song>(song));
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic[song]);
        }
    }
}