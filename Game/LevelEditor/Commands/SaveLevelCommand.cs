using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using XMLExtendedSerialization;
using GameLogic;
using System.Xml.Linq;

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
                doc = XMLSerializerEx.Serialize(_level, "GameLevel");
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
