using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using XMLExtendedSerialization;
using GameLogic;
using FarseerTools;

namespace LevelEditor.Commands
{
    public class OpenLevelCommand : ICommand
    {
        private string _fileName;
        private ObjectLevelManager _objectLevelManager;

        public OpenLevelCommand(string fileName, ObjectLevelManager objectLevelManager)
        {
            _fileName = fileName;
            _objectLevelManager = objectLevelManager;
        }

        public void Execute()
        {
            using (Stream stream = File.OpenRead(_fileName))
            {
                try
                {
                    XMLSerializerEx serializer = new XMLSerializerEx();
                    _objectLevelManager.GameLevel = (GameLevel)serializer.Deserialize(stream);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(String.Format("Cannot open level: {0}", ex.Message), ex);
                }
            }
        }

        public string Name
        {
            get { return "OpenLevel"; }
        }
    }
}
