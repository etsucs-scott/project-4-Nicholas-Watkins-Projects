using System;
using System.Collections.Generic;
using System.Text;

namespace Project4.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class Saver
    {
        private string saveFilePath = "..\\..\\..\\..\\..\\clipData.csv";
        private Dictionary<string, List<string>> savedClips = new Dictionary<string, List<string>>();
        /// <summary>
        /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public void AddData(string name, List<string> data)
        {
            savedClips.Add(name, data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void RemoveData(string name) 
        {
            savedClips.Remove(name);
        }
    }
}
