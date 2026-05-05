using System;
using System.Collections.Generic;

namespace DataClasses
{
    [Serializable]
    public class InteractionData
    {
        public string startTime;
        public int moveCount = 0;
        public int resizeCount = 0;
        public List<Interaction> interactions = new();
        public List<Interaction> moveInteractions = new();
        public List<Interaction> resizeInteractions = new();
    }

    [Serializable]
    public class Interaction
    {
        public string typeOfInteraction;
        public string interactionTime;

        public Interaction(string type)
        {
            typeOfInteraction = type;
            interactionTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
