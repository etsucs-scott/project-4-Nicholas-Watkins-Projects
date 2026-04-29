using System;
using System.Collections.Generic;
using System.Text;

// NOT IN USE due to time restriction

namespace Project4.Core // NEED TO COMMENT MORE
{
    /// <summary>
    /// Saves to file class
    /// </summary>
    public class Saver
    {
        private string saveFilePath = "..\\..\\..\\..\\..\\clipData.csv";
        public Dictionary<string, List<string>> savedClips { get; private set; } = new Dictionary<string, List<string>>();

        /// <summary>
        /// Retrieve the data from the default saveFilePath and puts it into the savedClips dictionary
        /// </summary>
        public void RetrieveData()
        {
            if (!File.Exists(saveFilePath)) // File has to exist... Should work on later
            {
                throw (new Exception());
            }

            string[] clips = File.ReadAllLines(saveFilePath);
            foreach (string clip in clips)
            {
                string[] clipInfo = clip.Split(",");
                List<string> clipInfoList = clipInfo.ToList();
                clipInfoList.RemoveAt(0);
                savedClips[clipInfo[0]] = clipInfoList;
            }
        }

        /// <summary>
        /// Saves the data from savedclips to a file (saveFilePath)
        /// </summary>
        public void SaveData()
        {
            File.Delete(saveFilePath); // Refreshs file with save data
            File.Create(saveFilePath);
            File.WriteAllText(saveFilePath, "path,percentage,\"decisecondsToPlay (100 = 1 second, 6000 = 1 minute, 360000 = 1 hour)\"\n");

            foreach (string clip in savedClips.Keys.ToList())
            {
                File.AppendAllText(saveFilePath, $"{clip},");
                foreach (string clipInfo in savedClips[clip])
                {
                    File.AppendAllText(saveFilePath, $"{clipInfo},");
                }
                File.AppendAllText(saveFilePath, Environment.NewLine);
            }
        }

        /// <summary>
        /// Add saved data to the dictionary using the name of the clip and list of clip data in string
        /// </summary>
        /// <param name="name">name of the clip</param>
        /// <param name="data">clip data converted to string</param>
        public void AddData(string name, List<string> data)
        {
            savedClips.Add(name, data);
        }

        /// <summary>
        /// Removes the data from teh savedClips dictionary based off the name
        /// </summary>
        /// <param name="name">name of clip with data</param>
        public void RemoveData(string name) 
        {
            savedClips.Remove(name);
        }
    }
}
