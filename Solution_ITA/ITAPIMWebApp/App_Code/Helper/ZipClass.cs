using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;


namespace PageBaseFun
{
    /// <summary>
    /// 压缩类
    /// </summary>
    public class ZipClass
    {
        public static void ZipFile(string FileToZip, string ZipedFile, int CompressionLevel, int BlockSize)
        {
            //如果文件没有找到，则报错
            if (!System.IO.File.Exists(FileToZip))
            {
                throw new System.IO.FileNotFoundException("指定要压缩的文件: " + FileToZip + " 不存在!");
            }

            System.IO.FileStream StreamToZip = new System.IO.FileStream(FileToZip, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.FileStream ZipFile = System.IO.File.Create(ZipedFile);
            ZipOutputStream ZipStream = new ZipOutputStream(ZipFile);
            ZipEntry ZipEntry = new ZipEntry("ZippedFile");
            ZipStream.PutNextEntry(ZipEntry);
            ZipStream.SetLevel(CompressionLevel);
            byte[] buffer = new byte[BlockSize];
            System.Int32 size = StreamToZip.Read(buffer, 0, buffer.Length);
            ZipStream.Write(buffer, 0, size);
            try
            {
                while (size < StreamToZip.Length)
                {
                    int sizeRead = StreamToZip.Read(buffer, 0, buffer.Length);
                    ZipStream.Write(buffer, 0, sizeRead);
                    size += sizeRead;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            ZipStream.Finish();
            ZipStream.Close();
            StreamToZip.Close();
        }

        /// <summary>
        /// 压缩目录
        /// </summary>
        /// <param name="args">数组(数组[0]: 要压缩的目录; 数组[1]: 压缩的文件名)</param>
        public static void ZipFileDictory(string[] args)
        {
            string[] filenames = Directory.GetFiles(args[0]);

            Crc32 crc = new Crc32();
            ZipOutputStream s = new ZipOutputStream(File.Create(args[1]));
            s.SetLevel(6);

            foreach (string file in filenames)
            {
                //打开压缩文件
                FileStream fs = File.OpenRead(file);

                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                ZipEntry entry = new ZipEntry(file);

                entry.DateTime = DateTime.Now;

                entry.Size = fs.Length;
                fs.Close();

                crc.Reset();
                crc.Update(buffer);

                entry.Crc = crc.Value;

                s.PutNextEntry(entry);

                s.Write(buffer, 0, buffer.Length);

            }

            s.Finish();
            s.Close();
        }

        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="FileToZip">要进行压缩的文件名</param>
        /// <param name="ZipedFile">压缩后生成的压缩文件名</param>
        public static void ZipFile(string FileToZip, string ZipedFile)
        {
            //如果文件没有找到，则报错
            if (!File.Exists(FileToZip))
            {
                throw new System.IO.FileNotFoundException("指定要压缩的文件: " + FileToZip + " 不存在!");
            }
            FileStream fs = File.OpenRead(FileToZip);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            fs.Close();

            FileStream ZipFile = File.Create(ZipedFile);
            ZipOutputStream ZipStream = new ZipOutputStream(ZipFile);
            ZipEntry ZipEntry = new ZipEntry("ZippedFile");
            ZipStream.PutNextEntry(ZipEntry);
            ZipStream.SetLevel(6);

            ZipStream.Write(buffer, 0, buffer.Length);
            ZipStream.Finish();
            ZipStream.Close();
        }
    }

    /// <summary>
    ///  解压类
    /// </summary>
    public class UnZipClass
    {
        /// <summary>
        /// 解压功能(解压压缩文件到指定目录)
        /// </summary>
        /// <param name="args">待解压的文件</param>
        /// <param name="args">指定解压目标目录</param>
        public static void UnZip(string[] args)
        {
            ZipInputStream s = new ZipInputStream(File.OpenRead(@args[0].Trim()));
            ZipEntry theEntry;
            string directoryName = Path.GetDirectoryName(@args[1].Trim());

            if (!Directory.Exists(@args[1].Trim()))
            {
                Directory.CreateDirectory(directoryName);
            }
            while ((theEntry = s.GetNextEntry()) != null)
            {

                string fileName = Path.GetFileName(theEntry.Name);

                if (fileName != String.Empty)
                {
                    FileStream streamWriter = File.Create(@args[1].Trim() + fileName);

                    int size = 2048;
                    byte[] data = new byte[2048];
                    while (true)
                    {
                        size = s.Read(data, 0, data.Length);
                        if (size > 0)
                        {
                            streamWriter.Write(data, 0, size);
                        }
                        else
                        {
                            break;
                        }
                    }

                    streamWriter.Close();
                }
            }
            s.Close();
        }
    }
}