using System;
using System.Collections.Generic;
using System.Text;
using FluentFTP;
using System.IO;

namespace ftpNodAntivirus
{
    class Client
    {

        /**
         *Настройки FTP подключения
         */
        private string ftpHost = "";
        private int ftpPort = 21;
        private string ftpUser = "";
        private string ftpPwd = "";

        /**
         * Папка с файлами которые нужно передать на сервер FTP
         */
        private string sourceFolder = "D:\\ob\\nod_upd\\";

        public void Upload()
        {
            FtpClient ftp = new FtpClient(ftpHost, ftpPort, ftpUser, ftpPwd);

            ftp.Connect();

            /**
             * Удаляем все файлы на FTP
             */
            foreach (FtpListItem item in ftp.GetListing())
            {
                if (item.Type == FtpFileSystemObjectType.File)
                {
                    Console.WriteLine("Удаляю: " + item.FullName);

                    ftp.DeleteFile(item.FullName);
                }
            }

            if (!Directory.Exists(sourceFolder))
            {
                return;
            }

            /**
             * Обход локального каталога и загрузка файлов на FTP
             */
            foreach (string file in Directory.GetFiles(sourceFolder))
            {
                Console.WriteLine("Отправляю: " + file);

                string fileName = Path.GetFileName(file);

                ftp.UploadFile(file, $"/{fileName}");
            }

            ftp.Disconnect();
        }
    }
}
