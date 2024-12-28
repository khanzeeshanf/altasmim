using System;
using System.Collections.Generic;
using System.Text;

namespace UrlBuilderPattern
{
    public class Url
    {
        public string Protocol { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Path { get; set; }
        public Dictionary<string, string> QueryParams { get; set; } = new Dictionary<string, string>();

        public override string ToString()
        {
            var url = new StringBuilder();
            url.Append($"{Protocol}://{Host}");

            if (Port > 0)
            {
                url.Append($":{Port}");
            }

            if (!string.IsNullOrEmpty(Path))
            {
                url.Append($"/{Path}");
            }

            if (QueryParams.Count > 0)
            {
                url.Append("?");
                foreach (var param in QueryParams)
                {
                    url.Append($"{param.Key}={param.Value}&");
                }
                url.Length--; // Remove the last '&'
            }

            return url.ToString();
        }
    }

    public interface IUrlBuilder
    {
        IUrlBuilder SetProtocol(string protocol);
        IUrlBuilder SetHost(string host);
        IUrlBuilder SetPort(int port);
        IUrlBuilder SetPath(string path);
        IUrlBuilder AddQueryParam(string key, string value);
        Url Build();
    }

    public class UrlBuilder : IUrlBuilder
    {
        private Url _url = new Url();

        public IUrlBuilder SetProtocol(string protocol)
        {
            _url.Protocol = protocol;
            return this;
        }

        public IUrlBuilder SetHost(string host)
        {
            _url.Host = host;
            return this;
        }

        public IUrlBuilder SetPort(int port)
        {
            _url.Port = port;
            return this;
        }

        public IUrlBuilder SetPath(string path)
        {
            _url.Path = path;
            return this;
        }

        public IUrlBuilder AddQueryParam(string key, string value)
        {
            _url.QueryParams[key] = value;
            return this;
        }

        public Url Build()
        {
            return _url;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IUrlBuilder builder = new UrlBuilder();
            Url url = builder
                .SetProtocol("https")
                .SetHost("www.example.com")
                .SetPort(443)
                .SetPath("path/to/resource")
                .AddQueryParam("key1", "value1")
                .AddQueryParam("key2", "value2")
                .Build();

            Console.WriteLine(url.ToString());
        }
    }
}