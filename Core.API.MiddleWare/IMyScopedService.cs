using System;

namespace Core.API.MiddleWare
{
    public interface IMyScopedService
    {
        public DateTime ReceiveTime {get;set;}
        public string Author {get;set;}
    }
}