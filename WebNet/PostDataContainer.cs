using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.IO;
using System.Web;

namespace BatchDomainTools.WebNet
{
    public class PostDataContainer
    {
        #region << Ctor >>

        public PostDataContainer(PostType arg_TypeOfQuery)
        {
            TypeOfQuery = arg_TypeOfQuery;
            this.Boundary = "-----------------------------" + DateTime.Now.Ticks.ToString("x");
            this.FileDataCollection = new List<FileData>();
            this.PostValueCollection = new PostValue();
            this.m_Encoding = Encoding.ASCII;
        }

        #endregion

        #region << Свойства >>

        public List<FileData> FileDataCollection { get; set; }

        public PostValue PostValueCollection { get; set; }

        public PostType TypeOfQuery { get; set; }

        public String Boundary { get; private set; }

        public Encoding m_Encoding { get; set; }

        #endregion

        #region << Методы >>

        public byte[] ToByte()
        {
            byte[] bytes = null;


            if (this.TypeOfQuery == PostType.application_x_www_form_urlencode && PostValueCollection.Count > 0)
            {
                bytes = PostValueCollection.ToByteUrlEncode(this.m_Encoding);
            }

            else if (this.TypeOfQuery == PostType.multipart_form_data)
            {
                bytes = PostValueCollection.ToByteMultiPart(this.Boundary, this.m_Encoding);
                using (MemoryStream MemStream = new MemoryStream())
                {
                    if (bytes != null && bytes.Length > 0) MemStream.Write(bytes, 0, bytes.Length);
                    foreach (FileData FileNow in this.FileDataCollection)
                    {
                        StringBuilder output = new StringBuilder("--" + this.Boundary + "\r\n");
                        output.AppendFormat
                        (
                            "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2} \r\n\r\n",
                             FileNow.PostValueName,
                             FileNow.FileName,
                             (String.IsNullOrEmpty(FileNow.FileType) == false ? FileNow.FileType : "application/octet-stream")

                        );
                        bytes = m_Encoding.GetBytes(output.ToString());
                        MemStream.Write(bytes, 0, bytes.Length);
                        MemStream.Write(FileNow.FileBody, 0, FileNow.FileBody.Length);
                        bytes = m_Encoding.GetBytes("\r\n");
                        MemStream.Write(bytes, 0, bytes.Length);
                    }
                    bytes = m_Encoding.GetBytes(this.Boundary + "--" + "\r\n");
                    MemStream.Write(bytes, 0, bytes.Length);
                    bytes = MemStream.ToArray();
                }
            }

            return bytes;
        }

        public string GetContentTypeHeader()
        {
            if (this.TypeOfQuery == PostType.application_x_www_form_urlencode)
            {
                return "application/x-www-form-urlencoded; charset=" + m_Encoding.BodyName;
            }
            else
            {
                return "multipart/form-data; boundary=" + this.Boundary.Remove(0, 2);
            }
        }

        public void Reinit()
        {
            Reinit(null);
        }

        public void Reinit(PostType? Arg_TypeOfQuery)
        {
            this.Boundary = "-----------------------------" + DateTime.Now.Ticks.ToString("x");
            this.FileDataCollection = new List<FileData>();
            this.PostValueCollection = new PostValue();
            if (Arg_TypeOfQuery != null)
                TypeOfQuery = Arg_TypeOfQuery.Value;
        }

        #endregion
    }

    #region << Дополнительные типы >>

    public struct FileData 
    {
        public string FileName;

        public byte[] FileBody;

        public string FileType;

        public string PostValueName;
    }

    public enum PostType 
    {
        application_x_www_form_urlencode,
        multipart_form_data
    }

    public class PostValue : NameValueCollection 
    {
        public byte[] ToByteUrlEncode(Encoding Arg_Encoding)
        {
            byte[] bytes = null;
            if (this.AllKeys.Length > 0)
            {
                if (Arg_Encoding == null) Arg_Encoding = Encoding.ASCII;
                StringBuilder builder = new StringBuilder();
                foreach (string str3 in this.AllKeys)
                {
                    builder.Append(HttpUtility.UrlEncode(HttpUtility.UrlDecode(str3)));
                    builder.Append("=");
                    builder.Append(HttpUtility.UrlEncode(HttpUtility.UrlDecode(this[str3])));
                    builder.Append("&");
                }
                bytes = Arg_Encoding.GetBytes(builder.ToString().TrimEnd('&'));
            }
            return bytes;
        }

        public byte[] ToByteUrlEncode()
        {
            return this.ToByteUrlEncode(null);
        }

        public byte[] ToByteMultiPart(string Boundary, Encoding Arg_Encoding)
        {
            if (String.IsNullOrEmpty(Boundary))
            {
                throw new ArgumentNullException("Boundary");
            }
            byte[] bytes = null;
            if (this.AllKeys.Length > 0 && string.IsNullOrEmpty(Boundary) == false)
            {
                if (Arg_Encoding == null) Arg_Encoding = Encoding.ASCII;
                StringBuilder builder = new StringBuilder();
                foreach (string str3 in this.AllKeys)
                {
                    builder.Append(Boundary + "\r\n");
                    builder.Append("Content-Disposition: form-data; name=\"" + str3 + "\"\r\n\r\n");
                    builder.Append(this[str3] + "\r\n");
                }
                bytes = Arg_Encoding.GetBytes(builder.ToString());
            }
            return bytes;
        }

        public byte[] ToByteMultiPart(string Boundary)
        {
            return this.ToByteMultiPart(Boundary, null);
        }

        public void Add(string ValueCollection)
        {
            if (String.IsNullOrEmpty(ValueCollection))
                throw new ArgumentNullException(ValueCollection);
            ValueCollection = ValueCollection.Trim('&');
            if (ValueCollection.Contains("&"))
            {
                string[] Value = ValueCollection.Split('&');
                foreach (string ValueNow in Value)
                {
                    if (ValueNow.Contains("="))
                    {
                        this.Add(ValueNow);
                    }
                }
                return;
            }
            else if (ValueCollection.Contains("=") && ValueCollection.StartsWith("=") == false)
            {
                int IndexOf = ValueCollection.IndexOf('=');
                string key = ValueCollection.Substring(0, IndexOf);
                string value = IndexOf < ValueCollection.Length ?
                       ValueCollection.Substring(++IndexOf, ValueCollection.Length - IndexOf) : string.Empty;

                this.Add(key, value);
                return;
            }
            throw new ArgumentException("Argument must be separated by '&' or '='.", ValueCollection);
        }
    }

    #endregion
}
