using System.Collections.Generic;

namespace Forgery.DataStructures.Models
{
    public class Animation
    {
        public List<AnimationFrame> Frames { get; private set; }

        public Animation()
        {
            Frames = new List<AnimationFrame>();
        }
    }
}