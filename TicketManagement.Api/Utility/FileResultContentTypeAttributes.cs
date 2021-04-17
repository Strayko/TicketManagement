using System;

namespace TicketManagement.Api.Utility
{
    [AttributeUsage(AttributeTargets.Method)]
    public class FileResultContentTypeAttributes : Attribute
    {
        public FileResultContentTypeAttributes(string contentType)
        {
            ContentType = contentType;
        }
        
        public string ContentType { get; }
    }
}