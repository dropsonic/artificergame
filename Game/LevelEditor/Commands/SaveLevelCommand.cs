using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using XMLExtendedSerialization;
using GameLogic;
using System.Xml.Linq;
using FarseerTools;
using System.Windows.Forms;

namespace LevelEditor.Commands
{
    /// <summary>
    /// Делегат для метода обратного вызова в случае, если файл с таким именем уже существует.
    /// </summary>
    public delegate DialogResult FileExistsDelegate(string fileName);

    public class SaveLevelCommand : ICommand
    {
        private string _fileName;
        private GameLevel _level;
        private FileExistsDelegate _fileExistsCallback;

        /// <summary>
        /// Конструктор для случая "Save As"
        /// </summary>
        /// <param name="fileName">Полное имя файла для сохранения.</param>
        /// <param name="level">Уровень.</param>
        /// <param name="fileExitsCallback">Функция обратного вызова для случая, если один из файлов уже существует.</param>
        public SaveLevelCommand(string fileName, GameLevel level, FileExistsDelegate fileExistsCallback)
        {
            _fileName = fileName;
            _level = level;
            _fileExistsCallback = fileExistsCallback;
        }

        /// <summary>
        /// Конструктор для случая "Save"
        /// </summary>
        public SaveLevelCommand(string fileName, GameLevel level)
        {
            _fileName = fileName;
            _level = level;
            _fileExistsCallback = null;
        }

        public void Execute()
        {
            XDocument doc;
            try
            {
                XMLSerializerEx serializer = new XMLSerializerEx(new List<IXMLCustomSerializer> { 
                    new RenderTarget2DXMLSerializer(), new WorldXMLSerializer(), new BodyXMLSerializer(), new FixtureXMLSerializer() });
                doc = serializer.Serialize(_level, "GameLevel"); //сохраняет текстуры в temp-папку
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
                string currentPath = Path.GetDirectoryName(_fileName) + "\\";
                if (Directory.Exists(TextureSerializerSettings.FilePath))
                {
                    string[] files = Directory.GetFiles(TextureSerializerSettings.FilePath);
                    foreach (string file in files)
                    {
                        string newFileName = string.Concat(currentPath, Path.GetFileName(file));
                        //Если файл с таким именем уже существует, то вызываем метод обратного вызова
                        if (File.Exists(newFileName))
                        {
                            if (_fileExistsCallback != null)
                            {
                                DialogResult dResult = _fileExistsCallback(newFileName);
                                if (dResult == DialogResult.No)
                                {
                                    File.Delete(file);
                                    continue;
                                }
                                if ((dResult == DialogResult.Cancel) || (dResult == DialogResult.Abort))
                                {
                                    //Возвращаем всё к состоянию до сохранения
                                    File.Delete(_fileName);
                                    foreach (string file_ in files)
                                        File.Delete(file_);
                                    Directory.Delete(TextureSerializerSettings.FilePath);
                                    return;
                                }
                            }

                            File.Delete(newFileName);
                        }

                        File.Move(file, newFileName);
                    }

                    //Удаляем временную директорию из-под текстур
                    Directory.Delete(TextureSerializerSettings.FilePath);
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
