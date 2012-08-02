using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using XMLExtendedSerialization;
using GameLogic;
using System.Xml.Linq;
using FarseerTools;

namespace LevelEditor.Commands
{
    public class SaveLevelCommand : ICommand
    {
        private string _fileName;
        private GameLevel _level;

        public SaveLevelCommand(string fileName, GameLevel level)
        {
            _fileName = fileName;
            _level = level;
        }

        public void Execute()
        {
            XDocument doc;
            try
            {
                doc = XMLSerializerEx.Serialize(_level, "GameLevel"); //сохраняет текстуры в temp-папку
            }
            catch (Exception ex)
            {
                throw new ApplicationException(String.Format("Cannot serialize game level: {0}", ex.Message), ex);
            }

            try
            {
                using (Stream stream = File.Create(_fileName))
                {
                    doc.Save(stream);
                }
                //Перемещаем текстуры в текущую папку
                string currentPath = Path.GetDirectoryName(_fileName);
                string[] files = Directory.GetFiles(TextureSerializerSettings.FilePath);
                foreach (string file in files)
                {
                    string newFileName = string.Concat(currentPath, Path.GetFileName(file));
                    File.Move(file, currentPath);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(String.Format("Cannot save file: {0}", ex.Message), ex);
            }
        }

        public string Name
        {
            get { return "SaveLevel"; }
        }
    }
}
