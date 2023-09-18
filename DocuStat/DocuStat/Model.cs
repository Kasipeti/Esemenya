using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuStat
{
    public class Model
    {
        private string _filePath;
        public string FileContent { get; private set; }
        public Dictionary<string, int> DistinctWordCount { get; private set; }
        //Konstruktor
        public Model(string filePath) 
        {
            _filePath = filePath;
            FileContent = string.Empty;
            DistinctWordCount = new Dictionary<string, int>();
        }
        public void Load() 
        {
           FileContent= File.ReadAllText(_filePath);
            ComputDistincWords();

        }
        private void ComputDistincWords()
        {
            DistinctWordCount.Clear();
            string[] words= FileContent.Split().Where(s=> s.Length>0).ToArray();
            for (int i= 0; i < words.Length; i++) 
            {
                words[i] = string.Concat(words[i]
                    .SkipWhile(c=> !char.IsLetter(c)).
                    Reverse()
                    .SkipWhile(c => !char.IsLetter(c)).
                    Reverse()
                    );
                if (string.IsNullOrEmpty( words[i]))
                {
                    continue;
                }
                words[i] = words[i].ToLower();
                if (DistinctWordCount.ContainsKey(words[i]))
                {
                    ++DistinctWordCount[words[i]];
                }
                else
                {
                    DistinctWordCount.Add(words[i], 1);
                }
            }

        }
    }
}
