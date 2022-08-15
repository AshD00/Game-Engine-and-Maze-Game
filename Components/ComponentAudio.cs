using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenGL_Game.Managers;
using OpenTK.Audio.OpenAL;
using OpenTK;

namespace OpenGL_Game.Components
{
    /// <summary>
    /// The component class for audio.
    /// Controls looping, pausing, playing and stopping of audio, as well as the position.
    /// </summary>
    class ComponentAudio : IComponent
    {
        int audioBuffer;
        int audioSource;

        public ComponentAudio(string sourceName, bool loop)
        {
            // Setup Audio Source from the Audio Buffer
            audioBuffer = ResourceManager.LoadAudio(sourceName);
            audioSource = AL.GenSource();
            AL.Source(audioSource, ALSourcei.Buffer, audioBuffer); // attach the buffer to a source
            if (loop)
            {
                AL.Source(audioSource, ALSourceb.Looping, true); // source loops infinitely
            }
        }
        public ComponentTypes ComponentType
        {
            get { return ComponentTypes.COMPONENT_AUDIO; }
        }
        public void SetPosition(Vector3 emitterPosition)
        {
            AL.Source(audioSource, ALSource3f.Position, ref emitterPosition);
        }

        public void CloseAudio()
        {
            AL.SourceStop(audioSource);
            AL.DeleteSource(audioSource);
            AL.DeleteBuffer(audioBuffer);
        }

        public void PlayAudio()
        {
            AL.SourcePlay(audioSource);
        }
        public void PauseAudio()
        {
            AL.SourceStop(audioSource);
        }
    }
}
